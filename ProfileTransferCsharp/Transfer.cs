using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace ProfileTransferCsharp
{
    public partial class Transfer : Form
    {

        //ArrayList  = new ArrayList();
        string ProfileSource, ProfileDest, DriveDest, DriveSource;
		bool incLocaldata, DirectTrans, DriveExtra, incRegistry;

		public double ToComplete = 0, progress = 0;
		public double Progress
		{
			get { return progress; }
			set
			{
				progress = value;
			}
		}
		//public MethodInvoker BGtodo = new MethodInvoker(Action);
		public string BGtodo;


		List<string> copyFiles = new List<string>(), copyFolders = new List<string>(), noFileCopy = new List<string>(), noFolderCopy = new List<string>();
		public List<string> loglist = new List<string>(), remaining = new List<string>();

		private TimeSpan startTime;// = DateTime.Now;
        
        public Transfer()
        {
            InitializeComponent();
        }


        private void Transfer_Load(object sender, EventArgs e)
        {
			startTime = DateTime.Now.TimeOfDay;
			label1.Text = DateTime.Now.ToString("H:mm");

			remaining.Add("CopyFiles");

			listBox1.HorizontalScrollbar = true;
			//set progress int 0
			Progress = 0;
			progressBar1.Value = 1;
			//set nocopy rules
			#region nocopy rules
			loglist.Add("Setting exception rules...");
            noFileCopy.Add("ntuser.dat");
            noFileCopy.Add("NTUSER.DAT");
            noFileCopy.Add("ntuser.ini");
            noFileCopy.Add("ntuser.pol");
            //noFileCopy.Add(@"\.");

            noFolderCopy.Add("Application Data");
            noFolderCopy.Add("Local Settings");
            noFolderCopy.Add("AppData");
            noFolderCopy.Add("My Documents");
            noFolderCopy.Add("My Music");
            noFolderCopy.Add("Searches");
            noFolderCopy.Add("Cookies");
            noFolderCopy.Add("NetHood");
            noFolderCopy.Add("PrintHood");
            noFolderCopy.Add("Recent");
            noFolderCopy.Add("SendTo");
            noFolderCopy.Add("Start Menu");
            noFolderCopy.Add("Templates");
            noFolderCopy.Add("IntelGraphicsProfiles");
            noFolderCopy.Add(".cisco");
            noFolderCopy.Add(".dnx");
            noFolderCopy.Add(".oracle_jre_usage");
            noFolderCopy.Add(".vscode");
            noFolderCopy.Add("Saved Games");
			noFolderCopy.Add("ProfileTransferLogs"); 


			loglist.Add("...Complete");

            Console.WriteLine("check1");

            loglist.Add("Adding Profile Source...");
            copylist(profileSource);
            loglist.Add("... Profile Source add complete");


            loglist.Add("Getting extras...");

            noFolderCopy.Clear();

            noFolderCopy.Add(@"\$");
            noFolderCopy.Add("System Volume Information");
            noFolderCopy.Add("Coach");
            noFolderCopy.Add("dynpubdata");
            noFolderCopy.Add("entryformData");
            noFolderCopy.Add("DPPRSync");

            extras();

            loglist.Add("Extras Complete...");


            if (driveExtra)
            {
                loglist.Add("Including Extra Drive/Partition...");

                noFolderCopy.Clear();

                noFolderCopy.Add(@"\$");
                noFolderCopy.Add("System Volume Information");

                copylist(DriveSource);

            } else
            {
                loglist.Add("No extra Drive/Parition...");
            }

			#endregion
			Console.WriteLine("check output");
			//string output = "";

			//foreach(string line in copyFiles) { output = output + line + Environment.NewLine; }
			//output = output + "on to folders" + Environment.NewLine;
			//foreach(string line in copyFolders) { output = output + line + Environment.NewLine; }

			//MessageBox.Show(output);

			if (incRegistry) { ImportDrives(); }


			loglist.Add("Moving onto copy process...");

            listUpdate();

			progressBar1.Maximum = Convert.ToInt32(ToComplete);

			/////////////////////////////////////////////
			backgroundWorker1.RunWorkerAsync(); 
            /////////////////////////////////////////////
			

        }
        private void unload(object sender, EventArgs e)
        {
			//called when exiting
			SaveLog();

		}
		#region list build
		private void copylist(string rootdir)
        {
            Console.WriteLine("check file");
            foreach (string file in Directory.GetFiles(rootdir))
            {
                int tempint = 0;
                foreach (string baditem in noFileCopy)
                {
                    if (file.Contains(baditem)) { tempint++; }
                }
                if (tempint < 1)
                {
                    loglist.Add("Adding File: " + file);
                    copyFiles.Add(file);
					ToComplete++;
				} else { loglist.Add("Skipping File: " + file); }
            }

            Console.WriteLine("check folder");
            foreach (string dir in Directory.GetDirectories(rootdir))
            {
                int tempint = 0;
                foreach (string baditem in noFolderCopy)
                {
                    if (dir.Contains(baditem)) { tempint++; }
                }
                if (tempint < 1)
                {
                    loglist.Add("Adding Folder: " + dir);
                    copyFolders.Add(dir);
					remaining.Add(Path.GetFileName(dir));
					ToComplete++;
                } else { loglist.Add("Skipping Folder: " + dir); }

            }
        }
		
		private void extras()
        {
            if (incLocaldata)
            {
                loglist.Add("Localdata True...");
                loglist.Add(ProfileSource + @"\..\..\localdata");
                if (Directory.Exists("LocaldataForTransfer"))
                {
                    //donothing
                } else if (Directory.Exists(ProfileSource + "\\..\\Localdata"))
                {
                    loglist.Add("Adding: " + ProfileSource + @"\..\Localdata");
                    copylist(ProfileSource + @"\..\Localdata");
                }
                else if (Directory.Exists(ProfileSource + "\\..\\..\\Localdata"))
                {
                    loglist.Add("Adding: " + ProfileSource + @"\..\..\Localdata");
                    copylist(ProfileSource + @"\..\..\Localdata");
                } else { loglist.Add("LocalData Folder not Found..."); }
            } else { loglist.Add("Localdata False..."); }

            List<string> extras = new List<string>();

            extras.Add(profileSource + @"\AppData\Local\Microsoft\Outlook");
            extras.Add(profileSource + @"\AppData\Roaming\Microsoft\Signatures");
            extras.Add(profileSource + @"\AppData\Roaming\Microsoft\Templates");
            extras.Add(profileSource + @"\AppData\Roaming\Microsoft\Sticky Notes");
            extras.Add(profileSource + @"\AppData\Roaming\Microsoft\OneNote");
            //extras.Add(profileSource + @"\AppData\Roaming\Microsoft\sillytest");

            foreach (string line in extras)
            {
                loglist.Add("For: " + line);
                if (Directory.Exists(line))
                {
                    loglist.Add("... Included");
                    copyFolders.Add(line);
					ToComplete++;
				} else { loglist.Add("... Skipped"); }
            }

            
        }
		#endregion
		private void copyProcess(string Source)
        {
			string Dest = profileDest + @"\" + Path.GetFileName(Source);

			//check if drive partition
			if (Source.Contains(DriveSource) && DriveExtra)
			{
				loglist.Add("Condition 1 - changing dest to: " + driveDest + @"\" + Path.GetFileName(Source));
				Dest = driveDest + @"\" + Path.GetFileName(Source);
			}
			else if (Source.Contains(@"\Localdata")) //check for local an direct
			{
					loglist.Add("Condition 2 - Localdata. Direct: " + directTrans);
					if (directTrans)
					{
						loglist.Add("... \\..\\..\\Localdata\\" + Path.GetFileName(Source));
						Dest = profileDest + "\\..\\..\\Localdata\\" + Path.GetFileName(Source);
					}
					else
					{
						loglist.Add("... To LocaldataForTransfer\\" + Path.GetFileName(Source));
						Dest = profileDest + "\\LocaldataForTransfer\\" + Path.GetFileName(Source);
					}
			} else if (Source.Contains("LocaldataForTransfer")) //check for backedup localdata
			{
				loglist.Add("Condition 3 - LocaldataForTransfer");
				if (Directory.Exists(profileDest + "\\..\\..\\Localdata\\" + Path.GetFileName(Source)))
				{
					Dest = profileDest + "\\..\\..\\Localdata\\" + Path.GetFileName(Source);
				}
			} else if (Source.Contains(@"AppData\local\Microsoft")) //set appdata folders
			{
				string appFolder = Path.GetFileName(Source);
				Dest = profileDest + @"\AppData\Local\Microsoft\" + appFolder;
			}
			else if (Source.Contains(@"AppData\Roaming\Microsoft")) //set appdata folders
			{
				string appFolder = Path.GetFileName(Source);
				Dest = profileDest + @"\AppData\Local\Microsoft\" + appFolder;
			}

			loglist.Add("Running: robocopy \"" + Source + " \" to: \"" + Dest + " \" /E /W:0 /R:1 /LOG+:\"" + ProfileDest + "\\ProfileTransferLogs\\robocopyLog" + Path.GetFileName(Dest) + ".txt\" ");

			Process pross = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = Environment.SystemDirectory + "/cmd.exe";
			pross.StartInfo = startInfo;
			pross.StartInfo.UseShellExecute = true;
			pross.StartInfo.RedirectStandardOutput = false;

			/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			//startInfo.Arguments = " /c ";
			startInfo.Arguments = " /c RoboCopy \"" + Source + " \" \"" + Dest + " \" /E /W:0 /R:1 /LOG+:\"" + ProfileDest + "\\ProfileTransferLogs\\robocopyLog-" + Path.GetFileName(Dest) + ".txt\" ";


			//loglist.Add(Environment.SystemDirectory + "\\cmd.exe /c robocopy \"" + Source + " \" \"" + Dest + " \" /E /W:0 /R:1 /LOG+:\"" + ProfileDest + "\\ProfileTransferLogs\\robocopyLog" + Path.GetFileName(Dest) + ".txt\" ");

			pross.Start();
			pross.WaitForExit();
			loglist.Add(Path.GetFileName(Dest) + " Completed.");
			remaining.Remove(Path.GetFileName(Source));
			Progress++;

		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			//object[] workerlist = { backgroundWorker2, backgroundWorker3, backgroundWorker4, backgroundWorker5 };
			BackgroundWorker[] workerlist = { backgroundWorker2, backgroundWorker3, backgroundWorker4, backgroundWorker5 };

			if (!Directory.Exists(ProfileDest + "\\ProfileTransferLogs"))
			{
				Directory.CreateDirectory(ProfileDest + "\\ProfileTransferLogs");
			}

			BGtodo = "F";
			backgroundWorker5.RunWorkerAsync();
			Thread.Sleep(200);

			int indexCounter = 0;
			if (!backgroundWorker1.IsBusy) { }

			while (indexCounter <= copyFolders.Count-1)
			{
				if (backgroundWorker1.CancellationPending) { break; }
				foreach (BackgroundWorker worker in workerlist)
				{
					if (!worker.IsBusy && indexCounter <= copyFolders.Count - 1)
					{
						BGtodo = copyFolders[indexCounter];
						worker.RunWorkerAsync();
						indexCounter++;
						Thread.Sleep(200);
						backgroundWorker1.ReportProgress(0);
					}
				}

				Thread.Sleep(300);
			}
			int wcd = 0;
			while (wcd < 4)
			{
				foreach (BackgroundWorker worker in workerlist)
				{
					if (!worker.IsBusy)
					{
						wcd++;
					}
				}
				backgroundWorker1.ReportProgress(0);
				if (wcd < 4) { wcd = 0; }
				Thread.Sleep(1000);
			}

			backgroundWorker1.ReportProgress(100);
		}

		private void backgroundwork1_reportProgress(object sender, ProgressChangedEventArgs e)
		{
			progressBar1.Value = Convert.ToInt32(Progress);
			txtProgressBar1.Text = (Convert.ToInt32(Progress / ToComplete * 100) + "% Complete");

			if (e.ProgressPercentage == 100)
			{
				buttonExit.Enabled = true;
				loglist.Add("...Complete. Saving log file to: " + ProfileDest + @"\ProfileTransferLogs\");
				listUpdate();
				SaveLog();
				txtProgressBar1.Text = ("Complete!");
				progressBar1.Hide();
				buttonPanic.Enabled = false;
			}

			else
			{
				listUpdate();
			}
		}

		

		private void copyFileFunction()
        {
			
            foreach(string file in copyFiles)
            {
				//string Dest = ProfileDest + @"\" + Path.GetFileName(file);
				string Dest = file.Replace(ProfileSource, ProfileDest);
				if (DriveExtra)
				{
					if (file.Contains(driveSource))
					{
						loglist.Add("DriveSource... Redirecting to: " + driveDest + @"\" + Path.GetFileName(file));
						Dest = driveDest + @"\" + Path.GetFileName(file);
					}
				}
				if (file.Contains("\\Localdata\\"))
				{
					if (incLocaldata)
					{
						if (!directTrans)
						{
							Dest = profileDest + "\\LocaldataForTransfer\\" + Path.GetFileName(file);
						}
					}
				}


				try
				{
				loglist.Add("Copying File: " + file + " to " + Dest);
					loglist.Add("Checking for: " + Path.GetDirectoryName(Dest));
					if (!Directory.Exists(Path.GetDirectoryName(Dest)))
					{
						loglist.Add("Not there - creating: " + Path.GetDirectoryName(Dest));
						Directory.CreateDirectory(Path.GetDirectoryName(Dest));
					}
					////////////////////////////////////////////////////////////////////////////////////////////////////////
                    File.Copy(file, Dest, true);

					//Progress++;
                } catch
                {
                    loglist.Add("Something went wrong with: " + file);
                }
				//loglist.Add("Updating Progress: " + (Progress+1));
				Progress++;
			}

			remaining.Remove("CopyFiles");
        }

		

		public void listUpdate()
        {
			try
			{
				foreach (string line in loglist)
				{
					listBox1.Items.Add(line);
					listBox1.TopIndex = listBox1.Items.Count - 1;
				}
				loglist.Clear();
			}
			catch { }
			try
			{
				listBox2.Items.Clear();
				foreach (string line in remaining)
				{
					listBox2.Items.Add(line);
				}
			}
			catch { }

			TimeSpan newTime = DateTime.Now.TimeOfDay - startTime;

			label2.Text = newTime.ToString("c").Remove(8) ;//ToString("H:m");
		}






		private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
		{
			copyProcess(BGtodo);
		}
		private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
		{
			copyProcess(BGtodo);
		}

		private void buttonPanic_Click(object sender, EventArgs e)
		{
			BackgroundWorker[] workerlist = { backgroundWorker2, backgroundWorker3, backgroundWorker4, backgroundWorker5 };
			if (backgroundWorker1.IsBusy) { backgroundWorker1.CancelAsync(); }
			foreach (BackgroundWorker worker in workerlist)
			{
				if (worker.IsBusy) { worker.CancelAsync(); }
			}
			loglist.Add("...Aborded by Technician :( why do you do that to me?");
			listUpdate();
			buttonExit.Enabled = true;
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			BackgroundWorker[] workerlist = { backgroundWorker2, backgroundWorker3, backgroundWorker4, backgroundWorker5 };
			if (backgroundWorker1.IsBusy) { backgroundWorker1.CancelAsync(); loglist.Add("...Aborded by Technician :( why do you do that to me?"); }
			foreach (BackgroundWorker worker in workerlist)
			{
				if (worker.IsBusy) { worker.CancelAsync(); }
			}
			listUpdate();
			SaveLog();
			Close();
		}

		private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
		{
			copyProcess(BGtodo);
		}

		private void buttonView_Click(object sender, EventArgs e)
		{
			Process.Start(profileDest + @"\ProfileTransferLogs");
		}

		private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
		{
			if (BGtodo == "F") { copyFileFunction(); } else
			{
				copyProcess(BGtodo);
			}

		}

		private void SaveLog()
		{
			string[] toWrite = new string[listBox1.Items.Count];
			int i = 0;
			foreach (string item in listBox1.Items) { toWrite[i] = item; i++; }
			if (!Directory.Exists(ProfileDest + @"\ProfileTransferLogs")) { Directory.CreateDirectory(ProfileDest + @"\ProfileTransferLogs"); }
			File.WriteAllLines(ProfileDest + @"\ProfileTransferLogs\CopyLog.txt", toWrite);
		}


		private void ImportDrives()
		{
			//E: \Users\rmclough\NTUSER.DAT
			//NTuserDat NTloader = new NTuserDat();
			//use profiledest to save regkeys
			//check profilesource in case we are restoring from a backup.
			//use name UserReg.txt

			MessageBox.Show(NTuserDat.Load(ProfileSource + @"\NTUSER.DAT", "TransferUser"));

			List<string> driveLetter = new List<string>();
			List<string> drivePath = new List<string>();

			//StringBuilder outputString = new StringBuilder("");

			//RegistryKey regLocation = RegistryKey
			MessageBox.Show("fail point?");
			//string registryValue = string.Empty;
			//RegistryKey localKey = null;
			RegistryKey NetworkKey = Registry.Users.OpenSubKey(@"TransferUser\Network");
			MessageBox.Show(NetworkKey.ToString());

			foreach (string subkey in NetworkKey.GetSubKeyNames())
			{
				try
				{
					var tmp = Registry.GetValue(NetworkKey + @"\" + subkey, "RemotePath", null);

					driveLetter.Add(subkey);
					drivePath.Add(tmp.ToString());

					loglist.Add(subkey + Environment.NewLine + tmp.ToString() + Environment.NewLine);
				}
				catch { loglist.Add("Failed to get network drives"); }
			}



			for (int i = 0; i < driveLetter.Count; i++)
			{
				try
				{
					DriveSettings.MapNetworkDrive(driveLetter[i], drivePath[i]);
					loglist.Add(driveLetter[i] + " " + drivePath[i] + Environment.NewLine);
				}
				catch
				{
					loglist.Add("Failed adding: " + driveLetter[i] + " " + drivePath[i] + Environment.NewLine);
				}
				
				//i++;
			}

			//MsgBox(outputString.ToString() + driveLetter.Count);

			//DriveSettings.MapNetworkDrive("L", @"\\CSDWP-SUPWS13\JSWShare");

			NTuserDat.Unload("TransferUser");
		}


		// properties sets
		public string profileSource
        {
            get { return ProfileSource; }
            set { ProfileSource = value; }
        }
        public string profileDest
        {
            get { return ProfileDest; }
            set { ProfileDest = value; }
        }
        public string driveDest
        {
            get { return DriveDest; }
            set { DriveDest = value; }
        }
        public string driveSource
        {
            get { return DriveSource; }
            set { DriveSource = value; }
        }
        public bool incLocalData
        {
            get { return incLocaldata; }
            set { incLocaldata = value; }
        }
        public bool directTrans
        {
            get { return DirectTrans; }
            set { DirectTrans = value; }
        }
        public bool driveExtra
        {
            get { return DriveExtra; }
            set { DriveExtra = value; }
        }
		public bool IncRegistry
		{
			get { return incRegistry; }
			set { incRegistry = value; }
		}
	}

	class Status
	{

		
	}
}
