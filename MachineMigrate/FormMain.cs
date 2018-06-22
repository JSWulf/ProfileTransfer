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
            FormClosing += FormMain_unLoad;
            
            //buttonSourceBrowse.Click += Browse;
            //buttonTargetBrowse.Click += Browse;

            SetMachineEvents(OldHost, checkBoxSourceLocal, textBoxSourceHost,
                comboBoxSourceDrive, comboBoxSourceProfile, textBoxSourceLocalData);

            SetMachineEvents(NewHost, checkBoxTargetLocal, textBoxTargetHost,
                comboBoxTargetDrive, comboBoxTargetProfile, textBoxTargetLocalData);

            //OldHost.ConnectivityChanged += UpdatePicture;

            PowerHelper.ForceSystemAwake();
        }

        
        private void FormMain_unLoad(object sender, EventArgs e)
        {
            PowerHelper.ResetSystemDefault();
        }

        //public static string HostName { get; set; }

        //public static string UserName { get; set; }
        private void SetMachineEvents(Machine machine, CheckBox chklocal, TextBox txtHost, 
            ComboBox cbDrive, ComboBox cbProfile, TextBox txtLocalData)
        {
            txtHost.LostFocus += machine.CheckHost;
            machine.ConnectivityChanged += UpdatePicture;
            machine.PathChanged += UpdatePath;

            chklocal.CheckedChanged += new EventHandler(delegate (Object o, EventArgs ea)
            {
                machine.IsLocal = chklocal.Checked;
            });

            txtHost.TextChanged += new EventHandler(delegate (Object o, EventArgs ea)
            {
                machine.Hostname = txtHost.Text;
            });

            cbDrive.TextChanged += new EventHandler(delegate (Object o, EventArgs ea)
            {
                machine.DriveLetter = cbDrive.Text;
            });

            cbProfile.TextChanged += new EventHandler(delegate (Object o, EventArgs ea)
            {
                machine.ProfileSource = cbProfile.Text;
                machine.UserName = cbProfile.Text;
            });

            txtLocalData.TextChanged += new EventHandler(delegate (Object o, EventArgs ea)
            {
                machine.LocalData = txtLocalData.Text;
            });

        }

        private void UpdatePath(object sender, EventArgs e)
        {
            var senderObj = (Machine)sender;
            Label selectedLabel = null;

            if (senderObj == OldHost)
            {
                selectedLabel = labelFullSource;
            }
            else if (senderObj == NewHost)
            {
                selectedLabel = labelFullTarget;
            }

            selectedLabel.Text = senderObj.FullPath;
        }

        private void UpdatePicture(object sender, EventArgs e)
        {
            var senderObj = (Machine)sender;
            //var senderName = senderobj.Hostname;
            PictureBox selectedPicBox = null;

            if (senderObj == OldHost)
            {
                //update source connectivity picture
                selectedPicBox = pictureBoxSource;
            }
            else if (senderObj == NewHost)
            {
                //update target connectivity picture
                selectedPicBox = pictureBoxTarget;
            }

            switch (senderObj.ConnectionState)
            {
                case 0:
                    selectedPicBox.Image = Properties.Resources.Minus_Grey;
                    break;
                case 50:
                    selectedPicBox.Image = Properties.Resources.Error_red;
                    break;
                case 100:
                    selectedPicBox.Image = Properties.Resources.Tick_Green;
                    break;
                default:
                    break;
            }

        }



        private void Browse(object sender, EventArgs e)
        {
            var sendObj = (Button)sender;
            var sendObjName = sendObj.Name;

            ComboBox txtUdt = null;
            string fullSelectedPath = "";
            string result = "";

            if (sendObjName.Contains("Source"))
            {
                txtUdt = comboBoxSourceProfile;
                fullSelectedPath = labelFullSource.Text;
            }
            else if (sendObjName.Contains("Target"))
            {
                txtUdt = comboBoxTargetProfile;
                fullSelectedPath = labelFullTarget.Text;
            }

            result = GetBrowserFolder(fullSelectedPath);

            if (!string.IsNullOrEmpty(result))
            {
                txtUdt.Text = result;
            }
            
            //throw new NotImplementedException();
        }

        private string GetBrowserFolder(string startFolder)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                SelectedPath = startFolder
            };
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }

            return startFolder;
        }

        public static long TotalSize { get; set; }

        public static Machine OldHost { get; set; }
        public static Machine NewHost { get; set; }

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
    }
}
