using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文件管理
{
    public class Folder : Entry
    {
        public Folder()
        {
            this.Type = "文件夹";
        }
        public Folder(Entry father)
        {
            this.Type = "文件夹";
            this.Father = father;
        }
        public Folder(string name, Entry father)
        {
            this.Name = name;
            this.Type = "文件夹";
            this.Father = father;
            this.ChangedTime = DateTime.Now;
        }
        public bool Create(string name, string type)
        {
            Entry p = this;
            if (p.getChild() == null)
            {
                if (type == "文件夹") p.setChild(new Folder(name, p));//新建文件夹 
                else p.setChild(new File(name, type, p));//文件
                p = p.getChild();
            }
            else
            {
                p = p.getChild();
                Entry q = p;
                while (p != null)
                {
                    if (p.getName().Equals(name) && p.getType().Equals(type)) return false;
                    else
                    {
                        q = p;
                        p = p.getBrother();
                    }
                }
                p = q;
                if ((type.Equals("文件夹"))) p.setBrother(new Folder(name, this));
                else p.setBrother(new File(name, type, this));
                p = p.getBrother();
            }
            p.setRoad();//初始化路径
            return true;
        }//在this下新建一个名为name，类型为type的文件
        public List<Entry> Open()//返回此文件夹下的所有entry的list
        {
            List<Entry> result = new List<Entry>();
            Entry p = this.getChild();
            while (p != null)
            {
                result.Add(p);
                p = p.getBrother();
            }
            return result;
        }
        public Entry selectChild(string name)
        {
            if (this.getChild() == null) return null;
            else
            {
                Entry p = this.getChild();
                while (p != null)
                {
                    if (p.getName() == name) return p;
                    else p = p.getBrother();
                }
                return null;
            }
        }
        //public override bool Equals(string name)
        //{
        //    return this.Name.Equals(name);
        //}
    }
}
