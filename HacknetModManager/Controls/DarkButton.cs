using System.Drawing;
using System.Windows.Forms;

namespace HacknetModManager.Controls {
    public class DarkButton : Button {
        public DarkButton() {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            FlatAppearance.MouseDownBackColor = Color.FromArgb(74, 74, 74);
            FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            BackColor = Color.FromArgb(50, 50, 50);
            ForeColor = Color.White;
        }
    }
}
