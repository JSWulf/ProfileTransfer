using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Win10Migrate
{
    public class LinksToQuickAccess
    {
        LinksToQuickAccess()
        {
            LinksPath = new DirectoryInfo(CopyList.NewHost.ProfileSource + @"\Links");
        }
        LinksToQuickAccess(string PathToLinks)
        {
            LinksPath = new DirectoryInfo(PathToLinks);
        }

        private DirectoryInfo linksPath;

        public DirectoryInfo LinksPath
        {
            get { return linksPath; }
            set {
                if (Directory.Exists(value.FullName))
                {
                    linksPath = value;
                }
                else
                {
                    throw new Exception("Inputed path not found: " + value.FullName);
                }
            }
        }

        private List<LinkToQ> LinkLists { get; set; }

        public List<LinkToQ> GetLinks()
        {
            if (LinkLists == null)
            {
                LinkLists = new List<LinkToQ>();
                //go through files
                foreach (var shortcutFile in Directory.GetFiles(linksPath.FullName))
                {

                    LinkLists.Add(new LinkToQ());
                }
            }
            else
            {
                //do nothing... just return linklist.
            }

            return LinkLists;
        }

    }
}
