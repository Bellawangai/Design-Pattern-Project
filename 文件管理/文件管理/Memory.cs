using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 文件管理
{
    class Memory
    {
        private static int Count = 65536;//一共多少硬盘块
        private static int Size = 512;//每个硬盘块的大小
        private static char[][] Space = new char[Count][];//65536*512的硬盘 模拟为32MB
        private static bool[] Used = new bool[Count];//若已经分配则为真
       
        //单例模式
        private static Memory instance = new Memory();

        private Memory()
        {
            for (int i = 0; i < Count; i++)
            {
                Used[i] = false;
                Space[i] = new char[Size];
            }
            if (Directory.Exists("Memory") && Directory.GetFiles("Memory").Length > 0)//确保文件夹存在
            {
                FileStream UsedFile = new FileStream("Memory\\Used.txt",FileMode.Open);
                if (UsedFile.Length == 0)
                {
                    UsedFile.Close();
                    return;//没有硬盘块被占用
                }
                StreamReader UsedReader = new StreamReader(UsedFile);
                string[] indexString = UsedReader.ReadLine().Split(new char[] { ' ' });
                foreach (string i in indexString)
                {
                    if (i == "") break;//每个索引的字符形式
                    int index = Convert.ToInt32(i);//真索引
                    Used[index] = true;
                    FileStream SpaceFile = new FileStream("Memory\\" + i + ".txt", FileMode.Open);
                    StreamReader SpaceReader = new StreamReader(SpaceFile);
                    List<string> content = new List<string>();
                    content.AddRange(SpaceReader.ReadLine().Split(new char[] { ' ' }));
                    content.RemoveAt(content.Count - 1);//处理掉最后的空字符
                    string temp = "";//存储临时字符 以免在space不存在的位置被0补全
                    for (int j = 0; j < content.Count; j++)
                    {
                        temp += (char)Convert.ToInt32(content[j]);
                    }
                    Space[index] = temp.ToCharArray();
                    SpaceReader.Close();
                    SpaceFile.Close();
                }
                UsedReader.Close();
                UsedFile.Close();
            }
        }

        public static Memory getInstance()
        {
            return instance;
        }
        public int getBlock()
        {
            for (int i = 0; i < Count; i++)
            {
                if (!Used[i])
                {
                    Used[i] = true;
                    return i;
                }
            }
            return -1;
        }
        public void Delete(int i)
        {
            Used[i] = false;
        }//将num中的内容删除
        public int getSize()
        {
            return Size;
        }
        public int getCount()
        {
            return Count;
        }
        public string getContent(int index)
        {
            string temp = new string(Space[index]);
            return temp;
        }//获得index中的内容
        public int setContent(string text)
        {
            if (text.Length > Size) return -1;
            else
            {
                int index = this.getBlock();
                Space[index] = text.ToCharArray();
                return index;
            }
        }//向硬盘中写入text，返回索引
        public List<int> getTable(int index)//如果一个硬盘块装的内容是索引 则返回所有索引的List
        {
            List<int> result = new List<int>();
            for (int i = 0; i < Space[index].Length; i += 2)
            {
                if (i > Space[index].Length) break;
                char temp = Space[index][i];
                int number = 0;
                if (temp >= (char)0 && temp <= (char)65535)
                {
                    number = (int)Space[index][i] * 256 + (int)Space[index][i + 1];
                    result.Add(number);
                }
                else break;
            }
            return result;
        }
        public bool Empty()
        {
            foreach(bool empty in Used)
            {
                if (empty) return false;
            }
            return true;
        }
        public void Format()
        {
            for (int i = 0; i < Count; i++)
            {
                Used[i] = false;
            }
        }//用于格式化
        public void Write()
        {
            if (!Directory.Exists("Memory")) Directory.CreateDirectory("Memory");
            FileStream UsedFile = new FileStream("Memory\\Used.txt", FileMode.Create);
            StreamWriter UsedWriter = new StreamWriter(UsedFile);
            for (int i = 0; i < Count; i++)
            {
                if (Used[i]) 
                {
                    UsedWriter.Write(i.ToString() + " ");
                    FileStream SpaceFile = new FileStream("Memory\\" + i.ToString() + ".txt", FileMode.Create);
                    StreamWriter SpaceWriter = new StreamWriter(SpaceFile);
                    foreach (char c in Space[i])
                    {
                        SpaceWriter.Write((int)c);
                        SpaceWriter.Write(" ");
                    }
                    SpaceWriter.Flush();
                    SpaceWriter.Close();
                    SpaceFile.Close();
                }
            }
            UsedWriter.Flush();//清空缓冲区
            UsedWriter.Close();//关闭流
            UsedFile.Close();
        }//持久化
    }
}
