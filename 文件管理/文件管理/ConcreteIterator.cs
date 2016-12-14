using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文件管理
{
    public class ConcreteIterator : Iterator
    {
        private MyList _list;
        private int _index;
        public ConcreteIterator(MyList list)
        {
            _list = list;
            _index = 0;
        }
        public bool hasNext()
        {
            if (_index < _list.length())
            {
                return true;
            }
            return false;
        }
        public void next()
        {
            if (_index < _list.length())
            {
                _index++;
            }
        }

        public Entry getCurrent()
        {
            return _list.getElement(_index);
        }
    }
}
