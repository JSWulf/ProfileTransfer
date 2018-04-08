using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10Migrate
{
    public static class Exceptions
    {
        public static List<string> ProfileFiles = new List<string>()
        {
            "ntuser.ini",
            "ntuser.dat",
            "ntuser.pol",

        };
        public static List<string> ProfileFolders = new List<string>()
        {
            "Application Data",
            "Local Settings",
            "My Documents",
            "My Music",
            "Searches",
            "Cookies",
            "NetHood",
            "PrintHood",
            "Recent",
            "SendTo",
            "Start Menu",
            "Templates",
            "IntelGraphicsProfiles",
            "cisco",
            ".dnx",
            ".oracle_jre_usage",
            ".vscode",
            "Saved Games",
            "ProfileTransferLogs"

        };

        public static List<string> FileTypes = new List<string>()
        {
            ".mp4",
            ".wma",
            ".mov",
            ".avi"

        };
    }
}
