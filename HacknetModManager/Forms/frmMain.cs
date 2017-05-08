using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HacknetModManager {
    public partial class frmMain : Form {
        public static string ModsFolder { get; private set; }
        public static string DownloadsFolder { get; private set; }
        public static string ExtractFolder { get; private set; }
        public static Dictionary<string, Mod> Mods { get; private set; }

        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            if(!CheckForHacknet() && !CheckForPathfinder()) {
                MessageBox.Show("Could not find Hacknet or Pathfinder installation. Please place Mod Manager in the same folder as Hacknet.", "Hacknet Missing");
                Application.Exit();
            }

            Mods = new Dictionary<string, Mod>();

            InitializeFolders();
            LoadMods();
            ResizeLabels();
        }

        private void frmMain_Activated(object sender, EventArgs e) {
            btnPlayUnmodded.Enabled = CheckForHacknet();
            btnPlayPathfinder.Enabled = CheckForPathfinder();
        }

        private void btnPlayPathfinder_Click(object sender, EventArgs e) {
            Process.Start("HacknetPathfinder.exe");
        }

        private void btnPlayUnmodded_Click(object sender, EventArgs e) {
            Process.Start("steam://rungameid/365450");
        }

        private void frmMain_Resize(object sender, EventArgs e) {
            ResizeLabels();
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            LoadMods();
        }

        private void btnOpenModFolder_Click(object sender, EventArgs e) {
            Process.Start(ModsFolder);
        }

        private void btnEnableAll_Click(object sender, EventArgs e) {
            SetCheckedAll(true);
        }

        private void btnDisableAll_Click(object sender, EventArgs e) {
            SetCheckedAll(false);
        }

        private void btnInstall_Click(object sender, EventArgs e) {

        }

        private void btnRemove_Click(object sender, EventArgs e) {
            var selected = listMods.SelectedItems;

            foreach(ListViewItem item in selected) {
                Mods[item.Text].Remove();
                Mods.Remove(item.Text);
                listMods.Items.Remove(item);
            }
        }

        private void listMods_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            Mod mod = Mods[e.Item.Text];

            if(!string.IsNullOrWhiteSpace(mod.Title)) {
                lblTitleVersion.Text = mod.Title;

                if(!string.IsNullOrWhiteSpace(mod.Version)) {
                    lblTitleVersion.Text += " " + mod.Version;
                }
            }
            else lblTitleVersion.Text = "N/A";

            lblDescription.Text = (string.IsNullOrWhiteSpace(mod.Description) ? "N/A" : mod.Description);
            lblAuthors.Text = (mod.Authors.Length == 0 ? "N/A" : string.Join(", ", mod.Authors));
        }

        private void ResizeLabels() {
            lblDescription.ConstrainMaximumWidthToParent(lblDescription.Margin.Right * 4);
            lblAuthors.ConstrainMaximumWidthToParent(lblAuthors.Margin.Right * 4);
            lblTitleVersion.ConstrainMaximumWidthToParent(lblTitleVersion.Margin.Right * 4);
        }

        private bool CheckForHacknet() {
            return File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Hacknet.exe"));
        }

        private bool CheckForPathfinder() {
            return File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "HacknetPathfinder.exe"));
        }

        private void InitializeFolders() {
            string dir = Directory.GetCurrentDirectory();

            ModsFolder = Path.Combine(dir, "Mods");
            DownloadsFolder = Path.Combine(dir, "ModManager");
            ExtractFolder = Path.Combine(ModsFolder, "Downloads");

            FileUtils.CreateFolder(ModsFolder);
            FileUtils.CreateFolder(DownloadsFolder);
            FileUtils.CreateFolder(ExtractFolder);
        }

        private void LoadMods() {
            if(Mods.Count > 0) Mods.Clear();

            var dlls = Directory.GetFiles(ModsFolder, "*.dll", SearchOption.TopDirectoryOnly);
            var jsons = Directory.GetFiles(ModsFolder, "*.json", SearchOption.TopDirectoryOnly);

            foreach(string dll in dlls) {
                string name = Path.GetFileNameWithoutExtension(dll);

                string json = jsons.FirstOrDefault(j => Regex.IsMatch(j, @".*\\" + name + @"\.json"));

                if(!string.IsNullOrWhiteSpace(json)) {
                    Mods.Add(name, Mod.Parse(name, json));
                }
                else {
                    Mods.Add(name, new Mod(name));
                }
            }

            foreach(string name in Mods.Keys) {
                listMods.Items.Add(name);
            }
        }
        
        private void SetCheckedAll(bool check) {
            for(int i = 0; i < listMods.Items.Count; i++) {
                listMods.Items[i].Checked = check;
            }
        }
    }
}
