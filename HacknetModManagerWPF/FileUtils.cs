using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;

namespace HacknetModManager {
    public static class FileUtils {
        /// <summary>
        /// Create a folder.
        /// </summary>
        /// <param name="path">folder path</param>
        public static void CreateFolder(string path) {
            if(!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Start a process silently.
        /// </summary>
        /// <param name="path">path to process</param>
        /// <param name="args">arguments to send to process</param>
        public static void StartSilent(string path, string[] args) {
            Process process = new Process();

            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.FileName = path;
            process.StartInfo.Arguments = string.Join(" ", args);

            process.Start();
        }

        /// <summary>
        /// Get files with multiple search patterns.
        /// </summary>
        /// <param name="path">folder path</param>
        /// <param name="searchOption">search option</param>
        /// <param name="searchPattern">first search pattern</param>
        /// <param name="searchPatterns">subsequent search patterns</param>
        /// <returns>files matching search patterns</returns>
        public static string[] GetFiles(string path, SearchOption searchOption, string searchPattern, params string[] searchPatterns) {
            List<string> files = new List<string>();

            files.AddRange(Directory.GetFiles(path, searchPattern, searchOption));

            foreach(string pattern in searchPatterns) {
                files.AddRange(Directory.GetFiles(path, pattern, searchOption));
            }

            files.Sort();
            return files.ToArray();
        }

        /// <summary>
        /// Unzip a file.
        /// </summary>
        /// <param name="file">zip file path</param>
        /// <param name="extractFolder">where to extract files</param>
        /// <returns>list of extracted files</returns>
        public static List<string> Unzip(string file, string extractFolder) {
            List<string> files = new List<string>();

            if(!Directory.Exists(extractFolder)) {
                Directory.CreateDirectory(extractFolder);
            }

            if(!string.IsNullOrWhiteSpace(file) && file.EndsWith(file) && File.Exists(file)) {
                using(ZipArchive archive = ZipFile.OpenRead(file)) {
                    foreach(ZipArchiveEntry entry in archive.Entries) {
                        string extracted = Path.Combine(extractFolder, entry.FullName);

                        if(File.Exists(extracted)) {
                            File.Delete(extracted);
                        }

                        entry.ExtractToFile(extracted);
                        files.Add(extracted);
                    }
                }
            }

            return files;
        }

        /// <summary>
        /// Delete a directory's content.
        /// </summary>
        /// <param name="directory">directory path</param>
        /// <param name="recursive">whether to delete subdirectories</param>
        public static void DeleteDirectoryContents(string directory, bool recursive = true, bool deleteDirectory = false) {
            DirectoryInfo dir = new DirectoryInfo(directory);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if(!dir.Exists) {
                throw new DirectoryNotFoundException(
                    "Directory does not exist or could not be found: " + directory);
            }

            FileInfo[] files = dir.GetFiles();
            foreach(FileInfo file in files) {
                file.Delete();
            }

            if(recursive) {
                foreach(DirectoryInfo subdir in dirs) {
                    DeleteDirectoryContents(subdir.FullName, recursive);
                }
            }

            if(deleteDirectory) {
                dir.Delete();
            }
        }

        // --------------------------------------------------------------------
        // Following source modified from http://stackoverflow.com/a/12292399/567983

        public static void FileCopyWithReplicate(string source, string dest, bool overwrite, bool deleteSource = false,
            bool deleteSourceContents = false) {
            string destDirectory = Path.GetDirectoryName(dest);
            Directory.CreateDirectory(destDirectory);

            if(deleteSource) deleteSourceContents = true;

            if(Directory.Exists(source)) {
                DirectoryCopy(source, dest, overwrite, deleteSourceContents);
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
    }
}
