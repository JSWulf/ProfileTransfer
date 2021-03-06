﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10Migrate
{
    public class Machine
    {
        public Machine(string Host)
        {
            Hostname = Host;
        }

        public string ProfileSource { get; set; }
        private string hostname;

        public string Hostname
        {
            get { return hostname; }
            set {
                hostname = value;
                if (string.Equals(value, Environment.MachineName, StringComparison.InvariantCultureIgnoreCase))
                {
                    IsLocal = true;
                } else { IsLocal = false; }
            }
        }

        private bool IsLocal { get; set; }

        private string getUser()
        {
            return Start.UserName;
        }
        
        public string Path
        {
            get {
                if (IsLocal)
                {
                    return @"C:\";
                }
                else
                {
                    return @"\\" + Hostname + @"\C$\";
                }
            }
            set {  }
        }

    }
}
