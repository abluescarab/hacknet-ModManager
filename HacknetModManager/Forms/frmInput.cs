using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HacknetModManager {
    public partial class frmInput : Form {
        public string Answer { get; private set; }

        public frmInput() {
            InitializeComponent();
        }

        public DialogResult ShowDialog(string title, string text) {
            Text = title;
            lblInput.Text = text;
            return ShowDialog();
        }

        private void btnOK_Click(object sender, EventArgs e) {
            Answer = txtInput.Text;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Answer = "";
            Close();
        }
    }
}
