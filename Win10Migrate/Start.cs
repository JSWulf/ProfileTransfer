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
        string NL = Environment.NewLine;

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



            var nl = Environment.NewLine;
            var tb = "	";

            Console.WriteLine("You inputed: " + nl + 
                "    New Host" + tb + "=" + tb + NewHost.Hostname + nl +
                "    Old Host" + tb + "=" + tb + OldHost.Hostname + nl +
                "    User name" + tb + "=" + tb + UserName + nl +
                "Press ENTER to exit...");

            Console.ReadLine();
        }

        private static string SelectUser()
        {
            var output = new List<string>();
            if (Directory.Exists(OldHost.Path))
            {
                foreach (var folder in Directory.GetDirectories(OldHost.Path + @"Users\"))
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
    }
}
