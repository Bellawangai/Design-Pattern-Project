using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文件管理
{
    public class MyList : MyListCollection
    {
        private List<Entry> list;
        public MyList()
        {
            list = new List<Entry>();
        }
        public Iterator getIterator()
        {
            return new ConcreteIterator(this);
        }
        public int length()
        {
            return list.Count();
        }
        public Entry getElement(int index)
        {
            return list[index];
        }
        public void Clear()
        {
            list.Clear();
        }
        public void Add(Entry entry)
        {
            list.Add(entry);
        }
        public void AddRange(MyList roadlist)
        {
            list.AddRange(roadlist.list);
        }

    }
}
