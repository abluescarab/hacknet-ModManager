using System.Drawing;
using System.Windows.Forms;

namespace HacknetModManager.Controls {
    public class DarkButton : Button {
        public DarkButton() {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.BorderColor = DarkTheme.Transparent;
            FlatAppearance.MouseDownBackColor = DarkTheme.LightLightBackColor;
            FlatAppearance.MouseOverBackColor = DarkTheme.LightBackColor;
            BackColor = DarkTheme.DarkBackColor;
            ForeColor = DarkTheme.TextColor;
        }
    }
}
