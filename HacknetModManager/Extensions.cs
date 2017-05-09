using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

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
    }
}
