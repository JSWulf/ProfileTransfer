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
            
            long fileOutput = 0;
            foreach (string name in Directory.GetFiles(folder))
            {
                FileInfo info = new FileInfo(name);
                fileOutput += info.Length;
            }
            return fileOutput;
        }
    
        public static bool ContainsIgnoreCase(this String baseString, string Compare)
        {
            if (baseString.IndexOf(Compare, StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool EndsWithIgnoreCase(this String baseString, string Compare)
        {
            if (baseString.EndsWith(Compare, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
