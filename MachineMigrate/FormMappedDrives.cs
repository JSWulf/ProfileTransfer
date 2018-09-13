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

namespace MachineMigrate
{
    public partial class FormMappedDrives : Form
    {
        public FormMappedDrives()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //copy getmappeddrives to c:\localdata
            try
            {
                var path = @"\\" + textBox1.Text + @"\C$\Localdata\";
                File.WriteAllBytes(path + "GetMappedDrives.exe", Properties.Resources.GetMappedDrives);

                MessageBox.Show("GetMappedDrives.exe has been coppied to " + path + Environment.NewLine +
                    "Have the user run the file while logged onto " + textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var filename = FormMain.StartPath + @"\GetMappedDrives.exe";
                if (!File.Exists(filename))
                {
                    File.WriteAllBytes(filename, Properties.Resources.GetMappedDrives);
                }
                Process.Start(filename, textBox2.Text);

                MessageBox.Show("Don't forget to unload the hive from regedit!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var filename = FormMain.StartPath + @"\Retrieving mapped drives when old computer is not working.pdf";
            if (!File.Exists(filename))
            {
                File.WriteAllBytes(filename, Properties.Resources.Retrieving_mapped_drives_when_old_computer_is_not_working);
            }
            Process.Start(filename);
        }

        private void FormMappedDrives_Load(object sender, EventArgs e)
        {
            textBox1.Text = FormMain.OldHost.Hostname;
        }
    }
}
