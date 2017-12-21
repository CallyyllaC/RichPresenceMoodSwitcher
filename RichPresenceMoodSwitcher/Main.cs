using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RichPresenceMoodSwitcher
{
    public partial class Main : Form
    {
        private static Discord.EventHandlers handlers;
        private Dictionary<Button, int> ButtonDict= new Dictionary<Button, int>();
        private string[] SettingsFile = null;
        public Main()
        {
            try
            {
                OpenSettings();
                InitializeComponent();
                AddButtons();
                UpdateButtonNames();
                toolTip1.UseAnimation = true;
            }
            catch (Exception e)
            {
                ErrorWin Newwin = new ErrorWin($"{e.Message}. You should tell Cali about this");
                Newwin.Show();
                LogError(e.Message);
                Newwin.FormClosed += Newwin_FormClosed;
            }
        }

        private void AddButtons()
        {
            try
            {
                ButtonDict.Add(BT_Depressed,11);
                ButtonDict.Add(BT_Unhappy,20);
                ButtonDict.Add(BT_Meh,29);
                ButtonDict.Add(BT_Happy,38);
                ButtonDict.Add(BT_Ecstatic,47);
                ButtonDict.Add(BT_Custom1,56);
                ButtonDict.Add(BT_Custom2,65);
                ButtonDict.Add(BT_Custom3,74);
                ButtonDict.Add(BT_Custom4,83);
                ButtonDict.Add(BT_Custom5,92);
                ButtonDict.Add(BT_Custom6,101);
                ButtonDict.Add(BT_Custom7,110);
                ButtonDict.Add(BT_Custom8,119);
                ButtonDict.Add(BT_Custom9,128);
                ButtonDict.Add(BT_Custom10,137);
            }
            catch (Exception e)
            {
                ErrorWin Newwin = new ErrorWin($"{e.Message}. You should tell Cali about this");
                Newwin.Show();
                LogError(e.Message);
                Newwin.FormClosed += Newwin_FormClosed;
            }
        }

        private void ResetButtonColors()
        {
            try
            {
                BT_Custom1.ForeColor = DefaultForeColor;
                BT_Custom2.ForeColor = DefaultForeColor;
                BT_Custom3.ForeColor = DefaultForeColor;
                BT_Custom4.ForeColor = DefaultForeColor;
                BT_Custom5.ForeColor = DefaultForeColor;
                BT_Custom6.ForeColor = DefaultForeColor;
                BT_Custom7.ForeColor = DefaultForeColor;
                BT_Custom8.ForeColor = DefaultForeColor;
                BT_Custom9.ForeColor = DefaultForeColor;
                BT_Custom10.ForeColor = DefaultForeColor;
                BT_Depressed.ForeColor = DefaultForeColor;
                BT_Unhappy.ForeColor = DefaultForeColor;
                BT_Meh.ForeColor = DefaultForeColor;
                BT_Happy.ForeColor = DefaultForeColor;
                BT_Ecstatic.ForeColor = DefaultForeColor;
            }
            catch (Exception e)
            {
                ErrorWin Newwin = new ErrorWin($"{e.Message}. You should tell Cali about this");
                Newwin.Show();
                LogError(e.Message);
            }
        }

        private void OpenSettings()
        {
            try
            {
                SettingsFile = File.ReadAllLines($"{Application.StartupPath}\\Settings.txt");
            }
            catch (Exception e)
            {
                ErrorWin Newwin = new ErrorWin($"{e.Message}. You should tell Cali about this");
                Newwin.Show();
                LogError(e.Message);
                Newwin.FormClosed += Newwin_FormClosed;
            }
        }

        private void Newwin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void Update(int id)
        {
            try
            {
                Discord.Shutdown();
            }
            catch
            {

            }

            try
            {

                Discord.RichPresence NewDisplay = new Discord.RichPresence();

                Discord.Initialize(SettingsFile[id + 1], handlers);
                NewDisplay.state = SettingsFile[id + 2];
                NewDisplay.details = SettingsFile[id + 3];
                //NewDisplay.startTimestamp = Convert.ToInt64(DateTime.Now);
                NewDisplay.largeImageKey = SettingsFile[id + 4];
                NewDisplay.largeImageText = SettingsFile[id + 5];
                NewDisplay.smallImageKey = SettingsFile[id + 6];
                NewDisplay.smallImageText = SettingsFile[id + 7];

                Discord.UpdatePresence(NewDisplay);
                ResetButtonColors();
            }
            catch (Exception e)
            {
                ErrorWin Newwin = new ErrorWin($"{e.Message}. You should tell Cali about this");
                Newwin.Show();
                LogError(e.Message);
            }
        }

        private void UpdateButtonNames()
        {
            try
            {

                BT_Custom1.Text = SettingsFile[GetValueFor(BT_Custom1)];
                toolTip1.SetToolTip(BT_Custom1, SettingsFile[GetValueFor(BT_Custom1)]);
                BT_Custom2.Text = SettingsFile[GetValueFor(BT_Custom2)];
                toolTip1.SetToolTip(BT_Custom2, SettingsFile[GetValueFor(BT_Custom2)]);
                BT_Custom3.Text = SettingsFile[GetValueFor(BT_Custom3)];
                toolTip1.SetToolTip(BT_Custom3, SettingsFile[GetValueFor(BT_Custom3)]);
                BT_Custom4.Text = SettingsFile[GetValueFor(BT_Custom4)];
                toolTip1.SetToolTip(BT_Custom4, SettingsFile[GetValueFor(BT_Custom4)]);
                BT_Custom5.Text = SettingsFile[GetValueFor(BT_Custom5)];
                toolTip1.SetToolTip(BT_Custom5, SettingsFile[GetValueFor(BT_Custom5)]);
                BT_Custom6.Text = SettingsFile[GetValueFor(BT_Custom6)];
                toolTip1.SetToolTip(BT_Custom6, SettingsFile[GetValueFor(BT_Custom6)]);
                BT_Custom7.Text = SettingsFile[GetValueFor(BT_Custom7)];
                toolTip1.SetToolTip(BT_Custom7, SettingsFile[GetValueFor(BT_Custom7)]);
                BT_Custom8.Text = SettingsFile[GetValueFor(BT_Custom8)];
                toolTip1.SetToolTip(BT_Custom8, SettingsFile[GetValueFor(BT_Custom8)]);
                BT_Custom9.Text = SettingsFile[GetValueFor(BT_Custom9)];
                toolTip1.SetToolTip(BT_Custom9, SettingsFile[GetValueFor(BT_Custom9)]);
                BT_Custom10.Text = SettingsFile[GetValueFor(BT_Custom10)];
                toolTip1.SetToolTip(BT_Custom10, SettingsFile[GetValueFor(BT_Custom10)]);
            }
            catch (Exception e)
            {
                ErrorWin Newwin = new ErrorWin($"{e.Message}. You should tell Cali about this");
                Newwin.Show();
                LogError(e.Message);
            }
        }

        private int GetValueFor(Button look)
        {
            int returnme = 0;
            for (int i = 0; i < ButtonDict.Count; i++)
            {
                if (ButtonDict.ElementAt(i).Key == look)
                {
                    returnme = ButtonDict.ElementAt(i).Value;
                }
            }
            return returnme;
        }

        //button presses
        private void BT_Depressed_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Depressed));
            BT_Depressed.ForeColor = Color.Green;
        }

        private void BT_Unhappy_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Unhappy));
            BT_Unhappy.ForeColor = Color.Green;
        }

        private void BT_Meh_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Meh));
            BT_Meh.ForeColor = Color.Green;
        }

        private void BT_Happy_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Happy));
            BT_Happy.ForeColor = Color.Green;
        }

        private void BT_Ecstatic_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Ecstatic));
            BT_Ecstatic.ForeColor = Color.Green;
        }

        private void BT_Custom1_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Custom1));
            BT_Custom1.ForeColor = Color.Green;
        }

        private void BT_Custom2_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Custom2));
            BT_Custom2.ForeColor = Color.Green;
        }

        private void BT_Custom3_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Custom3));
            BT_Custom3.ForeColor = Color.Green;
        }

        private void BT_Custom4_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Custom4));
            BT_Custom4.ForeColor = Color.Green;
        }

        private void BT_Custom5_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Custom5));
            BT_Custom5.ForeColor = Color.Green;
        }

        private void BT_Custom6_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Custom6));
            BT_Custom6.ForeColor = Color.Green;
        }

        private void BT_Custom7_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Custom7));
            BT_Custom7.ForeColor = Color.Green;
        }

        private void BT_Custom8_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Custom8));
            BT_Custom8.ForeColor = Color.Green;
        }

        private void BT_Custom9_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Custom9));
            BT_Custom9.ForeColor = Color.Green;
        }

        private void BT_Custom10_Click(object sender, EventArgs e)
        {
            Update(GetValueFor(BT_Custom10));
            BT_Custom10.ForeColor = Color.Green;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Discord.Shutdown();
            }
            catch
            {

            }
        }
    }
}
