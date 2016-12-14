using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 文件管理
{
    public class File : Entry
    {
        private int[] Table = new int[13];//文件索引表
        private long size = 0;//文件大小
        private int block = 0;//磁盘占用数量
        Memory memory = Memory.getInstance();
        public File()
        {

        }
        public File(Entry father)
        {
            this.Father = father;
        }
        public File(string name,string type,Entry father)
        {
            this.Name = name;
            this.Type = type;
            this.Father = father;
            this.ChangedTime = DateTime.Now;
            for (int i = 0; i < 13; i++)
            {
                this.Table[i] = -1;
            }//未占用空间
        }
        public override long getSize()
        {
            return this.size;
        }
        public void setSize(long size)
        {
            this.size = size;
        }
        public override int getBlock()
        {
            return this.block;
        }
        public void setBlock(int block)
        {
            this.block = block;
        }
        public void setTable(List<int> table)
        {
            for (int i = 0; i < 13; i++)
            {
                this.Table[i] = table[i];
            }
        }
        //public override bool Equals(string name)
        //{
        //    return this.Name.Equals(name);
        //}
        //public override Entry selectChild(string name)
        //{
        //    throw new Exception("文件下无子文件");
        //}//重写丢出异常

        public string Open()
        {
            if (this.Type == "txt")
            {
                string temp = "";//最后返回的内容
                for (int i = 0; i < 10; i++)
                {
                    if (this.Table[i] != -1)
                    {
                        temp += memory.getContent(this.Table[i]);
                    }
                    else return temp;
                }//直接寻址到此结束
                if (this.Table[10] != -1)
                {
                    List<int> indexList = memory.getTable(Table[10]);
                    foreach (int i in indexList)//每个i都是一个盘号
                    {
                        temp += memory.getContent(i);
                    }
                }//一次间接
                if (this.Table[11] != -1)
                {
                    List<int> indexList = memory.getTable(Table[11]);//一级索引
                    foreach (int i in indexList)
                    {
                        List<int> secondList = memory.getTable(i);
                        foreach (int j in secondList)
                        {
                            temp += memory.getContent(j);
                        }
                    }
                }//二次间接
                if (this.Table[12] != -1)
                {
                    List<int> indexList = memory.getTable(Table[12]);
                    foreach (int i in indexList)
                    {
                        List<int> secondList = memory.getTable(i);
                        foreach (int j in secondList)
                        {
                            List<int> thirdList = memory.getTable(j);
                            foreach (int k in thirdList)
                            {
                                temp += memory.getContent(k);
                            }
                        }
                    }
                }//三次间接
                return temp;
            }
            else return null;
        }//通过多级索引表返回字符串
        public void Save(string text)
        {
            if (this.Type != "txt") throw new Exception("不可向非文本文件写入信息");
            else if (text.Length == 0) return;
            else
            {
                this.Clear();
                this.size = text.Length;
                int MemorySize = memory.getSize();
                if (this.size > MemorySize * memory.getCount()) throw new Exception("超过硬盘容量");
                for (int i = 0; i < 10; i++)
                {
                    if (text.Length > MemorySize)//写入内容超过一个硬盘块
                    {
                        this.Table[i] = memory.setContent(text.Substring(0, MemorySize));
                        text = text.Substring(MemorySize);
                        block++;
                    }
                    else//写入内容不足一个硬盘块
                    {
                        this.Table[i] = memory.setContent(text);
                        block++;
                        return;
                    }
                }
                List<string> index = new List<string>();
                index.Add("");
                while (text.Length > 0)
                {
                    string indextemp = "";
                    if (text.Length > MemorySize)
                    {
                        indextemp += Convert.ToString(memory.setContent(text.Substring(0, MemorySize)), 16);
                        while (indextemp.Length < 4)
                        {
                            indextemp = indextemp.Insert(0, "0");
                        }
                        text = text.Substring(MemorySize);
                        block++;
                    }
                    else
                    {
                        indextemp += Convert.ToString(memory.setContent(text), 16);
                        while (indextemp.Length < 4)
                        {
                            indextemp = indextemp.Insert(0, "0");
                        }
                        text = "";
                        block++;
                    }
                    index[0] += (char)Convert.ToInt32(indextemp.Substring(0, 2), 16);
                    index[0] += (char)Convert.ToInt32(indextemp.Substring(2, 2), 16);
                }//把text压缩进索引中
                for (int i = 0; i < 3; i++)
                {
                    index.Add("");
                    if (index[i].Length <= MemorySize)//索引内容只需要一个块
                    {
                        this.Table[10 + i] = memory.setContent(index[i]);
                        block++;
                        return;
                    }
                    this.Table[10 + i] = memory.setContent(index[i].Substring(0, MemorySize));
                    block++;
                    index[i] = index[i].Substring(MemorySize);
                    while (index[i].Length > 0)
                    {
                        string indextemp = "";
                        if (index[i].Length >= MemorySize)
                        {
                            indextemp += Convert.ToString(memory.setContent(index[0].Substring(0, MemorySize)), 16);
                            while (indextemp.Length < 4)
                            {
                                indextemp = indextemp.Insert(0, "0");
                            }
                            index[i] = index[i].Substring(MemorySize);
                            block++;
                        }
                        else
                        {
                            indextemp += Convert.ToString(memory.setContent(index[0].Substring(0, MemorySize)), 16);
                            while (indextemp.Length < 4)
                            {
                                indextemp = indextemp.Insert(0, "0");
                            }
                            index[i] = "";
                            block++;
                        }
                        index[i + 1] += (char)Convert.ToInt32(indextemp.Substring(0, 2), 16);
                        index[i + 1] += (char)Convert.ToInt32(indextemp.Substring(2, 2), 16);
                    }//压缩到更高一级的索引中
                }
            }
        }//将字符串存入虚拟硬盘
        private void Clear()
        {
            this.block = 0;
            this.size = 0;
            for (int i = 0; i < 10; i++)
            {
                if (this.Table[i] == -1) return;
                else memory.Delete(Table[i]);
            }
            if (Table[10] != -1)
            {
                List<int> indexList = memory.getTable(Table[10]);
                foreach (int i in indexList)//每个i都是一个盘号
                {
                    memory.Delete(i);
                }
                memory.Delete(Table[10]);
                Table[10] = -1;
                indexList.Clear();
                if (Table[11] != -1)
                {
                    indexList = memory.getTable(Table[11]);
                    foreach (int i in indexList)
                    {
                        List<int> secondList = memory.getTable(i);
                        foreach (int j in secondList)
                        {
                            memory.Delete(j);
                        }
                        memory.Delete(i);
                    }
                    memory.Delete(Table[11]);
                    Table[11] = -1;
                    indexList.Clear();
                    if (Table[12] != -1)
                    {
                        indexList = memory.getTable(Table[12]);
                        foreach (int i in indexList)
                        {
                            List<int> secondList = memory.getTable(i);
                            foreach (int j in secondList)
                            {
                                List<int> thirdList = memory.getTable(j);
                                foreach (int k in thirdList)
                                {
                                    memory.Delete(k);
                                }
                                memory.Delete(j);
                            }
                            memory.Delete(i);
                        }
                        memory.Delete(Table[12]);
                        Table[12] = -1;
                        indexList.Clear();
                    }
                }
            }
        }//将所有索引表清空 以及对应的硬盘块和多级索引表的硬盘块
        public override void Delete()
        {
            this.Clear();
            if (this.Father.getChild() == this) this.Father.setChild(this.Brother);
            else
            {
                Entry p = this.Father.getChild();
                while (p.getBrother() != this)
                {
                    p = p.getBrother();
                }
                p.setBrother(this.Brother);
            }
        }//删除
        public override void Write(int n)
        {
            if (!Directory.Exists("Folder")) Directory.CreateDirectory("Folder");
            FileStream EntryFiles = new FileStream("Folder\\" + n + ".txt", FileMode.Create);
            StreamWriter EntryWriter = new StreamWriter(EntryFiles);
            EntryWriter.WriteLine(this.Type);
            EntryWriter.WriteLine(this.Name);
            EntryWriter.WriteLine(this.ChangedTime);
            EntryWriter.WriteLine(this.size);
            EntryWriter.WriteLine(this.block);
            foreach (int i in Table)
            {
                EntryWriter.Write(i);
                EntryWriter.Write(" ");
            }
            EntryWriter.Close();
            EntryFiles.Close();
            if (this.Brother != null) this.Brother.Write(n * 2 + 2);
        }//递归写 需要用到n来判断应该的位置
    }
}
