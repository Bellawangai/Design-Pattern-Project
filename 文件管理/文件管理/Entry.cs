using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace 文件管理
{
    public class Entry
    {
        protected string Name;
        protected string Type;
        protected MyList Road = new MyList();
        protected Entry Father = null;
        protected Entry Brother = null;
        protected Entry Child = null;
        public DateTime ChangedTime;//修改时间

        public Entry()
        {

        }
        public Entry(Entry father)
        {
            this.Father = father;
        }
        public Entry(string name, string type, Entry father)
        {
            this.Name = name;
            this.Type = type;
            this.ChangedTime = DateTime.Now;
            this.Father = father;
        }
        public Entry getBrother()
        {
            return this.Brother;
        }
        public void setBrother(Entry brother)
        {
            this.Brother = brother;
        }
        public Entry getChild()
        {
            return this.Child;
        }
        public void setChild(Entry child)
        {
            this.Child = child;
        }
        public Entry getFather()
        {
            return this.Father;
        }
        public string getName()
        {
            return this.Name;
        }
        public string getType()
        {
            return this.Type;
        }
        public void setName(string name)
        {
            this.Name = name;
        }
        //public virtual bool Create(string name, string type)
        //{
        //    throw new Exception("无法在文件下新建路径");
        //}//虚函数，在Folder中重写，此处抛出异常
        public MyList getRoad()
        {
            return this.Road;
        }
        public string getRoad_string()
        {
            string road = "";
            Iterator it = Road.getIterator();
            while (it.hasNext())
            {
                road += it.getCurrent().getName() + '/';
                it.next();
            }
            road = road.Substring(0, road.Length - 1);
            return road;
        }//获取路径，迭代器模式
        public void reName(string name)
        {
            this.Name = name;
            this.ChangedTime = DateTime.Now;
        }
        public string getChangedTime()
        {
            return this.ChangedTime.ToString();
        }
        
        public virtual bool Equals(string name)
        {
            return this.Name.Equals(name);
            //throw new Exception("系统文件异常");
        }
        
        //public virtual Entry selectChild(string name)
        //{
        //    if (this.getChild() == null) return null;
        //    else
        //    {
        //        Entry p = this.getChild();
        //        while (p != null) 
        //        {
        //            if (p.getName() == name) return p;
        //            else p = p.getBrother();
        //        }
        //        return null;
        //    }
        //}//返回this下文件名为Name的文件指针，在File对应方法中抛出异常
        
        public virtual long getSize()
        {
            long size = 0;
            if (this.getChild() == null) return 0;
            else
            {
                Entry p = this.getChild();
                while (p != null)
                {
                    size += p.getSize();
                    p = p.getBrother();
                }
                return size;
            }
        }
        public List<Entry> SelectChild()
        {
            if (this.getChild() == null) return null;
            else
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
            //throw new Exception("系统未知异常");
        }//返回this下的所有child的链表数组
        public void setRoad()
        {
            this.Road.Clear();
            if (this.Father == null) this.Road.Add(new Entry("", "root", null));//设置一个不存在的根目录
            else
            {
                Entry p = this.Father;
                Road.AddRange(p.getRoad());
                Road.Add(p);
            }
        }//更新Dir，用在初始化中
        public virtual void Delete()
        {
            if (this.Father.getChild() == this) this.Father.Child = this.Brother;
            else
            {
                Entry p = this.Father.Child;
                while (p.getBrother() != this)
                {
                    p = p.getBrother();
                }
                p.setBrother(this.Brother);
            }
            List<Entry> allChild = this.SelectChild();
            if (allChild != null) //下一级循环中的递归删除
            {
                foreach (Entry entry in allChild)
                {
                    entry.Delete();
                }
            }
               
        }//删除this节点
        public virtual int getBlock()
        {
            if (this.getChild() == null) return 0;
            else
            {
                int num = 0;
                Entry p = this.getChild();
                while (p != null)
                {
                    num += p.getBlock();
                    p = p.getBrother();
                }
                return num;
            }
        }//递归返回文件实际占用空间
        public List<Entry> Find(string name)
        {
            if (this != null)
            {
                List<Entry> p = new List<Entry>();
                if (this.Name.IndexOf(name) != -1) p.Add(this);
                if (this.getBrother() != null) p.AddRange(this.Brother.Find(name));
                if (this.getChild() != null) p.AddRange(this.Child.Find(name));
                return p;
            }
            else return null;
        }//用于在this下面搜索匹配name的文件，返回一个链表数组
        public virtual void Write(int n)
        {
            if (!Directory.Exists("Folder")) Directory.CreateDirectory("Folder");
            FileStream EntryFiles = new FileStream("Folder\\" + n + ".txt", FileMode.Create);
            StreamWriter EntryWriter = new StreamWriter(EntryFiles);
            EntryWriter.WriteLine(this.Type);
            EntryWriter.WriteLine(this.Name);
            EntryWriter.WriteLine(this.ChangedTime);
            EntryWriter.Close();
            EntryFiles.Close();
            if (this.Child != null) this.Child.Write(2 * n + 1);
            if (this.Brother != null) this.Brother.Write(2 * n + 2);
        }//从root下的第一个子节点开始保存
        public virtual Entry Read(int n)
        {
            //初始化两个工厂
            Creator FolderFactory = new FolderFactory();
            Creator FileFactory = new FileFactory();
            
            FileStream EntryFile = new FileStream("Folder\\" + n + ".txt", FileMode.Open);
            StreamReader EntryReader = new StreamReader(EntryFile);
            string type = EntryReader.ReadLine();
            if (n % 2 == 1 || n == 0)//加child
            {
                if(type=="文件夹")
                {
                    this.Child = FolderFactory.CreateEntryFactory(this);
                    this.Child.Name = EntryReader.ReadLine();
                    this.Child.ChangedTime = DateTime.Parse(EntryReader.ReadLine());
                }
                else
                {
                    this.Child = FileFactory.CreateEntryFactory(this);
                    File p = (File)this.Child;
                    this.Child.Type = type;
                    this.Child.Name = EntryReader.ReadLine();
                    this.Child.ChangedTime = DateTime.Parse(EntryReader.ReadLine());
                    p.setSize(Convert.ToInt64(EntryReader.ReadLine()));
                    p.setBlock(Convert.ToInt32(EntryReader.ReadLine()));
                    string[] table = EntryReader.ReadLine().Split(new char[] { ' ' });
                    List<int> Table = new List<int>();
                    for (int i = 0; i < 13; i++)
                    {
                        Table.Add(Convert.ToInt32(table[i]));
                    }
                    p.setTable(Table);
                }
                
                EntryReader.Close();
                EntryFile.Close();
                this.Child.setRoad();
                return this.Child;
            }
            else//加brother
            {
                if (type == "文件夹")
                {
                    this.Brother = FolderFactory.CreateEntryFactory(this.Father);
                    this.Brother.Name = EntryReader.ReadLine();
                    this.Brother.ChangedTime = DateTime.Parse(EntryReader.ReadLine());
                }
                else
                {
                    this.Brother = FileFactory.CreateEntryFactory(this.Father);
                    File p = (File)this.Brother;
                    this.Brother.Type = type;
                    this.Brother.Name = EntryReader.ReadLine();
                    this.Brother.ChangedTime = DateTime.Parse(EntryReader.ReadLine());
                    
                    p.setSize(Convert.ToInt64(EntryReader.ReadLine()));
                    p.setBlock(Convert.ToInt32(EntryReader.ReadLine()));
                    string[] table = EntryReader.ReadLine().Split(new char[] { ' ' });
                    List<int> Table = new List<int>();
                    for (int i = 0; i < 13; i++)
                    {
                        Table.Add(Convert.ToInt32(table[i]));
                    }
                    p.setTable(Table);
                }
                
                EntryReader.Close();
                EntryFile.Close();
                this.Brother.setRoad();
                return this.Brother;
            }

        }//给this下面加入新的文件（读入文本）
        public void init(int n)
        {
            Entry p = this.Read(n);
            if (System.IO.File.Exists("Folder\\" + (n * 2 + 1).ToString() + ".txt"))
            {
                p.init(n * 2 + 1);
            }
            if (System.IO.File.Exists("Folder\\" + (n * 2 + 2).ToString() + ".txt"))
            {
                p.init(n * 2 + 2);
            }
        }//加child
    }
}
