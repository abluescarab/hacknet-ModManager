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
    /// Interaction logic for InputWindow.xaml
    /// </summary>
    public partial class InputWindow : Window {
        public string Answer { get; private set; }

        public InputWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            txtInput.Focus();
        }

        public bool? ShowDialog(Window owner, string title, string prompt) {
            Owner = owner;
            Title = title;
            lblPrompt.Content = prompt;
            return ShowDialog();
        }

        private void popupButtons_OKClicked(object sender, RoutedEventArgs e) {
            Answer = txtInput.Text;
            DialogResult = true;
            Close();
        }

        private void popupButtons_CancelClicked(object sender, RoutedEventArgs e) {
            Answer = "";
            DialogResult = false;
            Close();
        }
    }
}
