﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10Migrate
{
    public class CopyItem
    {
        public CopyItem()
        {

        }
        public CopyItem(string source)
        {
            SetSource(source);
        }


        public string Source { get; private set; }
        public string Target { get; private set; }
        public long Size { get; private set; }

        public void SetSource(string source)
        {
            Source = source;

            try
            {
                Target = source.Replace(CopyList.OldHost.Path, CopyList.NewHost.Path);
            }
            catch (Exception)
            {
                Console.WriteLine("Target not set for " + Source);
            }
            

            try
            {
                Size = Extensions.GetAllDirectorySize(Source);
            }
            catch (Exception)
            {
                try
                {
                    Size = Extensions.GetFileSize(Source);
                }
                catch (Exception)
                {
                    Size = 1;
                }
            }
            
        }

        public string Copy()
        {
            try
            {
                if (Directory.Exists(Source))
                {
                    CopyDirectory();
                }
                else
                {
                    File.Copy(Source, Target);
                }
                return "Copy " + Source + " ...Completed.";
            }
            catch (Exception e)
            {
                return "Copy" + Source + "...Failed!" + Environment.NewLine +
                    e.Message;
            }
            

        }


        private void CopyDirectory()
        {
            //string sourceDirectory, string targetDirectory
            DirectoryInfo diSource = new DirectoryInfo(Source);
            DirectoryInfo diTarget = new DirectoryInfo(Target);

            CopyAll(diSource, diTarget);
        }

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                //Log.Add(@"Copying " + target.FullName + "\\" + fi.Name);
                try
                {
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                }
                catch (Exception ef)
                {
                    Log.Add("Copy" + fi + "...Failed!" + Environment.NewLine +
                    ef.Message);
                }
                
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                try
                {
                    DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                    CopyAll(diSourceSubDir, nextTargetSubDir);
                }
                catch (Exception e2)
                {
                    Log.Add("Copy" + diSourceSubDir + "...Failed!" + Environment.NewLine +
                    e2.Message);
                }
                
            }
        }
    }
}
