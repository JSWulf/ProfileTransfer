using Microsoft.VisualStudio.TestTools.UnitTesting;
using Win10Migrate;
using System;
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

            foreach (var file in Directory.GetFiles(@"C:\Users\jwulf\"))
            {
                try
                {
                    Console.WriteLine("test");
                } catch (Exception) { };
            }
        }
    }
}