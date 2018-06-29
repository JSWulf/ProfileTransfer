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


            if (string.Equals(Hostname, Environment.MachineName, StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(Hostname, "Localhost", StringComparison.InvariantCultureIgnoreCase) )
            {
                IsLocal = true;
                ConnectionState = 100;
            }
            else
            {
                IsLocal = false;

                var BGworker = new BackgroundWorker
                {
                    WorkerReportsProgress = true,
                    WorkerSupportsCancellation = true,
                };
                BGworker.DoWork += CheckHostWorker;
                BGworker.ProgressChanged += CheckHostProgressUpdate;

                BGworker.RunWorkerAsync();
            }

            

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

        public string[] GetUsers(string userpath)
        {
            var UsersList = new List<string>();
            if (Directory.Exists(userpath))
            {
                foreach (var folder in Directory.GetDirectories(userpath))
                {
                    if (!folder.EndsWith("Default User", StringComparison.InvariantCultureIgnoreCase) &&
                        !folder.EndsWith("All Users", StringComparison.InvariantCultureIgnoreCase) &&
                        !folder.EndsWith("Public", StringComparison.InvariantCultureIgnoreCase) &&
                        !folder.EndsWith("Default", StringComparison.InvariantCultureIgnoreCase))
                    {
                        //UsersList.Add(Path.GetFileName(folder));
                        UsersList.Add(folder.Remove(0, folder.IndexOf(DriveLetter) + 3));
                    }
                }

                return UsersList.ToArray();
            }
            return null;

        }


        private string hostname;
        public string Hostname
        {
            get { return hostname; }
            set
            {
                hostname = value;
                OnPathChange();
            }
        }

        private string profilesouce;
        public string ProfileSource { get { return profilesouce; } set {
                profilesouce = value;
                var usrchk = value.Remove(0, value.LastIndexOf('\\') + 1);
                if (username != usrchk)
                {
                    username = usrchk;
                }
                OnPathChange();
            } }

        private string username;
        public string UserName { get { return username; } set {
                username = value;
                var sourceCheck = profilesouce.Remove(ProfileSource.LastIndexOf('\\') + 1) + value;
                if (profilesouce != sourceCheck)
                {
                    profilesouce = sourceCheck;
                }
                OnPathChange();
            } }
        
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

        public virtual void OnPathChange()
        {
            PathChanged?.Invoke(this, EventArgs.Empty);
        }

    }

}
