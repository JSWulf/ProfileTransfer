using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Win10Migrate
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
                File.WriteAllText(logFile, "Log started at: " + TimeStamp() + Environment.NewLine);
            }
        }


        static public void Add(string Line)
        {
            var LineStamp = TimeStamp() + "   " + Line + Environment.NewLine;
            File.AppendAllText(LogFile, LineStamp);
            Console.WriteLine(TimeStamp() + "   " + Line);
        }

        static public string TimeStamp()
        {
            return DateTime.Now.ToString("[yyyy-MM-dd-HH:mm:ss]");
        }
    }
}
