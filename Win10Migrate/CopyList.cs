using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10Migrate
{
    class CopyList : Start
    {
        CopyList()
        {
            CopyItems = new List<CopyItem>();
        }
        CopyList(string ExtraFolder)
        {
            CopyItems = new List<CopyItem>
            {
                new CopyItem(ExtraFolder)
            };
        }
        CopyList(List<string> ExtraFolders)
        {
            CopyItems = new List<CopyItem>();

            foreach (var item in ExtraFolders)
            {
                CopyItems.Add(new CopyItem(item));
            }
        }


        public List<CopyItem> CopyItems { get; set; }


        private void GetUserFiles()
        {

        }

    }


}
