using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文件管理
{
    //抽象工厂类
    public abstract class Creator
    {
        //工厂方法
        public abstract Entry CreateEntryFactory();
        public abstract Entry CreateEntryFactory(Entry en);
        
    
    }
}
