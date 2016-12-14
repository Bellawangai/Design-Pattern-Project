using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文件管理
{
    public class FolderFactory : Creator
    {
        public override Entry CreateEntryFactory()
        {
            return new Folder();
        }
        public override Entry CreateEntryFactory(Entry en)
        {
            return new Folder(en);
        }
        
    }
}
