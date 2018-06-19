using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineMigrate
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormClosing += FormMain_unLoad;
            checkBoxSourceLocal.CheckedChanged += UpdateSource;
            checkBoxTargetLocal.CheckedChanged += UpdateTarget;
            textBoxSourceHost.TextChanged += UpdateSource;
            textBoxSourceHost.LostFocus += new EventHandler(CheckHost);
            textBoxTargetHost.TextChanged += UpdateTarget;
            comboBoxSourceDrive.TextChanged += UpdateSource;
            comboBoxTargetDrive.TextChanged += UpdateTarget;
            comboBoxSourceProfile.TextChanged += UpdateSource;
            comboBoxTargetProfile.TextChanged += UpdateTarget;

            buttonSourceBrowse.Click += Browse;
            buttonTargetBrowse.Click += Browse;

            PowerHelper.ForceSystemAwake();
        }

        private void FormMain_unLoad(object sender, EventArgs e)
        {
            PowerHelper.ResetSystemDefault();
        }

        //public static string HostName { get; set; }

        //public static string UserName { get; set; }

        public static Machine OldHost { get; set; }
        public static Machine NewHost { get; set; }

        public static long TotalSize { get; set; }

        private void Browse(object sender, EventArgs e)
        {
            var sendObj = (TextBox)sender;
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

        private void CheckHost(object sender, EventArgs e)
        {
            var Box = (TextBox)sender;
            var BoxName = Box.Name;


            var BGworker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true,
            };
            BGworker.DoWork += CheckHostWorker;
            BGworker.ProgressChanged += CheckHostProgressUpdate;

            BGworker.RunWorkerAsync(Box);

            //return new EventHandler(CheckHost);
        }

        private void CheckHostProgressUpdate(object sender, ProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CheckHostWorker(object sender, DoWorkEventArgs e)
        {
            //var test = e.Argument;
            //var testname = test.Name
            var Box = (Form)sender;
            var BoxName = Box.Name;

            MessageBox.Show(BoxName);
        }

        private void UpdateSource(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            SourceHost = textBoxSourceHost.Text;
            SourceDrive = comboBoxSourceDrive.Text;
            SourceProfile = comboBoxSourceProfile.Text;
            SourceLocaldata = textBoxSourceLocalData.Text;

            if (checkBoxSourceLocal.Checked)
            {
                SourceHostPath = SourceDrive + @":\";
            }
            else
            {
                SourceHostPath = @"\\" + SourceHost + @"\" + SourceDrive + @"$\";
            }


            labelFullSource.Text = SourceHostPath + SourceProfile;
        }

        private void UpdateTarget(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        

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
