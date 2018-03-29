using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10Migrate
{
    class Start
    {
        static void Main(string[] args)
        {
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
                            case @"/u": //set username
                            case @"/U":
                                UserName = argsplit[1];
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

                
            }
            else
            {
                HostName = Environment.MachineName;
                UserName = Environment.UserName;

            }

            //Console.WriteLine("we got: " + HostName + " " + UserName + " ");
            MainMenu();

            //Console.ReadLine();

        }

        public static string HostName { get; set; }

        public static string UserName { get; set; }

        public static Machine OldHost { get; set; }
        public static Machine NewHost { get; set; }

        public static void MainMenu()
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

            

            Console.WriteLine("You inputed: " + oHost);

            Console.ReadLine();
        }

        private static string SelectUser()
        {
            if (Directory.Exists(""))
            {

            }
            else { throw new Exception("Could not connect to " + OldHost.Hostname); }

            return "";
        }

        private static string Prompt(string Message, string Default)
        {
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
    }
}
