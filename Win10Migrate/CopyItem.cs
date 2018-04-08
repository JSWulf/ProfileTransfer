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
        public CopyItem(string source)
        {
            SetSource(source);
        }


        public string Source { get; private set; }
        public string Target { get; private set; }

        public void SetSource(string source)
        {
            Source = source;
            Target = source.Replace(CopyList.OldHost.Path, CopyList.NewHost.Path);
        }

    }
}
