using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Octokit;

namespace HacknetModManager {
    static class FileUtils {
        public static void CreateFolder(string path) {
            if(!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
        }

        public static void StartSilent(string path, string[] args) {
            Process process = new Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = path;
            process.StartInfo.Arguments = string.Join(" ", args);

            process.Start();
        }

        //
        //        public static void CreateFile(string path, string data) {
        //            var file = CreateFileAsync(path, data);
        //        }
        //
        //        private async static Task CreateFileAsync(string path, string data) {
        //            using(StreamWriter writer = new StreamWriter(path, false)) {
        //                await writer.WriteAsync(data);
        //            }
        //        }
    }
}
