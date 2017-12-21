using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RichPresenceMoodSwitcher
{
    public partial class ErrorWin : Form
    {
        string msg;
        public ErrorWin(string ErrorMsg)
        {
            InitializeComponent();
            msg = ErrorMsg;
        }

        private void ErrorWin_Load(object sender, EventArgs e)
        {
            label1.Text = msg;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
