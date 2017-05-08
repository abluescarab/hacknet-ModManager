using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
            Repository = repository;
            Authors = new string[] { };
        }

        public bool Update(GitHubClient client, string downloadFolder, string extractFolder) {
            Match match;

            if(IsValid(client, Repository, out match)) {
                string user = match.Groups[1].ToString();
                string repo = match.Groups[2].ToString();

                var download = BeginDownload(client, user, repo, downloadFolder, extractFolder);
                return true;
            }

            return false;
        }

        private async Task BeginDownload(GitHubClient client, string user, string repo, string downloadFolder, string extractFolder) {
            var repository = client.Repository;
            var release = await client.Repository.Release.GetLatest(user, repo);
            var assets = await client.Repository.Release.GetAllAssets(user, repo, release.Id);

            if(assets.Count > 0) {
                WebClient web = new WebClient();
                var zips = assets.Where(a => a.Name.Contains(".zip"));
                string[] urls = zips.Select(z => z.BrowserDownloadUrl).ToArray();
                string[] files = zips.Select(z => z.Name).ToArray();

                for(int i = 0; i < urls.Length; i++) {
                    string file = Path.Combine(downloadFolder, files[i]);

                    web.DownloadFileCompleted += (s, e) => {
                        Mod mod = Unzip(extractFolder, file).Result;

                        this.Copy(mod);
                        
                        if(!frmMain.Mods.ContainsKey(mod.Name)) {
                            frmMain.Mods.Add(mod.Name, mod);
                        }
                    };

                    web.DownloadFileAsync(new Uri(urls[i]), file);
                }
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

        public static bool IsValid(GitHubClient client, string repository, out Match match) {
            match = Regex.Match(repository, ".*github.com/(.*)/(.*)");

            if(client != null && !string.IsNullOrWhiteSpace(repository) && match.Success) {
                try {
                    SearchRepositoriesRequest request = new SearchRepositoriesRequest(match.Groups[2].ToString()) {
                        User = match.Groups[1].ToString()
                    };

                    return client.Search.SearchRepo(request).Result.TotalCount > 0;
                }
                catch(FormatException) {
                    return false;
                }
            }

            return false;
        }
        
        public static Mod Parse(string name, string file) {
            Mod jsonMod = JsonConvert.DeserializeObject<Mod>(File.ReadAllText(file));
            jsonMod.Name = name;

            return jsonMod;
        }

        public static async Task<Mod> Unzip(string extractFolder, string file) {
            string jsonFile = "";
            Mod mod;

            using(ZipArchive archive = ZipFile.OpenRead(file)) {
                foreach(ZipArchiveEntry entry in archive.Entries) {
                    if(entry.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase)) {
                        jsonFile = Path.Combine(extractFolder, entry.Name);
                    }

                    await Task.Run(() => entry.ExtractToFile(Path.Combine(extractFolder, entry.FullName)));
                }
            }

            if(!string.IsNullOrWhiteSpace(jsonFile) && File.Exists(jsonFile)) {
                string modName = Path.GetFileNameWithoutExtension(jsonFile);
                mod = Parse(modName, jsonFile);
            }
            else {
                mod = new Mod(Path.GetFileNameWithoutExtension(file));
            }

            return mod;
        }
    }
}
