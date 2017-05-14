using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HacknetModManager {
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window {
        private Mod mod;
        private const string noAuthors = "No authors.";

        public EditWindow() {
            InitializeComponent();
        }

        public bool? ShowDialog(Window owner, Mod mod) {
            this.Owner = owner;
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

        private void popupButtons_OkayClicked(object sender, RoutedEventArgs e) {
            mod.Title = txtTitle.Text;
            mod.Description = txtDescription.Text;
            mod.Version = txtVersion.Text;
            mod.Homepage = txtHomepage.Text;
            mod.Repository = txtRepository.Text;
            mod.Authors = (lbxAuthors.IsEnabled ? lbxAuthors.Items.Cast<string>().ToArray() : new string[] { });
            mod.Info = txtInfo.Text;

            DialogResult = true;
            Close();
        }

        private void popupButtons_CancelClicked(object sender, RoutedEventArgs e) {
            DialogResult = false;
            Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e) {
            InputWindow win = new InputWindow();

            if(win.ShowDialog(this, "Add Author", "Enter an author's name:") == true) {
                if(!string.IsNullOrWhiteSpace(win.Answer) && !lbxAuthors.Items.Contains(win.Answer)) {
                    if(lbxAuthors.Items.Contains(noAuthors)) {
                        lbxAuthors.Items.Clear();
                    }

                    lbxAuthors.Items.Add(win.Answer);
                    CheckAuthors();
                }
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e) {
            for(int i = lbxAuthors.Items.Count - 1; i >= 0; i--) {
                if(lbxAuthors.SelectedItems.Contains(lbxAuthors.Items[i])) {
                    lbxAuthors.Items.RemoveAt(i);
                }
            }

            CheckAuthors();
        }

        private void btnMoveUp_Click(object sender, RoutedEventArgs e) {
            lbxAuthors.MoveUp();
        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e) {
            lbxAuthors.MoveDown();
        }

        private void CheckAuthors() {
            lbxAuthors.IsEnabled = btnRemove.IsEnabled = lbxAuthors.Items.Count > 0;
            btnMoveDown.IsEnabled = btnMoveUp.IsEnabled = lbxAuthors.Items.Count > 1;

            if(lbxAuthors.Items.Count == 0) {
                lbxAuthors.Items.Add(noAuthors);
            }
            else {
                lbxAuthors.SelectedIndex = 0;
            }
        }
    }
}
