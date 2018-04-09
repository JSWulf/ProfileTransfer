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
    public class LogTests
    {
        [TestMethod()]
        public void TimeStampTest()
        {
            //var result = Log.TimeStamp();
            Console.WriteLine(Log.TimeStamp());
        }

        [TestMethod()]
        public void LogAddTest()
        {
            Log.LogFile = @"C:\localdata\testlogfile.log";

            Log.Add("test line");

            Assert.Inconclusive();
        }
    }
}