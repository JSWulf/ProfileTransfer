using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10Migrate
{
    public class CopyItem
    {
        public CopyItem()
        {

        }
        public CopyItem(string Source)
        {
            SetSource(Source);
        }


        public string Source { get; private set; }
        public string Target { get; private set; }

        public void SetSource(string Source)
        {

        }

    }
}
