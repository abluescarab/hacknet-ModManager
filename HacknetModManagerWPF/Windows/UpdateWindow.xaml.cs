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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window {
        public UpdateWindow() {
            InitializeComponent();
        }

        public bool? ShowDialog(Window owner, string currentVersion, string latestVersion) {
            Owner = owner;
            lblCurrentVersion.Content = currentVersion;
            lblLatestVersion.Content = latestVersion;
            return ShowDialog();
        }

        private void popupButtons_YesClicked(object sender, RoutedEventArgs e) {
            DialogResult = true;
            // todo: update
            Close();
        }

        private void popupButtons_NoClicked(object sender, RoutedEventArgs e) {
            DialogResult = false;
            Close();
        }
    }
}
