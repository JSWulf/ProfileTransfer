using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10Migrate
{
    public static class Extensions
    {

        public static long GetAllDirectorySize(string folder)
        {
            long output = 0;

            foreach (var dir in Directory.GetDirectories(folder))
            {
                try
                {
                    output += GetAllDirectorySize(dir);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

            
            output += GetAllFileSize(folder);
            

            return output;
        }

        public static long GetAllFileSize(string folder)
        {
            // 1.
            // Get array of all file names.
            //string[] a = Directory.GetFiles(folder, "*.*");

            // 2.
            // Calculate total bytes of all files in a loop.
            long fileOutput = 0;
            foreach (string name in Directory.GetFiles(folder))
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                fileOutput += info.Length;
            }
            // 4.
            // Return total size
            return fileOutput;
        }
    }
}
