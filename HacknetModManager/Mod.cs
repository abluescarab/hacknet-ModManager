using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
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

        private GitHubClient client;

        Mod() : this("", "") { }

        public Mod(string name) : this(name, "") { }

        public Mod(string name, string repository) {
            Name = name;
            Repository = repository;
        }

        public void Update(string downloadFolder, string extractFolder) {
            Match match;

            if(IsValid(Repository, out match)) {
                string user = match.Groups[1].ToString();
                string repo = match.Groups[2].ToString();
                client = new GitHubClient(new ProductHeaderValue(repo));

                var download = BeginDownload(client, user, repo, downloadFolder, extractFolder);
            }
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
                        this.Copy(Unzip(extractFolder, file).Result);
                    };

                    web.DownloadFileAsync(new Uri(urls[i]), file);
                }
            }
        }

        public void Remove() {
            if(!string.IsNullOrWhiteSpace(Name)) {
                
            }
        }

        public static bool IsValid(string repository, out Match match) {
            match = Regex.Match(repository, ".*github.com/(.*)/(.*)");
            return !string.IsNullOrWhiteSpace(repository) && match.Success;
        }

        public static Mod Parse(string name, string file) {
            Mod jsonMod = JsonConvert.DeserializeObject<Mod>(File.ReadAllText(file));
            jsonMod.Name = name;

            return jsonMod;
        }
        
        private static async Task<Mod> Unzip(string extractFolder, string file) {
            string jsonName = "";
            string jsonFile = "";

            using(ZipArchive archive = ZipFile.OpenRead(file)) {
                foreach(ZipArchiveEntry entry in archive.Entries) {
                    if(entry.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase)) {
                        jsonName = entry.Name;
                    }

                    await Task.Run(() => entry.ExtractToFile(Path.Combine(extractFolder, entry.FullName)));
                }
            }

            if(!string.IsNullOrWhiteSpace(jsonName)) {
                jsonFile = Path.Combine(extractFolder, jsonName);
                string mod = Path.GetFileNameWithoutExtension(jsonName);

                return Parse(mod, jsonFile);
            }
            else {
                return new Mod(Path.GetFileNameWithoutExtension(file));
            }
        }
    }
}
