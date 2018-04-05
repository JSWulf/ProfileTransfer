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
        public void GetDirectorySizeTest()
        {
            var result = Extensions.GetAllFileSize(@"C:\Users\Jwulf");
            Console.WriteLine(result / 1000000 + " MB");

            Assert.IsTrue(result != 0);
        }

        [TestMethod()]
        public void GetAllDirectorySizeTest()
        {
            var result = Extensions.GetAllDirectorySize(@"C:\Users\Jwulf");
            Console.WriteLine(result / 1000000 + " MB" + Environment.NewLine +
                result/1000000000 + " GB");

            Assert.IsTrue(result > 0);
        }
    }
}
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