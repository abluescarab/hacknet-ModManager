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

            lbxAuthors.SelectedIndex = 0;

            return ShowDialog();
        }

        private void btnMoveUp_Click(object sender, EventArgs e) {

        }

        private void btnMoveDown_Click(object sender, EventArgs e) {

        }

        private void btnAdd_Click(object sender, EventArgs e) {

        }

        private void btnRemove_Click(object sender, EventArgs e) {

        }

        private void btnOK_Click(object sender, EventArgs e) {

        }

        private void btnCancel_Click(object sender, EventArgs e) {

        }
    }
}
