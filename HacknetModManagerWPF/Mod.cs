using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Octokit;

namespace HacknetModManager {
    public class Mod {
        public const string INFO_EXT = ".hackmod";
        public const string DISABLED_EXT = ".disabled";

        /// <summary>
        /// Name of the mod based on the DLL file.
        /// </summary>
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }
        /// <summary>
        /// Homepage URL.
        /// </summary>
        public string Homepage { get; set; }
        /// <summary>
        /// Download repository URL.
        /// </summary>
        public string Repository { get; set; }
        public string[] Authors { get; set; }
        public string Info { get; set; }
        public List<string> Files { get; private set; }

        public Mod() : this("", "") { }

        public Mod(string name) : this(name, "") { }

        public Mod(string name, string repository) {
            Name = name;
            Title = "";
            Description = "";
            Version = "";
            Homepage = "";
            Repository = repository;
            Authors = new string[] { };
            Info = "";
            Files = new List<string>();
        }

        /// <summary>
        /// Update the mod from its repository.
        /// </summary>
        /// <param name="client">GitHub client</param>
        /// <param name="downloadFolder">where to download repository files</param>
        /// <param name="extractFolder">where to extract files from a zip</param>
        /// <param name="modsFolder">where mods are stored</param>
        /// <param name="release">user-selected release</param>
        /// <returns>whether update was successful</returns>
        public bool Update(GitHubClient client, string downloadFolder, string extractFolder, string modsFolder,
            Release release = null) {
            Match match;

            if(IsValid(client, Repository, out match)) {
                return Download(client, release, match, downloadFolder, extractFolder, modsFolder);
            }

            return false;
        }

        /// <summary>
        /// Remove mod files.
        /// </summary>
        public void Remove() {
            if(Files.Count > 0) {
                foreach(string file in Files) {
                    if(File.Exists(file)) File.Delete(file);
                }

                Files.Clear();
            }
        }

        /// <summary>
        /// Read mod info from its <see cref="INFO_EXT"/> file.
        /// </summary>
        /// <param name="file"><see cref="INFO_EXT"/> file for the mod</param>
        /// <returns>this mod</returns>
        public Mod ReadInfo(string file) {
            if(File.Exists(file)) {
                this.Copy(JsonConvert.DeserializeObject<Mod>(File.ReadAllText(file)));
                Name = Path.GetFileNameWithoutExtension(file);
            }

            return this;
        }

        /// <summary>
        /// Write the mod info to its <see cref="INFO_EXT"/> file.
        /// </summary>
        /// <param name="file"><see cref="INFO_EXT"/> file for the mod</param>
        public void WriteInfo(string file) {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            FileStream stream;
            string directory = Path.GetDirectoryName(file);

            if(!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }

            if(!File.Exists(file)) {
                stream = File.Create(file);
            }
            else {
                stream = File.OpenWrite(file);
            }

            using(StreamWriter writer = new StreamWriter(stream)) {
                writer.Write(json);
            }
        }

        /// <summary>
        /// Download the mod from its repository.
        /// </summary>
        /// <param name="client">GitHub client</param>
        /// <param name="release">selected release</param>
        /// <param name="validatedRepo">validated repository URL from <see cref="IsValid(GitHubClient, string, out Match)"/></param>
        /// <param name="downloadFolder">where to download repository files</param>
        /// <param name="extractFolder">where to extract files from a zip</param>
        /// <param name="modsFolder">where mods are stored</param>
        /// <returns>whether download was successful</returns>
        private bool Download(GitHubClient client, Release release, Match validatedRepo, string downloadFolder, string extractFolder,
            string modsFolder) {
            string user = validatedRepo.Groups[1].Value;
            string repo = validatedRepo.Groups[2].Value;

            IReadOnlyList<ReleaseAsset> assets = null;

            try {
                if(release == null) {
                    release = client.Repository.Release.GetLatest(user, repo).Result;
                }

                assets = client.Repository.Release.GetAllAssets(user, repo, release.Id).Result;
            }
            catch(Exception e) {
                if(e is AggregateException || e is RateLimitExceededException) {
                    RateUtils.ShowRateErrorMessage(client, false);
                    return false;
                }
            }

            if(assets.Count > 0) {
                // begin downloading files
                WebClient web = new WebClient();
                string[] urls = assets.Select(a => a.BrowserDownloadUrl).ToArray();
                string[] names = assets.Select(a => a.Name).ToArray();
                string info = names.FirstOrDefault(n => n.EndsWith(INFO_EXT));
                List<string> files = new List<string>();
                bool unzipped = false;
               
                if(string.IsNullOrWhiteSpace(info) && !names.Any(n => n.EndsWith(".zip"))) {
                    return false;
                }

                // remove old files
                Remove();

                for(int i = 0; i < urls.Length; i++) {
                    string download = Path.Combine(downloadFolder, names[i]);
                    string extract = Path.Combine(extractFolder, names[i]);
                    string filename = Path.GetFileName(extract);

                    if(File.Exists(download)) File.Delete(download);

                    web.DownloadFile(urls[i], download);

                    // if zip file, extract it and return result if not valid
                    if(download.EndsWith(".zip")) {
                        List<string> unzippedFiles = FileUtils.Unzip(download, extractFolder);
                        string unzippedInfo = unzippedFiles.FirstOrDefault(u => u.EndsWith(INFO_EXT));

                        // if zip contains an info file and there are none present in the assets, read info from extracted file
                        if(string.IsNullOrWhiteSpace(info) && !string.IsNullOrWhiteSpace(unzippedInfo)) {
                            info = unzippedInfo;
                            unzippedFiles.Remove(unzippedInfo);
                            unzipped = true;
                        }

                        // add files to mod
                        files.AddRange(unzippedFiles.Select(f => f.Replace(extractFolder, modsFolder)).ToList());
                    }
                    // if info file, set it as the mod info file
                    else if(download.EndsWith(INFO_EXT)) {
                        info = download;
                    }
                    // otherwise, it's a content file and add it to Files
                    else if(!files.Contains(filename)) {
                        files.Add(filename.Replace(downloadFolder, modsFolder));
                    }
                }

                // if an info file was found outside a zip file, read from it
                if(!string.IsNullOrWhiteSpace(info)) {
                    ReadInfo(info);
                }
                // if we extracted our zip files and found no info file, and there wasn't one present outside a zip file,
                // this is not a valid mod.
                else if(!unzipped) {
                    // delete all files from the failed download
                    foreach(string file in files) {
                        if(File.Exists(file)) File.Delete(file);
                    }
                    
                    return false;
                }

                // copy all the files to the mods folder
                FileUtils.FileCopyWithReplicate(extractFolder, modsFolder, true, true);

                // update the files list and write it to the info file
                Files = files;
                WriteInfo(info);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Unzip a zip file containing a mod.
        /// </summary>
        /// <param name="file">zip file path</param>
        /// <param name="extractFolder">where to extract files</param>
        /// <param name="modsFolder">where mods are stored</param>
        /// <returns>whether zip file is a valid mod</returns>
        public bool Unzip(string file, string extractFolder, string modsFolder) {
            List<string> files = FileUtils.Unzip(file, extractFolder);
            string info = files.FirstOrDefault(f => f.EndsWith(INFO_EXT));

            if(files.Count > 0 && !string.IsNullOrWhiteSpace(info)) {
                ReadInfo(Path.Combine(extractFolder, info));
                
                files.Remove(info);
                Files.AddRange(files.Select(f => f.Replace(extractFolder, modsFolder)).ToList());

                FileUtils.FileCopyWithReplicate(extractFolder, modsFolder, true, true);
                return true;
            }

            // if this is an invalid zip file, remove extracted files
            FileUtils.DeleteDirectoryContents(extractFolder);

            return false;
        }

        /// <summary>
        /// Check if a repository is valid.
        /// </summary>
        /// <param name="client">GitHub client</param>
        /// <param name="repository">repository URL</param>
        /// <param name="match">regex match to contain capture groups</param>
        /// <returns>whether the repository is valid</returns>
        public static bool IsValid(GitHubClient client, string repository, out Match match) {
            match = Regex.Match(repository, @".*github\.com\/(.*?)\/([\w\d-_.]+)\/?");

            if(client != null && match.Success) {
                try {
                    SearchRepositoriesRequest request = new SearchRepositoriesRequest(match.Groups[2].Value) {
                        User = match.Groups[1].Value
                    };

                    return client.Search.SearchRepo(request).Result.TotalCount > 0;
                }
                catch(Exception e) {
                    if(e is AggregateException || e is RateLimitExceededException) {
                        RateUtils.ShowRateErrorMessage(client, false);
                    }
                }
            }

            return false;
        }

        /*private async void DownloadAsync(GitHubClient client, Release release, string user, string repo, string modsFolder,
            string downloadFolder, string extractFolder) {
            if(release == null) {
                release = await client.Repository.Release.GetLatest(user, repo);
            }

            var assets = await client.Repository.Release.GetAllAssets(user, repo, release.Id);

            if(assets.Count > 0) {
                WebClient web = new WebClient();
                var downloads = assets.Where(a => a.Name.Contains(".zip") || a.Name.Contains(".dll"));
                string[] urls = downloads.Select(d => d.BrowserDownloadUrl).ToArray();
                string[] files = downloads.Select(d => d.Name).ToArray();

                for(int i = 0; i < urls.Length; i++) {
                    string filename = files[i];
                    string download = Path.Combine(downloadFolder, filename);

                    web.DownloadFileCompleted += (s, e) => {
                        if(download.Contains(".zip")) {
                            Unzip(modsFolder, extractFolder, download);
                        }
                        else if(download.Contains(".dll")) {
                            string json = Path.Combine(modsFolder, filename.Replace(".dll", FILE_EXTENSION));

                            if(File.Exists(json)) {
                                File.Delete(json);
                            }

                            FileUtils.FileCopyWithReplicate(download, Path.Combine(modsFolder, filename), true, deleteSource: true);
                            this.Copy(new Mod() { Name = this.Name, Repository = "https://github.com/" + user + "/" + repo });
                            WriteInfo(modsFolder);
                        }
                    };

                    web.DownloadFileAsync(new Uri(urls[i]), download);
                }
            }
        }*/



        /*public async void UnzipAsync(string modsFolder, string extractFolder, string zipFile) {
            string jsonFile = "";

            using(ZipArchive archive = ZipFile.OpenRead(zipFile)) {
                foreach(ZipArchiveEntry entry in archive.Entries) {
                    if(entry.FullName.EndsWith(FILE_EXTENSION, StringComparison.OrdinalIgnoreCase)) {
                        jsonFile = Path.Combine(extractFolder, entry.Name);
                    }

                    string file = Path.Combine(extractFolder, entry.FullName);

                    if(File.Exists(file)) {
                        File.Delete(file);
                    }

                    await Task.Run(() => entry.ExtractToFile(Path.Combine(extractFolder, entry.FullName)));
                }
            }

            if(!string.IsNullOrWhiteSpace(jsonFile) && File.Exists(jsonFile)) {
                string modName = Path.GetFileNameWithoutExtension(jsonFile);
                this.Copy(Parse(modName, jsonFile));
            }
            else {
                this.Copy(new Mod(Path.GetFileNameWithoutExtension(zipFile)));
            }

            FileUtils.FileCopyWithReplicate(extractFolder, modsFolder, true, deleteSourceContents: true);
        }*/
    }
}
