using System.Collections.Generic;
using System.ComponentModel;

namespace HacknetModManager {
    public class ModListViewItem : INotifyPropertyChanged {
        private bool isChecked;
        private Mod mod;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsChecked {
            get { return isChecked; }
            set {
                if(isChecked != value) {
                    isChecked = value;
                    OnPropertyChanged("IsChecked");
                }
            }
        }

        public Mod Mod {
            get { return mod; }
            set {
                if(mod != value) {
                    mod = value;
                    OnPropertyChanged("Mod");
                }
            }
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e) {
            PropertyChanged?.Invoke(this, e);
        }

        protected void OnPropertyChanged(string propertyName) {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        public ModListViewItem(Mod mod, bool isChecked) {
            this.mod = mod;
            this.isChecked = isChecked;
        }
    }
}
