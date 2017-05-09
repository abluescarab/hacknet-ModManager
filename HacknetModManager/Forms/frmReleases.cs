using System.Text.RegularExpressions;
using System.Windows.Forms;
using Octokit;

namespace HacknetModManager {
    public partial class frmReleases : Form {
        public Release Release { get; private set; }

        private Mod mod;
        private GitHubClient client;
        private string repo;
        private string user;

        public frmReleases() {
            InitializeComponent();
        }

        public DialogResult ShowDialog(GitHubClient client, Mod mod) {
            this.client = client;
            this.mod = mod;
            lblChooseRelease.Text = string.Format(lblChooseRelease.Text, mod.Title);
            Match match;

            if(Mod.IsValid(client, mod.Repository, out match)) {
                user = match.Groups[1].Value;
                repo = match.Groups[2].Value;

                var releases = client.Repository.Release.GetAll(user, repo).Result;

                lbxReleases.DataSource = releases;
                lbxReleases.DisplayMember = "Name";
            }

            return ShowDialog();
        }

        private void btnOK_Click(object sender, System.EventArgs e) {
            if(lbxReleases.SelectedItems.Count > 0) {
                DialogResult = DialogResult.OK;
                Release = (Release)lbxReleases.SelectedItem;
            }
            else {
                DialogResult = DialogResult.Cancel;
                Release = null;
            }

            Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
