using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMigrate
{
    public class CopyList : FormMain
    {
        public CopyList()
        {
            CopyItems = new List<CopyItem>();
            //MainStart();
        }
        public CopyList(string ExtraFolder)
        {
            CopyItems = new List<CopyItem>
            {
                new CopyItem(ExtraFolder)
            };
            //MainStart();
        }
        public CopyList(List<string> ExtraFolders)
        {
            CopyItems = new List<CopyItem>();

            foreach (var item in ExtraFolders)
            {
                CopyItems.Add(new CopyItem(item));
            }

            //MainStart();
        }

        public void MainStart()
        {
            var oldUserRoot = OldHost.Path + @"Users\" + OldHost.UserName;
            Log.LogFile = NewHost.Path + @"Users\" + NewHost.UserName + @"\Win10Migration" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".log";

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
            Log.Add("Total size of things to copy: " + TotalSize);

            foreach (var item in CopyItems)
            {
                Log.Add(item.Copy());

                TotalSize =- item.Size;
                Log.Add("Total size remaining: " + TotalSize);
            }
            ///////////////////////////////////////////End Copy


            Console.WriteLine("Migration complete at: " + Log.TimeStamp() + " Press ENTER to exit...");
            Console.ReadLine();
            
        }

        private void AddItem(string subitem)
        {
            var newfolder = new CopyItem(subitem);

            Log.Add("Adding: " + subitem);

            CopyItems.Add(newfolder);

            TotalSize += newfolder.Size;
        }

        public List<CopyItem> CopyItems { get; set; }

        

    }


}
