using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Octokit;

namespace HacknetModManager {
    public class Mod {
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
        }

        public bool Update(GitHubClient client, string modsFolder, string downloadFolder, string extractFolder,
            Release release = null) {//, bool async = false) {
            Match match;

            if(IsValid(client, Repository, out match)) {
                //if(async) {
                //    DownloadAsync(client, release, user, repo, modsFolder, downloadFolder, extractFolder);
                //}
                //else {
                Download(client, release, match, modsFolder, downloadFolder, extractFolder);
                //}

                return true;
            }

            return false;
        }

        public void WriteInfo(string modsFolder) {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            string file = Path.Combine(modsFolder, Name + ".json");
            FileStream stream;

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

        public void Remove() {
            if(!string.IsNullOrWhiteSpace(Name)) {
                string[] files = Directory.GetFiles(frmMain.ModsFolder, Name + "*");

                foreach(string file in files) {
                    File.Delete(file);
                }
            }
        }

        private void Download(GitHubClient client, Release release, Match validatedUrl, string modsFolder, string downloadFolder,
            string extractFolder) {
            string user = validatedUrl.Groups[1].Value;
            string repo = validatedUrl.Groups[2].Value;

            if(release == null) {
                release = client.Repository.Release.GetLatest(user, repo).Result;
            }

            var assets = client.Repository.Release.GetAllAssets(user, repo, release.Id).Result;

            if(assets.Count > 0) {
                WebClient web = new WebClient();
                var downloads = assets.Where(a => a.Name.Contains(".zip") || a.Name.Contains(".dll"));
                string[] urls = downloads.Select(d => d.BrowserDownloadUrl).ToArray();
                string[] files = downloads.Select(d => d.Name).ToArray();

                for(int i = 0; i < urls.Length; i++) {
                    string download = Path.Combine(downloadFolder, files[i]);

                    web.DownloadFile(new Uri(urls[i]), download);

                    if(download.Contains(".zip")) {
                        Unzip(modsFolder, extractFolder, download);
                    }
                    else if(download.Contains(".dll")) {
                        string json = Path.Combine(modsFolder, files[i].Replace(".dll", ".json"));

                        if(File.Exists(json)) {
                            File.Delete(json);
                        }

                        FileUtils.FileCopyWithReplicate(download, Path.Combine(modsFolder, files[i]), true, deleteSource: true);
                        this.Copy(new Mod() { Name = this.Name, Repository = validatedUrl.Value });
                        WriteInfo(modsFolder);
                    }
                }
            }
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
                            string json = Path.Combine(modsFolder, filename.Replace(".dll", ".json"));

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

        public void Unzip(string modsFolder, string extractFolder, string zipFile) {
            string jsonFile = "";

            using(ZipArchive archive = ZipFile.OpenRead(zipFile)) {
                foreach(ZipArchiveEntry entry in archive.Entries) {
                    if(entry.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase)) {
                        jsonFile = Path.Combine(extractFolder, entry.Name);
                    }

                    string file = Path.Combine(extractFolder, entry.FullName);

                    if(File.Exists(file)) {
                        File.Delete(file);
                    }

                    entry.ExtractToFile(Path.Combine(extractFolder, entry.FullName));
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
        }

        /*public async void UnzipAsync(string modsFolder, string extractFolder, string zipFile) {
            string jsonFile = "";

            using(ZipArchive archive = ZipFile.OpenRead(zipFile)) {
                foreach(ZipArchiveEntry entry in archive.Entries) {
                    if(entry.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase)) {
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

        public static Mod Parse(string name, string file) {
            Mod jsonMod = JsonConvert.DeserializeObject<Mod>(File.ReadAllText(file));
            jsonMod.Name = name;

            return jsonMod;
        }

        public static bool IsValid(GitHubClient client, string repository, out Match match) {
            match = Regex.Match(repository, @".*github\.com\/(.*?)\/([\w\d-_.]+)\/?");

            if(client != null && !string.IsNullOrWhiteSpace(repository) && match.Success) {
                try {
                    SearchRepositoriesRequest request = new SearchRepositoriesRequest(match.Groups[2].Value) {
                        User = match.Groups[1].Value
                    };

                    return client.Search.SearchRepo(request).Result.TotalCount > 0;
                }
                catch(FormatException) {
                    return false;
                }
            }

            return false;
        }
    }
}
