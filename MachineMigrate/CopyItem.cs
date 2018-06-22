using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MachineMigrate
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
        public string Target { get; set; }
        public long Size { get; private set; }

        public void SetSource(string source)
        {
            Source = source;

            try
            {
                Target = source.Replace(FormMain.OldHost.DrivePath, FormMain.NewHost.DrivePath);
            }
            catch (Exception)
            {
                Console.WriteLine("Target not set for " + Source);
            }
            

            //try
            //{
            //    Size = Extensions.GetAllDirectorySize(Source);
            //}
            //catch (Exception)
            //{
            //    try
            //    {
            //        Size = Extensions.GetFileSize(Source);
            //    }
            //    catch (Exception)
            //    {
            //        Size = 1;
            //    }
            //}
            
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

        private int retryCount = 0;

        private void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            try
            {
                Directory.CreateDirectory(target.FullName);

                // Copy each file into the new directory.
                foreach (FileInfo fi in source.GetFiles())
                {
                    try
                    {
                        var destFileName = Path.Combine(target.FullName, fi.Name);

                        //Console.WriteLine(fi.FullName + " to " + destFileName);
                        if (TargetFileIsNewer(fi.FullName, destFileName))
                        {
                            //TargetFileIsNewer -- do nothing
                            Log.Add(destFileName + " -- newer already exists. Skipping");
                        }
                        else
                        {
                            fi.CopyTo(destFileName, true);
                        }
                    }
                    catch (Exception ef)
                    {
                        Log.Add("Copy" + fi + "...Failed!" + Environment.NewLine +
                        ef.Message);
                        throw;
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
                        Log.Add("Copy " + diSourceSubDir + "...Failed!" + Environment.NewLine +
                        e2.Message);
                    }

                }

                retryCount = 0;
            }
            catch (Exception ex)
            {
                if (!ex.Message.ContainsIgnoreCase("denied"))
                {
                    Log.Add("Connectivity lost... retrying...");
                    Log.Add(ex.Message);

                    if (retryCount < 6)
                    {
                        Thread.Sleep(10000);
                        retryCount++;
                        CopyAll(source, target);
                    }
                    else
                    {
                        Log.Add("Number of retries exceeded. Fix the problem then try again.");
                        return;
                    } 
                }
                
            }

        }

        public static bool TargetFileIsNewer(string SourceFile, string TargetFile)
        {
            if (File.Exists(SourceFile) && File.Exists(TargetFile))
            {
                var CompareInt = DateTime.Compare(File.GetLastWriteTime(SourceFile), File.GetLastWriteTime(TargetFile));

                if (CompareInt == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
