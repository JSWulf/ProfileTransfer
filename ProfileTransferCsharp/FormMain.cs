using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Win32;


//using System.Collections.Generic;
using System.ComponentModel;
//using System.Diagnostics;

namespace ProfileTransferCsharp
{
	

	public partial class FormMain : Form
    {
		// variables

		public string ProfileSource, ProfileDest, DriveDest, DriveSource;
        public bool incLocaldata, DirectTrans, incRegistry, DriveExtra, textOnly = false;

		//private uint previousExeState;

        bool LoadComplete = false;
		public FormMain()
		{
			Console.WriteLine("test");
			InitializeComponent();
		}

        public void MsgBox(string msg)
        {
            if(textOnly == true)
            {
                Console.WriteLine(msg);
            } else if(textOnly == false)
            {
                MessageBox.Show(msg);
            }

        }

        private void FormMain_Load(object sender, EventArgs e) // on load
        {
			//previousExeState = NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);

			//NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);

			//backgroundWorker1.RunWorkerAsync();
			PowerHelper.ForceSystemAwake();

			Console.WriteLine("test");

            DriveDest = @"Documents\oldHMIData";

            if (Directory.Exists("E:\\Users\\" + Environment.UserName))
            {
                textBoxSource.Text = ("E:\\Users\\" + Environment.UserName);
                textBoxDest.Text = ("C:\\Users\\" + Environment.UserName);
            } else if(Directory.Exists("D:\\Users\\" + Environment.UserName))
            {
                textBoxSource.Text = ("D:\\Users\\" + Environment.UserName);
                textBoxDest.Text = ("C:\\Users\\" + Environment.UserName);
            } else
            {
                textBoxSource.Text = ("C:\\Users\\" + Environment.UserName);
                textBoxDest.Text = ("D:\\Users\\" + Environment.UserName);
            }

            if (Directory.Exists("C:\\Localdata")) { checkBoxLocal.Checked = true; }

			////////////////////////////////////////////////////////////////////////////
			checkBoxRegistry.Checked = true;
			////////////////////////////////////////////////////////////////////////////

			int driveNumber = 0;
			DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (string drive in Environment.GetLogicalDrives())
            {
                if (drive != @"C:\")
                {
					comboBox1.Items.Add(drive + " - " + drives[driveNumber].VolumeLabel);
                }
				driveNumber++;
            }

            txtDriveDest.Text = textBoxDest.Text + @"\Documents\" + DriveDest;
			/*string tempDriveVar = Environment.GetLogicalDrives()[3];*/
			if (comboBox1.GetItemText(2) == "")
			{
				//MsgBox("it checked");
				comboBox1.SelectedIndex = 2;
					//Environment.GetLogicalDrives()[3];
			}
			else {
				//comboBox1.Text = Environment.GetLogicalDrives()[1];
				comboBox1.SelectedIndex = 0;
			}

			//HMI specific:
			//textBoxSource.Text = "";
			//textBoxDest.Text = "";
			checkBox1.Checked = false;
			DriveSource = comboBox1.Text.Remove(3);
			//checkBoxLocal.Checked = false;
			//checkBoxLocal.Hide();
			//buttonBackup.Hide();

            LoadComplete = true;
            
        }

        private void textBoxSource_TextChanged(object sender, EventArgs e)
        {
            ProfileSource = textBoxSource.Text;
            if (ProfileSource.Contains("C:\\"))
            {
                textBoxDest.Text = (ProfileSource.Remove(0, 1).Insert(0, "D"));
            }
            else
            {
                textBoxDest.Text = (ProfileSource.Remove(0, 1).Insert(0, "C"));
            }
			//txtDriveDest.Text = ProfileDest;
        }

        private void textBoxDest_TextChanged(object sender, EventArgs e)
        {

			if (ProfileDest == null)
			{
				//MsgBox("condition true");
				ProfileDest = textBoxDest.Text;
				txtDriveDest.Text = textBoxDest.Text + @"\Documents\" + DriveDest;
			}
			else
			{
				if (LoadComplete == true && txtDriveDest.Text.Contains(ProfileDest))
				{
					txtDriveDest.Text = textBoxDest.Text + @"\Documents\" + DriveDest;
					//txtDriveDest.Text = Path.Combine(textBoxDest.Text, DriveDest);
				}

				ProfileDest = textBoxDest.Text;
				//txtDriveDest.Text = ProfileDest + @"\" + DriveDest;
				Thread.Sleep(20);
				if (LoadComplete == true && txtDriveDest.Text.Contains(ProfileDest))
				{
					txtDriveDest.Text = textBoxDest.Text + @"\Documents\" + DriveDest;
					//txtDriveDest.Text = Path.Combine(textBoxDest.Text, DriveDest);
				}
			}
		}

        private void checkBoxLocal_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLocal.Checked == true)
            { incLocaldata = true;
            } else { incLocaldata = false; }
        }

        private void checkBoxRegistry_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRegistry.Checked == true)
            {
                incRegistry = true;
            }
            else { incRegistry = false; }
        }

        private void buttonSourceBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog tempvar = new FolderBrowserDialog();
            tempvar.ShowNewFolderButton = false;
			tempvar.SelectedPath = @"C:\Users\";
			DialogResult result = tempvar.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxSource.Text = tempvar.SelectedPath;
            }
        }

        private void buttonDestBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog tempvar = new FolderBrowserDialog();
            tempvar.ShowNewFolderButton = true;
            tempvar.SelectedPath = @"C:\Users\";
            DialogResult result = tempvar.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxDest.Text = tempvar.SelectedPath;
            }
        }

        private void buttonBackup_Click(object sender, EventArgs e)
        {
            DirectTrans = false;
            timeToRun();
        }

		private void buttonSecondaryBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog tempvar = new FolderBrowserDialog();
			tempvar.ShowNewFolderButton = true;
			tempvar.SelectedPath = txtDriveDest.Text;
			DialogResult result = tempvar.ShowDialog();
			if (result == DialogResult.OK)
			{
				txtDriveDest.Text = tempvar.SelectedPath;
			}
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			while (1 == 1) {
				if (backgroundWorker1.CancellationPending) { break; }
				Thread.Sleep(300000);
				backgroundWorker1.ReportProgress(0);
			}
		}
		private void backgroundWorker1_reportProgress(object sender, ProgressChangedEventArgs e)
		{
			//MsgBox("itworks");
			//NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);
			//SendKeys.Send("{RIGHT}");
		}

		

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                DriveSource = comboBox1.Text.Remove(3);
            } else { DriveSource = ""; }

        }

        private void txtDriveDest_TextChanged(object sender, EventArgs e)
        {
            //DriveDest = txtDriveDest.Text.Replace(ProfileDest + @"\", "");
            DriveDest = Path.GetFileName(txtDriveDest.Text);
            //DriveDest = txtDriveDest.Text;
            //MsgBox(DriveDest);
        }

		private void button2_Click(object sender, EventArgs e)
		{
			NTuserDat.Unload("TransferUser");
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                comboBox1.Enabled = true; txtDriveDest.Enabled = true; buttonSecondaryBrowse.Enabled = true;
            } else
            {
                comboBox1.Enabled = false; txtDriveDest.Enabled = false; buttonSecondaryBrowse.Enabled = false;
			}
        }

        private void buttonTransfer_Click(object sender, EventArgs e)
        {
            DirectTrans = true;
            timeToRun();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_Unload(object sender, EventArgs e)
        {
			//MessageBox.Show("hahahaha!");
			PowerHelper.ResetSystemDefault();
			// Restore previous state
			//NativeMethods.SetThreadExecutionState(previousExeState);
			//if (NativeMethods.SetThreadExecutionState(previousExeState) == 0)
			//{
			//	// No way to recover; already exiting
			//}
		}

        private void timeToRun()
        {
			if (textBoxSource.Text == "" || textBoxDest.Text == "") {
				MsgBox("Error! Inputs cannot be blank");
			} else {
				DriveDest = txtDriveDest.Text;
				DriveExtra = checkBox1.Checked;
				/*MsgBox("Here we go... " + Environment.NewLine +
					"Direct transfer: " + DirectTrans + Environment.NewLine +
					"Localdata: " + incLocaldata + Environment.NewLine +
					"Registry: " + incRegistry + Environment.NewLine +
					"Source: " + ProfileSource + Environment.NewLine +
					"Destination: " + ProfileDest + Environment.NewLine +
					"Include Drive: " + DriveExtra + Environment.NewLine +
					"Drive Source: " + DriveSource + Environment.NewLine +
					"Drive Dest: " + DriveDest);*/
				Transfer nextform = new Transfer();

				nextform.directTrans = DirectTrans;
				nextform.incLocalData = incLocaldata;
				nextform.IncRegistry = incRegistry;
				nextform.profileSource = ProfileSource;
				nextform.profileDest = ProfileDest;
				nextform.driveExtra = DriveExtra;
				nextform.driveSource = DriveSource;
				nextform.driveDest = DriveDest;

				nextform.ShowDialog();
			}
        }

		private void button1_Click(object sender, EventArgs e)
		{
			//E: \Users\rmclough\NTUSER.DAT
			//NTuserDat NTloader = new NTuserDat();
			//use profiledest to save regkeys
			//check profilesource in case we are restoring from a backup.
			//use name UserReg.txt
			//NTuserDat.Unload("TransferUser");
			MsgBox(ProfileSource);

			NTuserDat.Load(ProfileSource + @"\NTUSER.DAT", "TransferUser");

			List<string> driveLetter = new List<string>();
			List<string> drivePath = new List<string>();
			MsgBox("failpoint");

			StringBuilder outputString = new StringBuilder("");

			//RegistryKey regLocation = RegistryKey

			//string registryValue = string.Empty;
			//RegistryKey localKey = null;
			RegistryKey NetworkKey = null;
			try
			{
				NetworkKey = Registry.Users.OpenSubKey(@"TransferUser\Network");
			}
			catch
			{
				NetworkKey = Registry.CurrentUser.OpenSubKey("Network");
			}
			MsgBox(NetworkKey.ToString());

			foreach (string subkey in NetworkKey.GetSubKeyNames())
			{
				var tmp = Registry.GetValue( NetworkKey + @"\" + subkey, "RemotePath", null);

				driveLetter.Add(subkey);
				drivePath.Add(tmp.ToString());

				outputString.Append(subkey + Environment.NewLine + tmp.ToString() + Environment.NewLine);
			}

			List<string> FileOut = new List<string>();

			FileOut.Add("Dim objNetwork");
			FileOut.Add("Set objNetwork = WScript.CreateObject(\"WScript.Network\")");

			for (int i = 0; i < driveLetter.Count; i++ )
			{
				//iveSettings.MapNetworkDrive(driveLetter[i], drivePath[i]);
				//File.AppendText("NetworkDrives.txt", driveLetter[i] + " " + drivePath[i]);
				FileOut.Add("objNetwork.MapNetworkDrive " + driveLetter[i] + ", " + drivePath[i] + ", true");
				outputString.Append(driveLetter[i] + " " + drivePath[i] + Environment.NewLine);
				//i++;
			}

			MsgBox(outputString.ToString() + driveLetter.Count);

			File.AppendAllLines("NetworkDrives.vbs", FileOut);

			//DriveSettings.MapNetworkDrive("L", @"\\CSDWP-SUPWS13\JSWShare");*/
			/*Thread.Sleep(1000);

			NTuserDat.Unload("TransferUser");

			Thread.Sleep(1000);

			NTuserDat.Unload("TransferUser");//*/


		}

		public string Read(string KeyName)
		{
			// Opening the registry key
			RegistryKey rk = Registry.LocalMachine;
			// Open a subKey as read-only
			RegistryKey sk1 = rk.OpenSubKey(@"TransferUser\Network");
			// If the RegistrySubKey doesn't exist -> (null)
			if (sk1 == null)
			{
				return null;
			}
			else
			{
				try
				{
					// If the RegistryKey exists I get its value
					// or null is returned.
					return (string)sk1.GetValue(KeyName.ToUpper());
				}
				catch (Exception e)
				{
					// AAAAAAAAAAARGH, an error!
					MessageBox.Show("Reading registry " + KeyName.ToUpper() + " " + e.ToString());
					return null;
				}
			}
		}

	}
	//internal static class NativeMethods
	//{
	//	// Import SetThreadExecutionState Win32 API and necessary flags
	//	[DllImport("kernel32.dll")]
	//	public static extern uint SetThreadExecutionState(uint esFlags);
	//	public const uint ES_CONTINUOUS = 0x80000000;
	//	public const uint ES_SYSTEM_REQUIRED = 0x00000001;
	//}
	public class PowerHelper
	{
		public static void ForceSystemAwake()
		{
			NativeMethods.SetThreadExecutionState(NativeMethods.EXECUTION_STATE.ES_CONTINUOUS |
												  NativeMethods.EXECUTION_STATE.ES_DISPLAY_REQUIRED |
												  NativeMethods.EXECUTION_STATE.ES_SYSTEM_REQUIRED |
												  NativeMethods.EXECUTION_STATE.ES_AWAYMODE_REQUIRED);
		}

		public static void ResetSystemDefault()
		{
			NativeMethods.SetThreadExecutionState(NativeMethods.EXECUTION_STATE.ES_CONTINUOUS);
		}
	}

	internal static partial class NativeMethods
	{
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

		[FlagsAttribute]
		public enum EXECUTION_STATE : uint
		{
			ES_AWAYMODE_REQUIRED = 0x00000040,
			ES_CONTINUOUS = 0x80000000,
			ES_DISPLAY_REQUIRED = 0x00000002,
			ES_SYSTEM_REQUIRED = 0x00000001

			// Legacy flag, should not be used.
			// ES_USER_PRESENT = 0x00000004
		}
	}




	
}
