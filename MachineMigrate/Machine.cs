using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMigrate
{
    public class Machine
    {
        public Machine()
        {
            
        }
        public Machine(string Host)
        {
            Hostname = Host;
        }


        public void CheckHost(object sender, EventArgs e)
        {
            //var Box = (TextBox)sender;
            //var BoxName = Box.Name;
            Console.WriteLine("Checking host....");

            var BGworker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true,
            };
            BGworker.DoWork += CheckHostWorker;
            BGworker.ProgressChanged += CheckHostProgressUpdate;

            BGworker.RunWorkerAsync();

            //BGworker.CancelAsync();
            //return new EventHandler(CheckHost);
        }

        private void CheckHostProgressUpdate(object sender, ProgressChangedEventArgs e)
        {
            ConnectionState = e.ProgressPercentage;
        }

        private void CheckHostWorker(object sender, DoWorkEventArgs e)
        {
            var thisWorker = (sender as BackgroundWorker);

            thisWorker.ReportProgress(0);
            
            if (Directory.Exists(DrivePath))
            {
                thisWorker.ReportProgress(100);
            }
            else
            {
                thisWorker.ReportProgress(50);
            }

            thisWorker.Dispose();
        }

       
        private string hostname;
        public string Hostname
        {
            get { return hostname; }
            set
            {
                hostname = value;
                OnPathChange();
                //if (string.Equals(value, Environment.MachineName, StringComparison.InvariantCultureIgnoreCase))
                //{
                //    IsLocal = true;
                //} else { IsLocal = false;
                //}
            }
        }

        private string profilesouce;
        public string ProfileSource { get { return profilesouce; } set { profilesouce = value; OnPathChange(); } }

        private string username;
        public string UserName { get { return username; } set { username = value; OnPathChange(); } }
        
        private bool islocal;
        public bool IsLocal { get { return islocal; } set { islocal = value; OnPathChange(); } }

        private string driveletter = "C";
        public string DriveLetter { get { return driveletter; } set { driveletter = value; OnPathChange(); } }

        public string LocalData { get; set; }

        private int connectionState;
        public int ConnectionState
        {
            get { return connectionState; }
            set
            {
                connectionState = value;
                OnStateChange();
            }
        }
        public string DrivePath
        {
            get
            {
                if (IsLocal)
                {
                    return DriveLetter + @":\";
                }
                else
                {
                    return @"\\" + Hostname + @"\" + DriveLetter + @"$\";
                }
            }
            set { }
        }

        //private string fullPath;

        public string FullPath
        {
            get { //return fullPath; 
                return DrivePath + ProfileSource;
            }
            set {
                //fullPath = value;
                OnPathChange();
            }
        }


        public event EventHandler ConnectivityChanged;

        protected virtual void OnStateChange()
        {
            ConnectivityChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler PathChanged;

        protected virtual void OnPathChange()
        {
            PathChanged?.Invoke(this, EventArgs.Empty);
        }

    }

}
