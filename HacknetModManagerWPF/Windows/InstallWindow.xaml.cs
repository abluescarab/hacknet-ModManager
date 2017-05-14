using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace HacknetModManager {
    /// <summary>
    /// Interaction logic for InstallWindow.xaml
    /// </summary>
    public partial class InstallWindow : Window {
        public Mod Mod { get; private set; }
        public string Error { get; private set; }

        public InstallWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            popupButtons.OKButton.IsEnabled = false;
        }

        private void txtMod_TextChanged(object sender, TextChangedEventArgs e) {
            popupButtons.OKButton.IsEnabled = txtMod.Text.Length > 0;
        }

        private void popupButtons_OKClicked(object sender, RoutedEventArgs e) {
            bool added = false;
            Mod = default(Mod);

            if(new Uri(txtMod.Text).IsFile) {
                if(File.Exists(txtMod.Text)) {
                    Mod = new Mod();
                    if(!Mod.Unzip(txtMod.Text, MainWindow.ExtractFolder, MainWindow.ModsFolder)) {
                        Error = "That file does not contain a valid mod.";
                    }
                    else {
                        added = true;
                    }
                }
                else {
                    Error = "That file does not exist.";
                }
            }
            else {
                Mod = new Mod("", txtMod.Text);

                ReleaseWindow win = new ReleaseWindow();
                if(win.ShowDialog(this, MainWindow.Client, Mod) == true) {
                    if(!Mod.Update(MainWindow.Client, MainWindow.ManagerFolder, MainWindow.ExtractFolder, MainWindow.ModsFolder,
                        win.Release)) {
                        Error = "That repository or release does not contain a valid mod.";
                    }
                    else {
                        added = true;
                    }
                }
            }

            DialogResult = added;
            Close();
        }

        private void popupButtons_CancelClicked(object sender, RoutedEventArgs e) {
            DialogResult = false;
            Close();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.AddExtension = true;
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;
            dlg.DefaultExt = "zip";
            dlg.Filter = "Zip files|*.zip";
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.Multiselect = false;
            dlg.RestoreDirectory = true;
            dlg.Title = "Choose a mod...";
            dlg.ValidateNames = true;

            if(dlg.ShowDialog(this) == true) {
                txtMod.Text = dlg.FileName;
            }
        }
    }
}
