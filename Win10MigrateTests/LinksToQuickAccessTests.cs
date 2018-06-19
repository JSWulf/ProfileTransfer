using Microsoft.VisualStudio.TestTools.UnitTesting;
using Win10Migrate;
using System;
using Microsoft.CSharp.RuntimeBinder;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Win10Migrate.Tests
{
    [TestClass()]
    public class LinksToQuickAccessTests
    {
        [TestMethod()]
        public void GetLinksTest()
        {
            //var links = new DirectoryInfo(@"C:\Users\jwulf\Links");

            //Console.WriteLine("test");

            var shell32 = new Shell32.Shell();
            var nl = Environment.NewLine;

            foreach (var file in Directory.GetFiles(@"C:\Users\jwulf\Links"))
            {
                if (file.EndsWith(".lnk"))
                {
                    
                    Console.WriteLine("#newfile: " + file);
                    try
                    {
                        //var lnkPath = Path.GetFullPath(file);
                        var dir = shell32.NameSpace(Path.GetDirectoryName(file));
                        var itm = dir.Items().Item(Path.GetFileName(file));
                        var lnk = (Shell32.ShellLinkObject)itm.GetLink;
                        var lnkpth = lnk.Target.Path;
                        Console.WriteLine(dir + nl + itm + nl + lnk + nl + lnkpth);
                    }
                    catch (Exception) { };
                    Console.WriteLine("#endfile"); 
                }
            }
        }
    }
}