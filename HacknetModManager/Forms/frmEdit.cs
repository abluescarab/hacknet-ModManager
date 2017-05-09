using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HacknetModManager {
    public partial class frmEdit : Form {
        private Mod mod;
        private const string noAuthors = "No authors.";

        public frmEdit() {
            InitializeComponent();
        }

        public DialogResult ShowDialog(Mod mod) {
            this.mod = mod;

            txtTitle.Text = mod.Title;
            txtDescription.Text = mod.Description;
            txtVersion.Text = mod.Version;
            txtHomepage.Text = mod.Homepage;
            txtRepository.Text = mod.Repository;
            txtInfo.Text = mod.Info;

            foreach(string author in mod.Authors) {
                lbxAuthors.Items.Add(author);
            }

            if(lbxAuthors.Items.Count > 0)
                lbxAuthors.SelectedIndex = 0;
            else {
                lbxAuthors.Enabled = false;
                lbxAuthors.Items.Add(noAuthors);
            }

            return ShowDialog();
        }

        private void btnMoveUp_Click(object sender, EventArgs e) {

        }

        private void btnMoveDown_Click(object sender, EventArgs e) {

        }

        private void btnAdd_Click(object sender, EventArgs e) {
            frmInput input = new frmInput();
            if(input.ShowDialog("Add Author", "Enter an author's name:") == DialogResult.OK) {
                if(lbxAuthors.Items.Contains(noAuthors)) {
                    lbxAuthors.Items.Clear();
                }

                lbxAuthors.Items.Add(input.Answer);
                lbxAuthors.Enabled = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            for(int i = lbxAuthors.Items.Count - 1; i >= 0; i--) {
                if(lbxAuthors.SelectedItems.Contains(lbxAuthors.Items[i])) {
                    lbxAuthors.Items.RemoveAt(i);
                }
            }

            if(lbxAuthors.Items.Count == 0) {
                lbxAuthors.Enabled = false;
                lbxAuthors.Items.Add(noAuthors);
            }
        }

        private void btnOK_Click(object sender, EventArgs e) {
            mod.Title = txtTitle.Text;
            mod.Description = txtDescription.Text;
            mod.Version = txtVersion.Text;
            mod.Homepage = txtHomepage.Text;
            mod.Repository = txtRepository.Text;
            mod.Authors = lbxAuthors.Items.Cast<string>().ToArray();
            mod.Info = txtInfo.Text;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
