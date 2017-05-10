using System.Drawing;
using System.Windows.Forms;

namespace HacknetModManager.Controls {
    public class DarkTheme : ProfessionalColorTable {
        public static readonly Color DarkDarkBackColor = Color.FromArgb(34, 34, 34);
        public static readonly Color DarkBackColor = Color.FromArgb(50, 50, 50);
        public static readonly Color LightLightBackColor = Color.FromArgb(74, 74, 74);
        public static readonly Color LightBackColor = Color.FromArgb(60, 60, 60);
        public static readonly Color TextColor = Color.White;
        public static readonly Color Transparent = Color.FromArgb(0, 255, 255, 255);

        // MenuStripGradient
        public override Color MenuStripGradientBegin {
            get { return DarkDarkBackColor; }
        }

        public override Color MenuStripGradientEnd {
            get { return DarkDarkBackColor; }
        }

        // MenuItemSelected
        public override Color MenuItemSelected {
            get { return LightBackColor; }
        }

        // MenuItemSelectedGradient
        public override Color MenuItemSelectedGradientBegin {
            get { return LightBackColor; }
        }
        
        public override Color MenuItemSelectedGradientEnd {
            get { return LightBackColor; }
        }

        // MenuItemPressGradient
        public override Color MenuItemPressedGradientBegin {
            get { return LightLightBackColor; }
        }

        public override Color MenuItemPressedGradientMiddle {
            get { return LightLightBackColor; }
        }

        public override Color MenuItemPressedGradientEnd {
            get { return LightLightBackColor; }
        }

        // MenuBorder
        public override Color MenuBorder {
            get { return Color.Transparent; }
        }

        // MenuItemBorder
        public override Color MenuItemBorder {
            get { return Color.Transparent; }
        }
        
        // ToolStripDropDown
        public override Color ToolStripDropDownBackground {
            get { return DarkDarkBackColor; }
        }

        // ImageMarginGradient
        public override Color ImageMarginGradientBegin {
            get { return LightLightBackColor; }
        }

        public override Color ImageMarginGradientEnd {
            get { return LightLightBackColor; }
        }

        public override Color ImageMarginGradientMiddle {
            get { return LightLightBackColor; }
        }
    }
}
