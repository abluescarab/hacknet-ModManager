using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
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

        //public static void MoveUp(this ListBox listBox) {
        //    int[] final = new int[listBox.SelectedItems.Count];
        //    int n = 0;

        //    final.Repeat(-1);

        //    for(int i = 1; i < listBox.Items.Count; i++) {
        //        var item = listBox.Items[i];

        //        if(listBox.SelectedItems.Contains(item) && ShouldMoveItems(listBox, i, true)) {
        //            listBox.Items.RemoveAt(i);
        //            listBox.Items.Insert(i - 1, item);
        //            final[n++] = i - 1;
        //        }
        //    }

        //    foreach(int index in final) {
        //        if(index > -1) {
        //            listBox.SelectedIndices.Add(index);
        //        }
        //    }
        //}

        //public static void MoveDown(this ListBox listBox) {
        //    int[] final = new int[listBox.SelectedItems.Count];
        //    int n = 0;

        //    final.Repeat(-1);

        //    for(int i = listBox.Items.Count - 1; i >= 0; i--) {
        //        var item = listBox.Items[i];

        //        if(listBox.SelectedItems.Contains(item) && ShouldMoveItems(listBox, i, false)) {
        //            listBox.Items.RemoveAt(i);
        //            listBox.Items.Insert(i + 1, item);
        //            final[n++] = i + 1;
        //        }
        //    }

        //    foreach(int index in final) {
        //        if(index > -1) {
        //            listBox.SelectedIndices.Add(index);
        //        }
        //    }
        //}

        //private static bool ShouldMoveItems(ListBox listBox, int index, bool moveUp) {
        //    int nextIndex = (moveUp ? index - 1 : index + 1);
        //    int lastIndex = (moveUp ? 0 : listBox.Items.Count - 1);

        //    if((moveUp && nextIndex < lastIndex) || (!moveUp && nextIndex > lastIndex))
        //        return false;

        //    if(listBox.SelectedIndices.Contains(nextIndex)) {
        //        return ShouldMoveItems(listBox, nextIndex, moveUp);
        //    }
        //    else {
        //        return true;
        //    }
        //}
    }
}
