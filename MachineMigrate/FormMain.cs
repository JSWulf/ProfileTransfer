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
using System.Diagnostics;
using System.Threading;

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
            OldHost = new Machine();
            NewHost = new Machine();

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

            buttonStart.Click += new EventHandler(delegate (Object o, EventArgs ea) { Start(); });

            buttonStop.Click += new EventHandler(delegate (Object o, EventArgs ea) { Stop(); });

            SourceField.LocalData.TextChanged += LocalDataChange;
            TargetField.IsLocal.CheckedChanged += LocalDataChange;

            Log.LogUpdated += new EventHandler(delegate (Object o, EventArgs ea)
            {
                if (!BGcopyRunning)
                { UpdateLogList(); }
            });
            Log.LogProgressUpdated += new EventHandler(delegate (Object o, EventArgs ea) { UpdateLogList(); });
            //set defaults

            var confFile = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + 
                @"\MachineMigrate.conf";
            //MessageBox.Show(confFile);

            if (File.Exists(confFile))
            {
                //MessageBox.Show("get it");
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
                            NewHost.Hostname = sline[1];
                            break;
                        case "User":
                            //expecting full drive path
                            OldHost.ProfileSource = GenericFunctions.NoHostPath(sline[1]);
                            OldHost.DriveLetter = GenericFunctions.GetDriveLetterFromPath(sline[1]);
                            break;
                        default:
                            break;
                    }
                }
            }
            //else
            //{
            if (OldHost.Hostname == null)
            {
                OldHost.IsLocal = true;
                OldHost.Hostname = "Localhost";
            }
            if (OldHost.ProfileSource == null)
            {
                OldHost.ProfileSource = Environment.GetEnvironmentVariable("USERPROFILE").Remove(0, 3);
            }
            if (OldHost.Hostname == null)
            {
                NewHost.IsLocal = true;
                NewHost.Hostname = "Localhost";
            }
            if (OldHost.ProfileSource == null)
            {
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
            }

                
                
            //}

            SourceField.SetUsers();
            TargetField.SetUsers();

            textBoxSourceLocalData.Text = "Localdata";
            textBoxTargetLocalData.Text = "Localdata";
            checkBoxLocalData.Checked = true;

            PowerHelper.ForceSystemAwake();
        }

        

        private void FormMain_unLoad(object sender, EventArgs e)
        {
            PowerHelper.ResetSystemDefault();
        }

        protected void UpdateLogList()
        {
                LogListBox.Items.Add(Log.LastLineAdded);

                if (LogListBox.Items.Count > 5)
                {
                    LogListBox.SelectedIndex = (LogListBox.Items.Count - 1);
                }
        }

        private void LocalDataChange(object sender, EventArgs e)
        {
            var srcTxt = SourceField.LocalData.Text;
            if (srcTxt.Contains(@"\\") || srcTxt.Contains(@":\"))
            {
                var removeStart = srcTxt.Remove(0, 3);
                int SubCheck = removeStart.IndexOf(@"\");
                if (SubCheck <= 0)
                {
                    TargetField.LocalData.Text = removeStart;
                }
                else
                {
                    TargetField.LocalData.Text = removeStart.Remove(0, SubCheck);
                }
            }
            else
            {
                TargetField.LocalData.Text = srcTxt.Replace(OldHost.DrivePath, NewHost.DrivePath);
            }
        }

        

        

        private string[] GetUsers(string userpath)
        {
            if (Directory.Exists(userpath))
            {
                return Directory.GetDirectories(userpath);
            }
            return null;
        }


        private void Start()
        {
            StartTime = DateTime.Now;
            labelStartTime.Text = DateTime.Now.ToString("HH:mm:ss");
            RunClock.DoWork += RunClock_DoWork;
            RunClock.ProgressChanged += UpdateTime;
            RunClock.RunWorkerCompleted += RunClock_RunWorkerCompleted;

            RunClock.RunWorkerAsync();

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;

            if (SourceField.CkLocalData.Checked)
            {
                if (OldHost.LocalData.Contains(@"\\") || OldHost.LocalData.Contains(@":\"))
                {
                    if (string.IsNullOrEmpty(NewHost.LocalData) || 
                        NewHost.LocalData.Contains(@"\\") || 
                        NewHost.LocalData.Contains(@":\"))
                    {
                        clist = new CopyList(OldHost.LocalData, NewHost.LocalData);
                    }
                    else
                    {
                        clist = new CopyList(OldHost.LocalData);
                    }
                }
                else
                {
                    clist = new CopyList(OldHost.DrivePath + OldHost.LocalData);
                }
            }
            else
            {
                clist = new CopyList();
            }

            clist.ProgressUpdated += ProgressMade;


            try
            {
                clist.MainStart();
                buttonOpenLog.Enabled = true;
                listBoxItemsToGo.Items.Clear();
                foreach (var item in clist.CopyItems)
                {
                    listBoxItemsToGo.Items.Add(Path.GetFileName(item.Source));

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                buttonStart.Enabled = true;
                buttonStop.Enabled = false;
            }

            
            
        }

        private void RunClock_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void UpdateTime(object sender, ProgressChangedEventArgs e)
        {
            ///DateTime a = null;
                var a = DateTime.Now.Subtract(StartTime);
            labelTimer.Text = a.ToString("c").Remove(8);
        }

        private void RunClock_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (RunClock.CancellationPending)
                {
                    break;
                }
                RunClock.ReportProgress(0);
            }
        }

        public void Stop()
        {
            if (clist != null)
            {
                clist.StopCopy();
            }
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }
        
        public void ProgressMade(object sender, EventArgs e)
        {
            if (listBoxItemsToGo.Items.Count != 0)
            {
                listBoxItemsToGo.Items.RemoveAt(0);
            }
            progressBar1.Value = clist.ProgressDone;
        }

        protected static BackgroundWorker RunClock = new BackgroundWorker() {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

        public DateTime StartTime { get; private set; }

        public static CopyList clist { get; set; }
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
        public static bool BGcopyRunning { get; protected set; }

        private void checkBoxLocalData_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSourceLocalData.Enabled = checkBoxLocalData.Checked;
            textBoxTargetLocalData.Enabled = checkBoxLocalData.Checked;
            buttonLocalSourceBrowse.Enabled = checkBoxLocalData.Checked;
            buttonLocalTargetBrowse.Enabled = checkBoxLocalData.Checked;
        }

        private void buttonOpenLog_Click(object sender, EventArgs e)
        {
            if (File.Exists(Log.LogFile))
            {

                Process.Start(Log.LogFile);
            }
            
        }
    }
}
