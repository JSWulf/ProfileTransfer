using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10Migrate
{
    public class CopyList : Start
    {
        public CopyList()
        {
            CopyItems = new List<CopyItem>();
            MainStart();
        }
        public CopyList(string ExtraFolder)
        {
            CopyItems = new List<CopyItem>
            {
                new CopyItem(ExtraFolder)
            };
            MainStart();
        }
        public CopyList(List<string> ExtraFolders)
        {
            CopyItems = new List<CopyItem>();

            foreach (var item in ExtraFolders)
            {
                CopyItems.Add(new CopyItem(item));
            }

            MainStart();
        }

        private void MainStart()
        {
            var oldUserRoot = OldHost.Path + @"Users\" + UserName;
            Log.LogFile = NewHost.Path + @"Users\" + UserName + @"\Win10Migration" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";
            //add user profile files and folders
            foreach (var folder in Directory.GetDirectories(oldUserRoot))
            {
                if (!Exceptions.ProfileFolders.ListContains(folder))
                {
                    CopyItems.Add(new CopyItem(folder));
                }
            }

            foreach (var file in Directory.GetFiles(oldUserRoot))
            {
                if (!Exceptions.ProfileFiles.ListContains(file))
                {
                    CopyItems.Add(new CopyItem(file));
                }
            }

            foreach (var line in ProfileAdditions.AppDataFolders)
            {
                if (Directory.Exists(oldUserRoot + line))
                {
                    CopyItems.Add(new CopyItem(oldUserRoot + line));
                }
            }

            foreach (var item in CopyItems)
            {
                Console.WriteLine(item.Source);
                Console.WriteLine(item.Target);
            }
            Console.ReadLine();
        }


        public List<CopyItem> CopyItems { get; set; }


        private void GetUserFiles()
        {

        }

    }


}
