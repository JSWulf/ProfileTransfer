﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMigrate
{
    public static class ProfileAdditions
    {
        static string local = @"\AppData\Local\";
        static string roam = @"\AppData\Roaming\";

        public static List<string> AppDataFolders = new List<string>()
        {
            //local + @"Microsoft\OneNote",
            //local + @"Microsoft\Outlook",
            roam + @"Microsoft\Signatures",
            roam + @"Microsoft\Templates",
            roam + @"Microsoft\Outlook",
            roam + @"Microsoft\OneNote",
            roam + @"Microsoft\Sticky Notes",
            local + @"Microsoft",
            local + @"Google\Chrome\User Data\Default",
            roam + @"Mozilla\Firefox"
        };
    }
}
