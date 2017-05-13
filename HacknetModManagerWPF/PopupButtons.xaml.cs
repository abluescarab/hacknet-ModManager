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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HacknetModManager {
    /// <summary>
    /// Interaction logic for PopupButtons.xaml
    /// </summary>
    public partial class PopupButtons : UserControl {
        public event RoutedEventHandler OKClicked;
        public event RoutedEventHandler CancelClicked;

        public PopupButtons() {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e) {
            OnOKClicked(e);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            OnCancelClicked(e);
        }

        protected void OnOKClicked(RoutedEventArgs e) {
            OKClicked?.Invoke(this, e);
        }

        protected void OnCancelClicked(RoutedEventArgs e) {
            CancelClicked?.Invoke(this, e);
        }
    }
}
