using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RichPresenceMoodSwitcher
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            try
            {
                var SettingsFile = File.Open($"{Application.StartupPath}\\Settings.txt", FileMode.Open);
            }
            catch(Exception e)
            {
                ErrorWin Newwin = new ErrorWin($"{e.Message}. You should tell Cali about this");
                Newwin.Show();
                LogError(e.Message);
            }

        }

        private void LogError(string error)
        {
            try
            {
                if (!File.Exists($"{Application.StartupPath}\\Log.txt"))
                {
                    var tmp = File.Create($"{Application.StartupPath}\\Log.txt");
                    tmp.Dispose();
                }
                using (StreamWriter sw = new StreamWriter($"{Application.StartupPath}\\Log.txt", true))
                {
                    sw.WriteLine($"{DateTime.Now.Hour}:{DateTime.Now.Minute}\n{error}");
                }
            }
            catch
            {
                ErrorWin Newwin = new ErrorWin("Unable to log the error, you should REALLY tell Cali about this!");
                Newwin.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
