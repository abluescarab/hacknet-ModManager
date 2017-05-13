using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace HacknetModManager {
    public static class Extensions {
        public static void Copy<T>(this T dest, T source) {
            PropertyInfo[] destProperties = dest.GetType().GetProperties();

            foreach(PropertyInfo destPi in destProperties) {
                PropertyInfo sourcePi = source.GetType().GetProperty(destPi.Name);

                if(destPi.CanWrite)
                    destPi.SetValue(dest, sourcePi.GetValue(source, null), null);
            }
        }

        public static void Repeat<T>(this T[] array, T value) {
            for(int i = 0; i < array.Length; i++) {
                array[i] = value;
            }
        }

        public static bool? ShowDialog(this Window window, Window owner) {
            window.Owner = owner;
            return window.ShowDialog();
        }

        public static void MoveUp(this ListBox listBox) {
            string[] final = new string[listBox.SelectedItems.Count];
            int n = 0;

            for(int i = 1; i < listBox.Items.Count; i++) {
                string item = (string)listBox.Items[i];

                if(listBox.SelectedItems.Contains(item) && ShouldMoveItems(listBox, i, true)) {
                    listBox.Items.RemoveAt(i);
                    listBox.Items.Insert(i - 1, item);
                    final[n++] = item;
                }
            }

            foreach(string item in final) {
                if(!string.IsNullOrEmpty(item)) {
                    listBox.SelectedItems.Add(item);
                }
            }
        }

        public static void MoveDown(this ListBox listBox) {
            string[] final = new string[listBox.SelectedItems.Count];
            int n = 0;

            for(int i = listBox.Items.Count - 1; i >= 0; i--) {
                string item = (string)listBox.Items[i];

                if(listBox.SelectedItems.Contains(item) && ShouldMoveItems(listBox, i, false)) {
                    listBox.Items.RemoveAt(i);
                    listBox.Items.Insert(i + 1, item);
                    final[n++] = item;
                }
            }

            foreach(string item in final) {
                if(!string.IsNullOrEmpty(item)) {
                    listBox.SelectedItems.Add(item);
                }
            }
        }
        
        private static bool ShouldMoveItems(ListBox listBox, int index, bool moveUp) {
            int nextIndex = (moveUp ? index - 1 : index + 1);
            int lastIndex = (moveUp ? 0 : listBox.Items.Count - 1);

            if((moveUp && nextIndex < lastIndex) || (!moveUp && nextIndex > lastIndex))
                return false;

            if(listBox.SelectedItems.Contains(listBox.Items[nextIndex])) {
                return ShouldMoveItems(listBox, nextIndex, moveUp);
            }
            else {
                return true;
            }
        }
    }
}
