using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HacknetModManager.Controls {
    public class DarkMenuStripRenderer : ToolStripProfessionalRenderer {
        public DarkMenuStripRenderer() : base(new DarkTheme()) { }
    }
}
