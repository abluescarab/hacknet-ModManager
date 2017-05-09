using System;
using System.Data;
using System.Linq;
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
            
            CheckAuthors();

            return ShowDialog();
        }

        private void btnMoveUp_Click(object sender, EventArgs e) {
            lbxAuthors.MoveUp();
        }

        private void btnMoveDown_Click(object sender, EventArgs e) {
            lbxAuthors.MoveDown();
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            frmInput input = new frmInput();
            if(input.ShowDialog("Add Author", "Enter an author's name:") == DialogResult.OK) {
                if(!string.IsNullOrWhiteSpace(input.Answer) && !lbxAuthors.Items.Contains(input.Answer)) {
                    if(lbxAuthors.Items.Contains(noAuthors)) {
                        lbxAuthors.Items.Clear();
                    }

                    lbxAuthors.Items.Add(input.Answer);
                    CheckAuthors();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            for(int i = lbxAuthors.Items.Count - 1; i >= 0; i--) {
                if(lbxAuthors.SelectedItems.Contains(lbxAuthors.Items[i])) {
                    lbxAuthors.Items.RemoveAt(i);
                }
            }

            CheckAuthors();
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

        private void CheckAuthors() {
            lbxAuthors.Enabled = btnMoveDown.Enabled = btnMoveUp.Enabled = btnRemove.Enabled = lbxAuthors.Items.Count > 0;

            if(lbxAuthors.Items.Count == 0) {
                lbxAuthors.Items.Add(noAuthors);
            }
            else {
                lbxAuthors.SelectedIndex = 0;
            }
        }
    }
}
