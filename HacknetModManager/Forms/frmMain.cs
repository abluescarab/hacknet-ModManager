using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HacknetModManager {
    public partial class frmMain : Form {
        public static string ModsFolder { get; private set; }
        public static string ManagerFolder { get; private set; }
        public static string ExtractFolder { get; private set; }
        public static Dictionary<string, Mod> Mods { get; private set; }
        public static Octokit.GitHubClient Client { get; private set; }

        private bool doEnableDisable = false;

        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            if(!CheckForHacknet() && !CheckForPathfinder()) {
                MessageBox.Show("Could not find Hacknet or Pathfinder installation. Please place Mod Manager in the same folder as Hacknet.", "Hacknet Missing");
                Application.Exit();
            }

            Mods = new Dictionary<string, Mod>();
            Client = new Octokit.GitHubClient(new Octokit.ProductHeaderValue(Assembly.GetExecutingAssembly().GetName().Name));

            InitializeFolders();
            LoadMods();

            if(Mods.Count > 0) {
                listMods.Items[0].Selected = true;
            }
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
            frmInstall form = new frmInstall();
            form.ShowDialog();
            LoadMods();
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            var selected = listMods.SelectedItems;

            foreach(ListViewItem item in selected) {
                Mods[item.Text].Remove();
                Mods.Remove(item.Text);
                listMods.Items.Remove(item);
            }
        }

        private void btnHomepage_Click(object sender, EventArgs e) {
            if(listMods.SelectedItems.Count == 1) {
                Process.Start(Mods[listMods.SelectedItems[0].Text].Homepage);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e) {
            foreach(ListViewItem item in listMods.SelectedItems) {
                Mod mod = Mods[item.Text];
                mod.Update(Client, ModsFolder, ManagerFolder, ExtractFolder, async: true);
            }
        }

        private void btnChooseRelease_Click(object sender, EventArgs e) {
            // todo: open release window
        }

        private void btnEditModInfo_Click(object sender, EventArgs e) {
            frmEdit form = new frmEdit();
            Mod mod = Mods[listMods.SelectedItems[0].Text];

            if(form.ShowDialog(mod) == DialogResult.OK) {
                LoadMod(mod);
            }
            
            mod.WriteInfo(ModsFolder);
        }

        private void btnUpdateModManager_Click(object sender, EventArgs e) {

        }

        private void listMods_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if(listMods.SelectedItems.Count == 1) {
                Mod mod = Mods[e.Item.Text];
                LoadMod(mod);
                btnEditModInfo.Enabled = true;
            }
            else {
                btnHomepage.Enabled = btnUpdate.Enabled = btnChooseRelease.Enabled = false;
                btnEditModInfo.Enabled = false;
                lblTitleVersion.Text = "N/A";
                lblDescription.Text = "N/A";
                lblAuthors.Text = "N/A";
                txtInfo.Text = "No information.";
            }
        }

        private void listMods_ItemChecked(object sender, ItemCheckedEventArgs e) {
            if(doEnableDisable) {
                Mod mod = Mods[e.Item.Text];
                string moveFrom = "";
                string moveTo = "";

                if(e.Item.Checked) {
                    moveFrom = Path.Combine(ModsFolder, mod.Name + ".dll.disabled");
                    moveTo = moveFrom.Remove(moveFrom.LastIndexOf(".disabled"));
                }
                else {
                    moveFrom = Path.Combine(ModsFolder, mod.Name + ".dll");
                    moveTo = moveFrom + ".disabled";
                }

                if(File.Exists(moveFrom)) {
                    File.Copy(moveFrom, moveTo, true);
                    File.Delete(moveFrom);
                }
            }
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
            ManagerFolder = Path.Combine(dir, "ModManager");
            ExtractFolder = Path.Combine(ModsFolder, "Downloads");

            FileUtils.CreateFolder(ModsFolder);
            FileUtils.CreateFolder(ManagerFolder);
            FileUtils.CreateFolder(ExtractFolder);
        }

        private void LoadMod(Mod mod) {
            if(!string.IsNullOrWhiteSpace(mod.Title)) {
                lblTitleVersion.Text = mod.Title;

                if(!string.IsNullOrWhiteSpace(mod.Version)) {
                    lblTitleVersion.Text += " " + mod.Version;
                }
            }
            else lblTitleVersion.Text = mod.Name;

            btnHomepage.Enabled = !string.IsNullOrWhiteSpace(mod.Homepage);
            btnUpdate.Enabled = btnChooseRelease.Enabled = !string.IsNullOrWhiteSpace(mod.Repository);
            lblDescription.Text = (string.IsNullOrWhiteSpace(mod.Description) ? "N/A" : mod.Description);
            lblAuthors.Text = (mod.Authors.Length == 0 ? "N/A" : string.Join(", ", mod.Authors));
            txtInfo.Text = (string.IsNullOrWhiteSpace(mod.Info) ? "No information." : mod.Info);
        }

        private void LoadMods() {
            doEnableDisable = false;

            if(Mods.Count > 0) {
                Mods.Clear();
                listMods.Items.Clear();
            }

            var mods = FileUtils.GetFiles(ModsFolder, SearchOption.TopDirectoryOnly, "*.dll", "*.dll.disabled");
            var jsons = Directory.GetFiles(ModsFolder, "*.json", SearchOption.TopDirectoryOnly);

            foreach(string mod in mods) {
                string name = Regex.Match(mod.Remove(0, mod.LastIndexOf("\\") + 1), @"(.*)\.dll.*").Groups[1].ToString();
                string json = jsons.FirstOrDefault(j => Regex.IsMatch(j, @".*\\" + name + @"\.json"));

                if(!string.IsNullOrWhiteSpace(json)) {
                    Mods.Add(name, Mod.Parse(name, json));
                }
                else {
                    Mods.Add(name, new Mod(name));
                }

                ListViewItem item = listMods.Items.Add(name);
                item.Checked = !mod.Contains(".disabled");
            }

            doEnableDisable = true;
        }

        private void SetCheckedAll(bool check) {
            for(int i = 0; i < listMods.Items.Count; i++) {
                ListViewItem item = listMods.Items[i];

                if(item.Checked != check) {
                    listMods.Items[i].Checked = check;
                }
            }
        }
    }
}
