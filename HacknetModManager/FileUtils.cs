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

        // --------------------------------------------------------------------
        // Following source modified from http://stackoverflow.com/a/12292399/567983

        public static void FileCopyWithReplicate(string source, string dest, bool overwrite, bool deleteSource = false,
            bool deleteContents = false) {
            string destDirectory = Path.GetDirectoryName(dest);
            Directory.CreateDirectory(destDirectory);

            if(Directory.Exists(source)) {
                DirectoryCopy(source, dest, overwrite, deleteContents);
                if(deleteSource) Directory.Delete(source);
            }
            else if(File.Exists(source)) {
                File.Copy(source, dest, overwrite);
                if(deleteSource) File.Delete(source);
            }
        }

        private static void DirectoryCopy(string source, string dest, bool recursive, bool delete) {
            DirectoryInfo dir = new DirectoryInfo(source);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if(!dir.Exists) {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + source);
            }

            if(!Directory.Exists(dest)) {
                Directory.CreateDirectory(dest);
            }

            FileInfo[] files = dir.GetFiles();
            foreach(FileInfo file in files) {
                string temppath = Path.Combine(dest, file.Name);
                file.CopyTo(temppath, true);

                if(delete) file.Delete();
            }

            if(recursive) {
                foreach(DirectoryInfo subdir in dirs) {
                    string temppath = Path.Combine(dest, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, recursive, delete);
                }
            }
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
