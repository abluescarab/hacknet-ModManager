using System.Drawing;
using System.Windows.Forms;

namespace HacknetModManager.Controls {
    public class DarkButton : Button {
        public DarkButton() {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.BorderColor = DarkTheme.Transparent;
            FlatAppearance.MouseDownBackColor = DarkTheme.DarkDarkBackColor;
            FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            BackColor = DarkTheme.DarkBackColor;
            ForeColor = DarkTheme.TextColor;
        }
    }
}
