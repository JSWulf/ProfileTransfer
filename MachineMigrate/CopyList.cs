using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MachineMigrate
{
    public class CopyList : FormMain
    {
        public CopyList()
        {
            CopyItems = new List<CopyItem>();
        }
        public CopyList(string ExtraFolder)
        {
            CopyItems = new List<CopyItem>
            {
                new CopyItem(ExtraFolder)
            };
        }
        public CopyList(List<string> ExtraFolders)
        {
            CopyItems = new List<CopyItem>();

            foreach (var item in ExtraFolders)
            {
                CopyItems.Add(new CopyItem(item));
            }
        }
        public CopyList(string ExtraFolder, string ExtraTarget)
        {
            CopyItems = new List<CopyItem>
            {
                new CopyItem(ExtraFolder, ExtraTarget)
            };
        }

        public void MainStart()
        {
            //Log.LogUpdated += UpdateLogList;
            Console.WriteLine(OldHost.DrivePath);
            var oldUserRoot = OldHost.DrivePath + OldHost.ProfileSource;
            Log.LogFile = NewHost.DrivePath + NewHost.ProfileSource + @"\MachineMigration" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";
            Console.WriteLine("check2");
            //add user profile files and folders
            //////////////////////////////////////////////////////////////user profile folders
            Log.Add("(1) Adding User " + OldHost.UserName + " folders...");
            foreach (var folder in Directory.GetDirectories(oldUserRoot))
            {
                if (!Exceptions.ProfileFolders.ListContains(folder))
                {
                    AddItem(folder);
                }
                else { Log.Add("Skipping: " + folder); }
            }
            Log.Add("...(1) Complete.");

            //////////////////////////////////////////////////////////////user profile files
            Log.Add("(2) Adding User " + OldHost.UserName + " files...");
            foreach (var file in Directory.GetFiles(oldUserRoot))
            {
                if (!Exceptions.ProfileFiles.ListContains(file))
                {
                    AddItem(file);

                } else { Log.Add("Skipping: " + file); }
            }
            Log.Add("...(2) Complete.");

            //////////////////////////////////////////////////////////////user appdata folders
            Log.Add("(3) Adding User " + OldHost.UserName + " Profile Additions...");
            foreach (var line in ProfileAdditions.AppDataFolders)
            {
                if (Directory.Exists(oldUserRoot + line))
                {
                    AddItem(oldUserRoot + line);
                }
                else { Log.Add("Skipping: " + oldUserRoot + line); }
            }
            Log.Add("...(3) Complete.");

            ///////////////////////////////////////////Copy Items
            //Log.Add("Total size of things to copy: " + TotalSize);

            BGcopy = new BackgroundWorker {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
                //WorkerReportsCompleted = true
            };

            BGcopy.RunWorkerCompleted += BackgroundComplete;
            BGcopy.DoWork += BackgroundStart;
            BGcopy.ProgressChanged += BackgroundProgress;
            

            //Log.LogUpdated -= UpdateLogList;
            //Log.LogUpdated += new EventHandler(delegate (Object o, EventArgs ea) { });
            BGcopyRunning = true;
            BGcopy.RunWorkerAsync();

            ///////////////////////////////////////////End Copy

            
        }

        public void StopCopy()
        {
            if (BGcopyRunning)
            {
                BGcopy.CancelAsync();
            }
        }

        private void BackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
            BGcopyRunning = false;
            //Log.LogUpdated += UpdateLogList;
            Log.Add("Migration complete at: " + Log.TimeStamp());
            RunClock.CancelAsync();
        }

        private void BackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            var calIndex = (e.ProgressPercentage / CopyItems.Count) * 100;
            //ProgressMade(e.ProgressPercentage, calIndex);
            ProgressDone = e.ProgressPercentage;
            Log.OnLogProgressUpdate();
        }

        public void BackgroundStart(object sender, DoWorkEventArgs args)
        {
            Thread.Sleep(1000);
            var thisWorker = (sender as BackgroundWorker);
            int counter = 1;
            foreach (var item in CopyItems)
            {
                if (thisWorker.CancellationPending) { return; }

                Log.Add(item.Copy());

                double calculate = counter * 100 / CopyItems.Count;
                
                thisWorker.ReportProgress(Convert.ToInt32(calculate));
            }
        }

        private BackgroundWorker BGcopy;
        private void AddItem(string subitem)
        {
            var newfolder = new CopyItem(subitem);

            Log.Add("Adding: " + subitem);

            CopyItems.Add(newfolder);

            TotalSize += newfolder.Size;
        }

        public List<CopyItem> CopyItems { get; set; }
        private int progress;

        public int ProgressDone
        {
            get { return progress; }
            set {
                progress = value;
                OnProgressUpdated();
            }
        }

        public event EventHandler ProgressUpdated;

        public void OnProgressUpdated()
        {
            ProgressUpdated?.Invoke(null, EventArgs.Empty);
        }

    }


}
