using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HacknetModManager {
    public partial class frmInstall : Form {
        public frmInstall() {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            if(!string.IsNullOrWhiteSpace(txtMod.Text)) {
                if(new Uri(txtMod.Text).IsFile) {
                    if(File.Exists(txtMod.Text)) {
                        Mod mod = new Mod();
                        mod.Unzip(frmMain.ModsFolder, frmMain.ExtractFolder, txtMod.Text);

                        MessageBox.Show("Added " + mod.Name + " to mods.", "Added Mod");
                        frmMain.Mods.Add(mod.Name, mod);
                    }
                    else {
                        MessageBox.Show("That file does not exist.", "Mod Error");
                    }
                }
                else {
                    Mod mod = new Mod() {
                        Repository = txtMod.Text
                    };

                    // todo: show releases
                }

                txtMod.Text = string.Empty;
            }
            else {
                MessageBox.Show("No mod added.", "Mod Error");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            if(dlgOpenFile.ShowDialog() == DialogResult.OK) {
                txtMod.Text = dlgOpenFile.FileName;
            }
        }
    }
}
