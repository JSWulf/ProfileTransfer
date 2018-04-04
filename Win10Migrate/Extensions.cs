using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10Migrate
{
    public static class Extensions
    {
        public static bool ContainsIgnoreCase(this String baseString, string Compare)
        {
            if (baseString.IndexOf(Compare, StringComparison.InvariantCultureIgnoreCase) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool EndsWithIgnoreCase(this String baseString, string Compare)
        {
            if (baseString.EndsWith(Compare, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
