using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文件管理
{
    public interface Iterator
    {
        bool hasNext();
        Entry getCurrent();
        void next();
    
    }
}
