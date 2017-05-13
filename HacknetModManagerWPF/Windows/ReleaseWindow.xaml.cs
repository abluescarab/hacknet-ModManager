using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Octokit;

namespace HacknetModManager {
    /// <summary>
    /// Interaction logic for ReleaseWindow.xaml
    /// </summary>
    public partial class ReleaseWindow : Window {
        public Release Release { get; private set; }
        
        private Mod mod;
        private GitHubClient client;
        private string repo;
        private string user;

        public ReleaseWindow() {
            InitializeComponent();
            lbxReleases.Items.Clear();
        }
        
        public bool? ShowDialog(Window owner, GitHubClient client, Mod mod) {
            this.Owner = owner;
            this.client = client;
            this.mod = mod;
            Match match;

            if(Mod.IsValid(client, mod.Repository, out match)) {
                user = match.Groups[1].Value;
                repo = match.Groups[2].Value;
                IReadOnlyList<Release> releases = null;

                try {
                    releases = client.Repository.Release.GetAll(user, repo).Result;
                }
                catch(Exception e) {
                    if(e is AggregateException || e is RateLimitExceededException) {
                        RateUtils.ShowRateErrorMessage(client, false);
                        DialogResult = false;
                    }
                }

                if(releases != null && releases.Count > 0) {
                    lbxReleases.ItemsSource = releases;
                    lbxReleases.DisplayMemberPath = "Name";
                }
                else {
                    lbxReleases.IsEnabled = false;
                    lbxReleases.Items.Add("There are no releases.");
                    popupButtons.OKButton.IsEnabled = false;
                }
            }

            return ShowDialog();
        }

        private void popupButtons_OKClicked(object sender, RoutedEventArgs e) {
            if(lbxReleases.SelectedItems.Count > 0) {
                DialogResult = true;
                Release = (Release)lbxReleases.SelectedItem;
            }
            else {
                DialogResult = false;
                Release = null;
            }

            Close();
        }

        private void popupButtons_CancelClicked(object sender, RoutedEventArgs e) {
            DialogResult = false;
            Close();
        }
    }
}
