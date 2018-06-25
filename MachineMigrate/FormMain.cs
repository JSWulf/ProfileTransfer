using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MachineMigrate
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            OldHost = new Machine();
            NewHost = new Machine();

            

            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //set events
            FormClosing += FormMain_unLoad;

            SourceField = new MachineField("Source", OldHost, checkBoxSourceLocal, textBoxSourceHost, comboBoxSourceDrive,
                comboBoxSourceProfile, textBoxSourceLocalData, buttonSourceBrowse, buttonLocalSourceBrowse, pictureBoxSource, labelFullSource,
                checkBoxLocalData);

            TargetField = new MachineField("Target", NewHost, checkBoxTargetLocal, textBoxTargetHost, comboBoxTargetDrive,
                comboBoxTargetProfile, textBoxTargetLocalData, buttonTargetBrowse, buttonLocalTargetBrowse, pictureBoxTarget, labelFullTarget);

            SourceField.Profile.TextChanged += new EventHandler(delegate (Object o, EventArgs ea)
            {
                TargetField.Profile.Text = SourceField.Profile.Text;
            });

            SourceField.LocalData.TextChanged += LocalDataChange;
            TargetField.IsLocal.CheckedChanged += LocalDataChange;

            //set defaults

            var confFile = "MachineMigrate.conf";

            if (File.Exists(confFile))
            {
                foreach (var line in File.ReadAllLines(confFile))
                {
                    var sline = line.Split('=');

                    switch (sline[0])
                    {
                        case "Source":
                            //expecting local or hostname
                            OldHost.Hostname = sline[1];
                            break;
                        case "Target":
                            //expecting local or hostname
                            OldHost.Hostname = sline[1];
                            break;
                        case "User":
                            //expecting full drive path
                            OldHost.ProfileSource = GenericFunctions.NoHostPath(sline[1]);

                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                OldHost.IsLocal = true;
                OldHost.Hostname = "Localhost";
                OldHost.ProfileSource = Environment.GetEnvironmentVariable("USERPROFILE").Remove(0, 3);

                NewHost.IsLocal = true;
                NewHost.Hostname = "Localhost";
                foreach (var item in Environment.GetLogicalDrives())
                {
                    try
                    {
                        if (Directory.Exists(item + @"Users\" + Environment.UserName))
                        {
                            NewHost.DriveLetter = item[0].ToString();
                            NewHost.ProfileSource = @"Users\" + Environment.UserName;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                //NewHost.ProfileSource = Environment.GetEnvironmentVariable("USERPROFILE").Remove(0, 3);

                SourceField.SetUsers();
                TargetField.SetUsers();
            }

            textBoxSourceLocalData.Text = OldHost.DrivePath + "Localdata";
            textBoxTargetLocalData.Text = NewHost.DrivePath + "Localdata";
            checkBoxLocalData.Checked = true;

            PowerHelper.ForceSystemAwake();
        }

        private void LocalDataChange(object sender, EventArgs e)
        {
            TargetField.LocalData.Text = SourceField.LocalData.Text.Replace(OldHost.DrivePath, NewHost.DrivePath);
        }

        private void FormMain_unLoad(object sender, EventArgs e)
        {
            PowerHelper.ResetSystemDefault();
        }

        

        private string[] GetUsers(string userpath)
        {
            if (Directory.Exists(userpath))
            {
                return Directory.GetDirectories(userpath);
            }
            return null;
        }

        

        public static long TotalSize { get; set; }

        public static Machine OldHost { get; set; }
        public static Machine NewHost { get; set; }

        public static MachineField SourceField { get; set; }
        public static MachineField TargetField { get; set; }

        public string SourceHost { get; private set; }
        public string SourceDrive { get; private set; }
        public string SourceProfile { get; private set; }
        public string SourceLocaldata { get; private set; }
        public string SourceFull { get; private set; }
        public string SourceHostPath { get; private set; }

        public string TargetHost { get; private set; }
        public string TargetProfile { get; private set; }
        public string TargetLocaldata { get; private set; }
        public string TargetFull { get; private set; }

        private void checkBoxLocalData_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSourceLocalData.Enabled = checkBoxLocalData.Checked;
            textBoxTargetLocalData.Enabled = checkBoxLocalData.Checked;
        }
    }
}
