using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Octokit;

namespace HacknetModManager {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static string ModsFolder { get; private set; }
        public static string ManagerFolder { get; private set; }
        public static string ExtractFolder { get; private set; }
        public static Dictionary<string, Mod> Mods { get; private set; }
        public static GitHubClient Client { get; private set; }
        
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            if(!CheckForHacknet() && !CheckForPathfinder()) {
                MessageBox.Show("Could not find Hacknet or Pathfinder installation. Please place Mod Manager in the same folder as Hacknet.", "Hacknet Missing");
                System.Windows.Application.Current.Shutdown();
            }

            Mods = new Dictionary<string, Mod>();
            Client = new GitHubClient(new ProductHeaderValue(Assembly.GetExecutingAssembly().GetName().Name));

            InitializeFolders();
            LoadMods();
            UpdateStatusBar();
        }

        private void Window_Activated(object sender, EventArgs e) {
            btnPlayUnmodded.IsEnabled = CheckForHacknet();
            btnPlayPathfinder.IsEnabled = CheckForPathfinder();
        }

        private void btnEnableAll_Click(object sender, RoutedEventArgs e) {
            SetCheckedAll(true);
        }

        private void btnDisableAll_Click(object sender, RoutedEventArgs e) {
            SetCheckedAll(false);
        }

        private void btnOpenModsFolder_Click(object sender, RoutedEventArgs e) {
            Process.Start(ModsFolder);
        }

        private void btnInstall_Click(object sender, RoutedEventArgs e) {
            InstallWindow win = new InstallWindow();
            win.ShowDialog();
            LoadMods();
            UpdateStatusBar();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e) {
            var selected = listMods.SelectedItems;

            foreach(ModListViewItem item in selected) {
                item.Mod.Remove();
                Mods.Remove(item.Mod.Name);
                listMods.Items.Remove(item);
            }
        }

        private void btnReload_Click(object sender, RoutedEventArgs e) {
            LoadMods();
            UpdateStatusBar();
        }

        private void btnVisitHomepage_Click(object sender, RoutedEventArgs e) {
            if(listMods.SelectedItems.Count == 1) {
                Process.Start(((ModListViewItem)listMods.SelectedItems[0]).Mod.Homepage);
            }
        }

        private void btnUpdateMod_Click(object sender, RoutedEventArgs e) {
            Cursor = Cursors.Wait;

            foreach(ModListViewItem item in listMods.SelectedItems) {
                item.Mod.Update(Client, ManagerFolder, ExtractFolder, ModsFolder);
                LoadMod(item.Mod);
            }

            UpdateStatusBar();
            Cursor = Cursors.Arrow;
        }

        private void btnChooseRelease_Click(object sender, RoutedEventArgs e) {
            ReleaseWindow win = new ReleaseWindow();
            Mod mod = ((ModListViewItem)listMods.SelectedItems[0]).Mod;

            if(win.ShowDialog(this, Client, mod) == true) {
                if(mod.Update(Client, ManagerFolder, ExtractFolder, ModsFolder, win.Release)) {
                    LoadMod(mod);
                }
                else {
                    MessageBox.Show("That release does not contain a supported format.", "Release Error");
                }
            }

            UpdateStatusBar();
        }

        private void btnEditModInfo_Click(object sender, RoutedEventArgs e) {
            EditWindow win = new EditWindow();
            Mod mod = ((ModListViewItem)listMods.SelectedItems[0]).Mod;

            // todo: show edit mod info window
        }

        private void btnPlayUnmodded_Click(object sender, RoutedEventArgs e) {
            Process.Start("steam://rungameid/365450");
        }

        private void btnPlayPathfinder_Click(object sender, RoutedEventArgs e) {
            Process.Start("HacknetPathfinder.exe");
        }

        private void listMods_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            LoadMod(((ModListViewItem)listMods.SelectedItem).Mod);
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            ModListViewItem item = (ModListViewItem)listMods.SelectedItem;
            item.IsChecked = !item.IsChecked;
            listMods.Items.Refresh();
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            if(e.ClickCount == 2) {
                ListViewItem_MouseDoubleClick(sender, e);
            }
        }

        private void UpdateStatusBar() {
            statusRequests.ContentStringFormat = string.Format(statusRequests.ContentStringFormat, RateUtils.GetRateLimit(Client).Remaining);
            statusReset.ContentStringFormat = string.Format(statusReset.ContentStringFormat, RateUtils.GetFormattedResetTime(Client, false));
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
            Cursor = Cursors.Wait;

            if(!string.IsNullOrWhiteSpace(mod.Title)) {
                lblTitleVersion.Content = mod.Title;

                if(!string.IsNullOrWhiteSpace(mod.Version)) {
                    lblTitleVersion.Content += " " + mod.Version;
                }
            }
            else lblTitleVersion.Content = mod.Name;

            btnVisitHomepage.IsEnabled = !string.IsNullOrWhiteSpace(mod.Homepage);
            btnUpdateMod.IsEnabled = btnChooseRelease.IsEnabled = !string.IsNullOrWhiteSpace(mod.Repository);
            lblDescription.Content = (string.IsNullOrWhiteSpace(mod.Description) ? "N/A" : mod.Description);
            lblAuthors.Content = (mod.Authors.Length == 0 ? "N/A" : string.Join(", ", mod.Authors));
            txtInfo.Text = (string.IsNullOrWhiteSpace(mod.Info) ? "No information." : mod.Info);

            Cursor = Cursors.Arrow;
        }

        private void LoadMods() {
            Cursor = Cursors.Wait;

            if(Mods.Count > 0) {
                Mods.Clear();
                listMods.Items.Clear();
            }

            var mods = FileUtils.GetFiles(ModsFolder, SearchOption.TopDirectoryOnly, "*.dll", "*.dll" + Mod.DISABLED_EXT);
            var jsons = Directory.GetFiles(ModsFolder, "*" + Mod.INFO_EXT, SearchOption.TopDirectoryOnly);

            foreach(string mod in mods) {
                string name = Regex.Match(mod.Remove(0, mod.LastIndexOf("\\") + 1), @"(.*)\.dll.*").Groups[1].Value;
                string json = jsons.FirstOrDefault(j => Regex.IsMatch(j, @".*\\" + name + @"\" + Mod.INFO_EXT));
                Mod add = new Mod(name);

                if(!string.IsNullOrWhiteSpace(json)) {
                    add.ReadInfo(json);
                }

                Mods.Add(name, add);

                ModListViewItem item = new ModListViewItem(add, !mod.EndsWith(".dll" + Mod.INFO_EXT));
                listMods.Items.Add(item);
            }

            if(listMods.Items.Count > 0) {
                listMods.SelectedItem = listMods.Items[0];
            }
            
            Cursor = Cursors.Arrow;
        }

        private void SetCheckedAll(bool check) {
            Cursor = Cursors.Wait;

            for(int i = 0; i < listMods.Items.Count; i++) {
                ModListViewItem item = (ModListViewItem)listMods.Items[i];

                if(item.IsChecked != check) {
                    item.IsChecked = check;
                }
            }

            listMods.Items.Refresh();

            Cursor = Cursors.Arrow;
        }

        private void RadioCheck(object sender, EventArgs e) {
            MenuItem sndr = (MenuItem)sender;
            MenuItem prnt = (MenuItem)sndr.Parent;

            foreach(MenuItem item in prnt.Items) {
                if(item == sender) {
                    item.IsChecked = true;
                }
                else {
                    item.IsChecked = false;
                }
            }
        }
    }
}
