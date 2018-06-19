using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MachineMigrate
{
    static public class Log
    {
        //static public string LogFile { get; set; }
        static private string logFile;

        static public string LogFile
        {
            get { return logFile; }
            set {
                logFile = value;
                Directory.CreateDirectory(Path.GetDirectoryName(logFile));
                File.WriteAllText(logFile, "Log started at: " + TimeStamp() + Environment.NewLine);
            }
        }


        static public void Add(string Line)
        {
            var LineStamp = TimeStamp() + "   " + Line + Environment.NewLine;
            try
            {
                File.AppendAllText(LogFile, LineStamp);
            }
            catch (Exception le)
            {
                Console.WriteLine("Unable to write to log file... " + le.Message);
            }
            
            Console.WriteLine(TimeStamp() + "   " + Line);
        }

        static public string TimeStamp()
        {
            return DateTime.Now.ToString("[yyyy-MM-dd-HH:mm:ss]");
        }
    }
}
