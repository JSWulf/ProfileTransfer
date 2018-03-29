using System;
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
        public string Hostname { get; set; }
        public bool IsLocal { get; set; }

        private string getUser()
        {
            return Start.UserName;
        }
    }
}
