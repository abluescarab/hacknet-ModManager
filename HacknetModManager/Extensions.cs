using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace HacknetModManager {
    public static class Extensions {
        public static void ConstrainMaximumWidthToParent<T>(this T control, int rightMargin) where T : Control {
            control.MaximumSize = new Size(control.Parent.Width - rightMargin - control.Left, control.MaximumSize.Height);
            control.Width = control.MaximumSize.Width;
        }

        public static void ConstrainMaximumHeightToParent<T>(this T control, int bottomMargin) where T : Control {
            control.MaximumSize = new Size(control.MaximumSize.Width, control.Parent.Height - bottomMargin - control.Top);
            control.Height = control.MaximumSize.Height;
        }

        public static void Copy<T>(this T dest, T source) {
            PropertyInfo[] destProperties = dest.GetType().GetProperties();

            foreach(PropertyInfo destPi in destProperties) {
                PropertyInfo sourcePi = source.GetType().GetProperty(destPi.Name);

                if(destPi.CanWrite)
                    destPi.SetValue(dest, sourcePi.GetValue(source, null), null);
            }
        }
    }
}
