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
    public class PSEXECTests
    {
        [TestMethod()]
        public void RunTest()
        {
            PsExec.Run("LT491027", "", true);
        }
    }
}