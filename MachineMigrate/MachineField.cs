using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineMigrate
{
    public class MachineField
    {
        public MachineField(string name, Machine machine, CheckBox islocal, TextBox host, ComboBox drive,
            ComboBox profile, TextBox localdata, Button browse, Button localbrowse, PictureBox connect, Label pathlabel)
        {
            MachineFieldSet(name, machine, islocal, host, drive, profile, localdata, browse, localbrowse, connect, pathlabel, null);
        }
        public MachineField(string name, Machine machine, CheckBox islocal, TextBox host, ComboBox drive, 
            ComboBox profile, TextBox localdata, Button browse, Button localbrowse, PictureBox connect, Label pathlabel,
            CheckBox cklocaldata)
        {
            MachineFieldSet(name, machine, islocal, host, drive, profile, localdata, browse, localbrowse, connect, pathlabel, cklocaldata);
        }
        private void MachineFieldSet(string name, Machine machine, CheckBox islocal, TextBox host, 
            ComboBox drive, ComboBox profile, TextBox localdata, Button browse, Button localbrowse, PictureBox connect, 
            Label pathlabel, CheckBox cklocaldata)
        {
            Name = name;
            Machine = machine;
            IsLocal = islocal;
            Host = host;
            DriveLetter = drive;
            Profile = profile;
            LocalData = localdata;
            Browse = browse;
            LocalBrowse = localbrowse;
            ConnectStatus = connect;
            PathLabel = pathlabel;
            CkLocalData = cklocaldata;

            SetEvents();
        }

        public string Name { get; set; }
        public Machine Machine { get; set; }
        public ComboBox DriveLetter { get; set; }
        public TextBox Host { get; set; }
        public ComboBox Profile { get; set; }
        public CheckBox IsLocal { get; set; }
        public CheckBox CkLocalData { get; set; }
        public Label PathLabel { get; set; }
        public TextBox LocalData { get; set; }
        public Button Browse { get; set; }
        public Button LocalBrowse { get; set; }
        public PictureBox ConnectStatus { get; set; }

        private void SetEvents()
        {

            Browse.Click += BrowseFolder;
            LocalBrowse.Click += LocalBrowseFolder;

            Host.LostFocus += Machine.CheckHost;
            //IsLocal.CheckedChanged += Machine.CheckHost;
            Machine.ConnectivityChanged += UpdatePicture;
            Machine.PathChanged += UpdatePath;


            IsLocal.CheckedChanged += new EventHandler(delegate (Object o, EventArgs ea)
            {
                Machine.IsLocal = IsLocal.Checked;
                if (Machine.IsLocal)
                {
                    SetUsers();
                    DriveLetter.Items.Clear();
                    Machine.ConnectionState = 100;
                    foreach (var item in Environment.GetLogicalDrives())
                    {
                        if (!item.StartsWith("H"))
                        {
                            DriveLetter.Items.Add(item[0].ToString());
                        }
                    }
                }
            });

            Host.TextChanged += new EventHandler(delegate (Object o, EventArgs ea)
            {
                Machine.Hostname = Host.Text;
            });

            DriveLetter.TextChanged += new EventHandler(delegate (Object o, EventArgs ea)
            {
                Machine.DriveLetter = DriveLetter.Text;
            });

            Profile.TextChanged += new EventHandler(delegate (Object o, EventArgs ea)
            {
                Machine.ProfileSource = Profile.Text;
            });

            LocalData.TextChanged += new EventHandler(delegate (Object o, EventArgs ea)
            {
                Machine.LocalData = LocalData.Text;
            });

        }

        private void UpdatePath(object sender, EventArgs e)
        {
            PathLabel.Text = Machine.FullPath;
            if (Host.Text != Machine.Hostname) { Host.Text = Machine.Hostname; }
            if (DriveLetter.Text != Machine.DriveLetter) { DriveLetter.Text = Machine.DriveLetter; }
            if (Profile.Text != Machine.ProfileSource) { Profile.Text = Machine.ProfileSource; }
            if (IsLocal.Checked != Machine.IsLocal) { IsLocal.Checked = Machine.IsLocal; }
        }

        private void UpdatePicture(object sender, EventArgs e)
        {
            switch (Machine.ConnectionState)
            {
                case 0:
                    ConnectStatus.Image = Properties.Resources.Minus_Grey;
                    break;
                case 50:
                    ConnectStatus.Image = Properties.Resources.Error_red;
                    break;
                case 100:
                    ConnectStatus.Image = Properties.Resources.Tick_Green;
                    SetUsers();
                    break;
                default:
                    break;
            }

        }

        private void BrowseFolder(object sender, EventArgs e)
        {
            var result = GetBrowserFolder(Machine.FullPath);

            if (!string.IsNullOrEmpty(result))
            {
                if (result.Contains(@"\\"))
                {
                    Machine.IsLocal = false;
                    var noSlashes = result.Remove(0, 2);
                    Machine.Hostname = noSlashes.Remove(noSlashes.IndexOf('\\'));
                }
                else
                {
                    Machine.IsLocal = true;
                    Machine.Hostname = "Localhost";
                }

                //txtUdt.Text = result;
                if (Machine.IsLocal)
                {
                    Machine.DriveLetter = result[0].ToString();
                    Machine.ProfileSource = result.Remove(0, 3);
                }
                else
                {
                    int d = result.IndexOf('$');
                    Machine.DriveLetter = result[d - 1].ToString();
                    Machine.ProfileSource = result.Remove(0, d + 2);
                }

            }

            //throw new NotImplementedException();
        }
        private void LocalBrowseFolder(object sender, EventArgs e)
        {
            var result = GetBrowserFolder(Machine.DrivePath + Machine.LocalData);

            if (!string.IsNullOrEmpty(result))
            {

                //txtUdt.Text = result;
                LocalData.Text = result;

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

            return null;
        }

        public void SetUsers()
        {
            Profile.Items.Clear();
            try
            {
                Profile.Items.AddRange(Machine.GetUsers(Machine.DrivePath + "Users"));
            }
            catch (Exception)
            {
            }

            //Profile.Items.Equals(Machine.GetUsers(Machine.DrivePath + "Users"));
        }
    }
}
