using Microsoft.VisualStudio.TestTools.UnitTesting;
using Win10Migrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10Migrate.Tests
{
    [TestClass()]
    public class CopyItemTests
    {
        [TestMethod()]
        public void CopyTest()
        {
            Log.LogFile = @"C:\Localdata\TestCopy\testcopy.log";
            CopyItem copyItem = new CopyItem(@"C:\Localdata\ComputerSetup");
            copyItem.Target = @"C:\Localdata\TestCopy";

            Console.WriteLine(copyItem.Copy());

            Assert.Inconclusive();
        }

        [TestMethod()]
        public void TargetFileIsNewerTest()
        {
            var source = @"C:\Localdata\ComputerSetup\output.vbs";
            var target = @"C:\Localdata\TestCopy\output.vbs";

            Assert.IsTrue(CopyItem.TargetFileIsNewer(source, target));
        }
    }
}