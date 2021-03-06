﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMigrate
{
    public class Startremove
    {
        string NL = Environment.NewLine;

        static void SubMain(string[] args)
        {
            bool Sent = false;

            if (args.Length > 1)
            {
                
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i].Contains(':'))
                    {
                        var argsplit = args[i].Split(':');

                        switch (argsplit[0])
                        {
                            case @"/h": //set hostname
                            case @"/H":
                                HostName = argsplit[1];
                                break;
                            case @"/sent": //we've been sent
                                Sent = true;
                                break;
                            case @"/u": //set username
                            case @"/U":
                            case @"/user":
                            case @"/User":
                            case @"/USER":
                                UserName = argsplit[1];
                                break;
                            case @"/old": //set username
                            case @"/Old":
                            case @"/OLD":
                                try { OldHost = new Machine(argsplit[1]); } catch (Exception) { }
                                break;
                            case @"/new": //set username
                            case @"/New":
                            case @"/NEW":
                                try { NewHost = new Machine(argsplit[1]); } catch (Exception) { }
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(HostName))
                        {
                            HostName = args[i];
                        }
                        else if (string.IsNullOrEmpty(UserName))
                        {
                            UserName = args[i];
                        }
                    }


                }

                //try { } catch (Exception) { }
            }
            else
            {
                HostName = Environment.MachineName;
                UserName = Environment.UserName;

            }

            //// skip prompts and just run.
            if (Sent)
            {
                var clist = new CopyList(OldHost.DrivePath + "Localdata");
                clist.MainStart();

                return;
            }

            //Console.WriteLine("we got: " + HostName + " " + UserName + " ");
            if (OldHost == null || NewHost == null || UserName == null)
            {
                MainMenu();
            } else
            {
                GetStarted();
            }
            //Console.ReadLine();

        }

        public static string HostName { get; set; }

        public static string UserName { get; set; }

        public static Machine OldHost { get; set; }
        public static Machine NewHost { get; set; }

        public static long TotalSize { get; set; }

        public static void MainMenu()
        {

            try
            {
                var nHost = Prompt("New host [" + HostName + "]: ", HostName);
                var oHost = Prompt("Old host: ", null);

                NewHost = new Machine(nHost);
                OldHost = new Machine(oHost);

                Console.WriteLine("Type '?' to see list of users...");
                UserName = Prompt("Username [" + UserName + "]: ", UserName);

                if (UserName.Contains('?'))
                {
                    UserName = SelectUser();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Retry? [Y/N]: ");

                var retry = Console.ReadLine();
                if (string.Equals(retry,"y", StringComparison.InvariantCultureIgnoreCase))
                {
                    MainMenu();
                    return;
                } else
                {
                    Console.WriteLine("Press ENTER to exit...");
                    Console.ReadLine();
                    return;
                }
                
            }

            GetStarted();
        }

        private static void GetStarted()
        {
            var nl = Environment.NewLine;
            var tb = "	";

            Console.WriteLine("You inputed: " + nl +
                "    New Host" + tb + "=" + tb + NewHost.Hostname + nl +
                "    Old Host" + tb + "=" + tb + OldHost.Hostname + nl +
                "    User name" + tb + "=" + tb + UserName + nl);
            Console.Write("Continue? (Y/N) [Y]: ");

            var cont = Console.ReadLine();
            if (cont.ContainsIgnoreCase("y") || string.IsNullOrEmpty(cont))
            {
                
                Console.Write("Send to run on (Type 'skip' to skip) [" + NewHost.Hostname + "]: ");
                var Send = Console.ReadLine();

                if (string.IsNullOrEmpty(Send))
                {
                    try
                    {
                        CopyAndRun(NewHost.Hostname);
                    }
                    catch (Exception se)
                    {
                        Console.WriteLine(se.Message);
                        GetStarted();
                    }
                }
                else if (!Send.ContainsIgnoreCase("skip"))
                {
                    try
                    {
                        CopyAndRun(Send);
                    }
                    catch (Exception s)
                    {
                        Console.WriteLine(s.Message);
                        GetStarted();
                    }
                }
                else
                {
                    /////////////////////////////////////
                    var clist = new CopyList(OldHost.DrivePath + "Localdata");
                    clist.MainStart();
                    /////////////////////////////////////
                }
            }
            else
            {
                Console.Write("Restart? (Y/N) [N]: ");
                var restart = Console.ReadLine();
                if (restart.ContainsIgnoreCase("n") || string.IsNullOrEmpty(restart))
                {
                    Console.WriteLine("Press ENTER to exit...");
                    Console.ReadLine();
                }
                else
                {
                    MainMenu();
                }
            }
        }

        private static string SelectUser()
        {
            var output = new List<string>();
            if (Directory.Exists(OldHost.DrivePath))
            {
                foreach (var folder in Directory.GetDirectories(OldHost.DrivePath + @"Users\"))
                {
                    if (!folder.ContainsIgnoreCase("Default User") &&
                        !folder.ContainsIgnoreCase("All Users") &&
                        !folder.ContainsIgnoreCase("nimda") &&
                        !folder.ContainsIgnoreCase("Public") &&
                        !folder.ContainsIgnoreCase("Coach"))
                    {
                        output.Add(Path.GetFileName(folder));
                        //Console.WriteLine(Path.GetFileName(folder));
                    }
                    
                }
            }
            else { throw new Exception("Could not connect to " + OldHost.Hostname); }

            
            for (int i = 0; i < output.Count; i++)
            {
                Console.WriteLine("    " + i + ": " + output[i]);
            }
            Console.WriteLine("Enter coresponding number for user: ");

            try
            {
                int u = Convert.ToInt16(Console.ReadLine());

                return output[u];
            }
            catch (Exception)
            {
                Console.WriteLine("Could not understand your entry. Retry:");
                return SelectUser();
            }
            

            
        }

        private static string Prompt(string Message, string Default)
        {
            Console.Write(Message);
            var input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input) || string.IsNullOrEmpty(input))
            {
                return Default;
            }
            else
            {
                return input.Trim();
            }
            
        }

        private static void CopyAndRun(string TargetHost)
        {
            var Assembly = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            var destDrive = @"\\" + TargetHost + @"\C$\";
            var destPath = @"ProgramData\win10migrate\";
            var destName = "win10migrate.exe";
            var fullDest = destDrive + destPath + destName;

            if (Directory.Exists(destDrive))
            {
                Directory.CreateDirectory(destDrive + destPath);

                //Console.WriteLine(Assembly);
                File.Copy(Assembly, fullDest, true);
            } else { throw new Exception("Destination does not exist"); }

            //run with /old: /new: /u: /sent:true
            PsExec.Run(TargetHost, 
                @"C:\" + destPath + destName +
                " /old:" + OldHost.Hostname + " /new:" + NewHost.Hostname + " /u:" + UserName + " /sent:true", 
                true);
            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }

        //just to test getting list
        public static string GetProfileItems(string source)
        {
            var output = new StringBuilder();

            foreach (var file in Directory.GetFiles(source))
            {
                output.Append(file + Environment.NewLine);
            }

            foreach (var folder in Directory.GetDirectories(source))
            {
                output.Append(folder + Environment.NewLine);
            }

            return output.ToString();
        }
    }
}
