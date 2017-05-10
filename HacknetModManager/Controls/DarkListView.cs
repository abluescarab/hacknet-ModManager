using System.Drawing;
using System.Windows.Forms;

namespace HacknetModManager.Controls {
    public class DarkListView : ListView {
        public DarkListView() {
            BackColor = DarkTheme.LightLightBackColor;
            ForeColor = DarkTheme.TextColor;
            OwnerDraw = true;
            DrawItem += DarkListView_DrawItem;
        }

        private void DarkListView_DrawItem(object sender, DrawListViewItemEventArgs e) {
            SizeF size = e.Graphics.MeasureString(e.Item.Text, Font);
            Brush foreColor = new SolidBrush(ForeColor);
            Brush backColor = Brushes.Transparent;
            int checkBoxSize = 15;
            int textX = 0;

            if(CheckBoxes) {
                ButtonState state;

                if(e.Item.Checked)
                    state = ButtonState.Flat | ButtonState.Checked;
                else
                    state = ButtonState.Flat;

                ControlPaint.DrawCheckBox(e.Graphics, 0, e.Bounds.Top, checkBoxSize, checkBoxSize, state);
                textX = checkBoxSize;
            }

            if(e.Item.Selected) {
                backColor = new SolidBrush(DarkTheme.DarkDarkBackColor);
            }

            e.Graphics.FillRectangle(backColor, new RectangleF(e.Bounds.X + textX, e.Bounds.Y, size.Width, size.Height));
            e.Graphics.DrawString(e.Item.Text, Font, foreColor, e.Bounds.X + textX, e.Bounds.Top + 1);
        }
    }
}
