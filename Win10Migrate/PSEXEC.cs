using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Win10Migrate
{
    public static class PsExec
    {
        public static string Run(string host, string command)
        {
            return Run(host, command, false);
        }
        public static string Run(string host, string command, bool waitForExit)
        {
            var completeCommand = @" \\" + host + " " + command;

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = @"C:\Windows\SysNative\PSEXEC.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                //Arguments = " /c " + Command
                Arguments = completeCommand
            };
            Process execute = new Process
            {
                StartInfo = startInfo
            };

            Console.WriteLine("executing: " + completeCommand);

            execute.Start();

            if (waitForExit == true)
            {
                execute.WaitForExit();
            }

            return execute.StandardOutput.ReadToEnd() + Environment.NewLine + execute.StandardError.ReadToEnd();

        }
    }
}
