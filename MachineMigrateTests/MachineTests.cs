using Microsoft.VisualStudio.TestTools.UnitTesting;
using MachineMigrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMigrate.Tests
{
    [TestClass()]
    public class MachineTests
    {
        Machine machine = new Machine();

        [TestMethod()]
        public void MachineTest()
        {
            machine.ProfileSource = (@"Users\jwulf");

            Console.WriteLine(machine.ProfileSource);
            Console.WriteLine(machine.UserName);
        }

        [TestMethod()]
        public void MachineTest1()
        {
            machine.ProfileSource = (@"test\jwulf");
            machine.UserName = (@"a-jwulf");

            Console.WriteLine(machine.ProfileSource);
            Console.WriteLine(machine.UserName);
        }

        [TestMethod()]
        public void CheckHostTest()
        {

        }
    }
}