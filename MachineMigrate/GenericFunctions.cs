using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMigrate
{
    static public class GenericFunctions
    {
        static public string NoHostPath(string input)
        {
            string output = null;
            if (input.StartsWith(@"\\"))
            {
                output = input.Remove(0, 2);
            }

            return output.Remove(0, output.IndexOf('\\'));
        }
    }
}
