using System.Windows;
using System.Windows.Controls;

namespace HacknetModManager {
    /// <summary>
    /// Interaction logic for PopupButtons.xaml
    /// </summary>
    public partial class PopupButtons : UserControl {
        public event RoutedEventHandler OkayClicked;
        public event RoutedEventHandler CancelClicked;

        public string OkayText {
            get { return OkayButton.Content.ToString(); }
            set { OkayButton.Content = value; }
        }

        public string CancelText {
            get { return CancelButton.Content.ToString(); }
            set { CancelButton.Content = value; }
        }

        public bool OkayEnabled {
            get { return OkayButton.IsEnabled; }
            set { OkayButton.IsEnabled = value; }
        }

        public bool CancelEnabled {
            get { return CancelButton.IsEnabled; }
            set { CancelButton.IsEnabled = value; }
        }

        public PopupButtons() {
            InitializeComponent();
        }

        private void OkayButton_Clicked(object sender, RoutedEventArgs e) {
            OnOkayClicked(e);
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e) {
            OnCancelClicked(e);
        }

        protected void OnOkayClicked(RoutedEventArgs e) {
            OkayClicked?.Invoke(this, e);
        }

        protected void OnCancelClicked(RoutedEventArgs e) {
            CancelClicked?.Invoke(this, e);
        }
    }
}
