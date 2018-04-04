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
    public class ExtensionsTests
    {
        [TestMethod()]
        public void ContainsIgnoreCaseTest()
        {
            var source = @"This is a string\Folder";
            var target = @"\folder";

            Assert.IsTrue(source.ContainsIgnoreCase(target));
        }
    }
}