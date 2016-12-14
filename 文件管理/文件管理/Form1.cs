using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 文件管理
{
    public partial class Form1 : Form
    {
        Folder now = null;
        Folder root = null;
        Memory memory = Memory.getInstance();
        Stack<Folder> history = new Stack<Folder>();
        Stack<Folder> redo = new Stack<Folder>();
        private void CheckEnable()
        {
            if (redo.Count() > 0) this.ForwardButton.Enabled = true;
            else this.ForwardButton.Enabled = false;
            if (now != null && now.getFather() != null) this.UpwordButton.Enabled = true;
            else this.UpwordButton.Enabled = false;
            if (history.Count() > 1) this.BackwordButton.Enabled = true;
            else this.BackwordButton.Enabled = false;
        }//重置三个按钮的状态
        private void PrintIcon()//不用于打开文件 只用于前进后退以及初始化
        {
            this.listView1.Clear();
            List<Entry> member = now.SelectChild();
            if (member != null)
            {
                foreach (Entry entry in member)
                {
                    ListViewItem lvi = new ListViewItem();
                    if (entry.getType() == "文件夹")
                    {
                        lvi.ImageIndex = 0;//x为imagelist里的图片索引值，用的图片是icon
                        lvi.Text = entry.getName();
                    }
                    else if (entry.getType() == "txt")
                    {
                        lvi.ImageIndex = 1;
                        lvi.Text = entry.getName();
                    }
                    else if (entry.getType() == "exe")
                    {
                        lvi.ImageIndex = 2;
                        lvi.Text = entry.getName();
                    }
                    this.listView1.Items.Add(lvi);
                }
                string road = "";
                MyList path = now.getRoad();
                Iterator it = path.getIterator();
                while (it.hasNext())
                {
                    road += it.getCurrent().getName() + '/';
                    it.next();
                }
                road += now.getName();
                this.AddressText.Text = road;
            }
        }
        private void PrintIcon(List<Entry> member)//用于做搜索
        {
            history.Push(now);
            now = new Folder();
            now.setName(AddressText.Text);
            redo.Clear();
            CheckEnable();
            this.listView1.Clear();
            if (member != null && member.Count() > 0)
            {
                foreach (Entry entry in member)
                {
                    ListViewItem lvi = new ListViewItem();
                    if (entry.getType() == "文件夹")
                    {
                        lvi.ImageIndex = 0;//x为imagelist里的图片索引值，用的图片是icon
                        lvi.Text = entry.getRoad_string() + "/" + entry.getName();
                    }
                    else if (entry.getType() == "txt")
                    {
                        lvi.ImageIndex = 1;
                        lvi.Text = entry.getRoad_string() + "/" + entry.getName();
                    }
                    else if (entry.getType() == "exe")
                    {
                        lvi.ImageIndex = 2;
                        lvi.Text = entry.getRoad_string() + "/" + entry.getName();
                    }
                    this.listView1.Items.Add(lvi);
                }
                string road = "";
                MyList path = now.getRoad();
                Iterator it = path.getIterator();
                while (it.hasNext())
                {
                    road += it.getCurrent().getName() + '/';
                    it.next();
                }
                road += now.getName();
                this.AddressText.Text = road;
            }
        }
        private void Open(Entry entry)//传进来即将打开的Entry
        {
            if (entry.getType() == "文件夹")
            {
                this.history.Push(now);
                this.redo.Clear();
                this.CheckEnable();
                this.listView1.Clear();
                Folder folder = (Folder)entry;//为要打开的目录
                List<Entry> member = folder.Open();//为要打开的目录下的所有文件
                foreach (Entry item in member)
                {
                    ListViewItem lvi = new ListViewItem();
                    if (item.getType() == "文件夹")
                    {
                        lvi.ImageIndex = 0;//x为imagelist里的图片索引值，用的图片是icon
                        lvi.Text = item.getName();
                    }
                    else if (item.getType() == "txt")
                    {
                        lvi.ImageIndex = 1;
                        lvi.Text = item.getName();
                    }
                    else if (item.getType() == "exe")
                    {
                        lvi.ImageIndex = 2;
                        lvi.Text = item.getName();
                    }
                    this.listView1.Items.Add(lvi);
                }
                now = folder;
                string road = "";
                MyList path = now.getRoad();
                Iterator it = path.getIterator();
                while (it.hasNext())
                {
                    road += it.getCurrent().getName() + '/';
                    it.next();
                }
                road += now.getName();
                this.AddressText.Text = road;
            }
            else if (entry.getType().Equals("txt")) 
            {
                File file = (File)entry;
                TextEditor editor = new TextEditor(file);
                editor.Show();
            }
            else
            {
                MessageBox.Show("暂时不支持可执行文件的打开");
            }
        }
        public void Flush()
        {
            this.PrintIcon();
        }//刷新当前now
        public Form1()
        {
            InitializeComponent();
            if (Directory.Exists("Folder") && Directory.GetFiles("Folder").Length > 0)
            {
                this.now = new Folder();
                now.setName("/root");
                now.init(0);
                this.root = now;
            }
            else
            {
                this.now = new Folder();
                now.setName("/root");
                this.root = now;
            }
            this.PrintIcon();
            this.history.Push(root);
        }
        public Form1(Folder folder, Folder root)
        {
            InitializeComponent();
            this.root = root;
            this.now = folder;
            this.PrintIcon();
            this.history.Push(root);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems[0].Text.IndexOf("/") == -1)
            {
                Entry SelectedEntry = now.selectChild(this.listView1.SelectedItems[0].Text);
                this.Open(SelectedEntry);
            }
            else
            {
                List<string> Road = new List<string>();
                Road.AddRange(this.listView1.SelectedItems[0].Text.Split(new char[] { '/' }));
                Road.RemoveAt(0);
                if (Road[0] == "root") Road.RemoveAt(0);
                now=root;
                foreach (string entry in Road)
                {
                    if (now.selectChild(entry) != null) 
                    {
                        now = (Folder)now.selectChild(entry);
                    }
                    else
                    {
                        this.Open(now.selectChild(entry));
                        return;
                    }
                }
                this.Open(now);
            }
            this.CheckEnable();
        }//双击事件

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.GetItemAt(e.X, e.Y) != null)
                {
                    EntryMenu.Show(MousePosition);
                }
                else
                {
                    if (this.now == null) CreateMenuItem.Enabled = false;
                    MainMenu.Show(MousePosition);
                }
            }
        }//右键单击事件

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (ListViewItem lvi in this.listView1.SelectedItems)
                {
                    Entry entry = now.selectChild(lvi.Text);
                    entry.Delete();
                }
                this.Flush();
            }
            redo.Clear();
            this.CheckEnable();
        }//删除菜单时间

        private void CreateFolderMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = 0;//x为imagelist里的图片索引值，用的图片是icon
            string name = "新建文件夹";
            for (int i = 1; ; i++)
            {
                ListViewItem temp = null;
                if (i == 1) temp = this.listView1.FindItemWithText(name);
                else temp = this.listView1.FindItemWithText(name + "(" + i.ToString() + ")");
                if (temp == null)
                {
                    if (i != 1) name += "(" + i.ToString() + ")";
                    break;
                }
            }
            lvi.Text = name;
            this.listView1.Items.Add(lvi);
            this.listView1.Items[this.listView1.Items.Count - 1].BeginEdit();
        }//新建文件夹菜单事件

        private void CreatetxtMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = 1;
            string name = "新建文本文件";
            for (int i = 1; ; i++)
            {
                ListViewItem temp = null;
                if (i == 1) temp = this.listView1.FindItemWithText(name);
                else temp = this.listView1.FindItemWithText(name + "(" + i.ToString() + ")");
                if (temp == null)
                {
                    if (i != 1) name += "(" + i.ToString() + ")";
                    break;
                }
            }
            lvi.Text = name;
            this.listView1.Items.Add(lvi);
            this.listView1.Items[this.listView1.Items.Count - 1].BeginEdit();
        }//新建文本菜单事件

        private void CreateexeStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.ImageIndex = 2;
            string name = "新建可执行文件";
            for (int i = 1; ; i++)
            {
                ListViewItem temp = null;
                if (i == 1) temp = this.listView1.FindItemWithText(name);
                else temp = this.listView1.FindItemWithText(name + "(" + i.ToString() + ")");
                if (temp == null)
                {
                    if (i != 1) name += "(" + i.ToString() + ")";
                    break;
                }
            }
            lvi.Text = name;
            this.listView1.Items.Add(lvi);
            this.listView1.Items[this.listView1.Items.Count - 1].BeginEdit();
        }//新建exe菜单事件

        private void RenameMenuItem_Click(object sender, EventArgs e)
        {
            this.listView1.SelectedItems[0].BeginEdit();
        }

        private void UpwordButton_Click(object sender, EventArgs e)
        {
            this.Open(now.getFather());
            this.CheckEnable();
        }//向上按钮事件

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 1)
            {
                Entry SelectedEntry = now.selectChild(this.listView1.SelectedItems[0].Text);
                this.Open(SelectedEntry);
                this.ForwardButton.Enabled = false;
            }
            else
            {
                int i = 0;
                Folder oldFolder = now;//存储的是一开始的目录 在多个文件以及文件夹的打开中选择后面的文件
                foreach (ListViewItem lvi in this.listView1.SelectedItems)
                {
                    Entry SelectedEntry = oldFolder.selectChild(lvi.Text);
                    if (i == 0 && SelectedEntry.getType() == "文件夹")
                    {
                        this.Open(SelectedEntry);
                        i++;
                    }
                    else
                    {
                        if (SelectedEntry.getType() == "文件夹")
                        {
                            Form1 form = new Form1((Folder)SelectedEntry, root);
                            form.Show();
                        }
                        else
                        {
                            this.Open(SelectedEntry);
                        }
                    }                    
                }
            }
        }//打开菜单事件

        private void BackwordButton_Click(object sender, EventArgs e)
        {
            this.redo.Push(now);
            now = this.history.Pop();
            PrintIcon();
            CheckEnable();
        }//后退按钮事件

        private void ForwardButton_Click(object sender, EventArgs e)
        {
            this.history.Push(now);
            now = this.redo.Pop();
            PrintIcon();
            CheckEnable();
        }//前进按钮事件

        private void FormatMenuItem_Click(object sender, EventArgs e)
        {
            memory.Format();
            now = this.root;
            now.setChild(null);
            PrintIcon();
            this.history.Clear();
            this.redo.Clear();
            CheckEnable();
        }//格式化菜单事件

        private void FlushMenuItem_Click(object sender, EventArgs e)
        {
            this.Flush();
        }//刷新菜单事件

        private void GotoButton_Click(object sender, EventArgs e)
        {
            List<string> Road = new List<string>();
            Road.AddRange(this.AddressText.Text.Split(new char[] { '/' }));
            Road.RemoveAt(0);
            if (Road[0] == "root") Road.RemoveAt(0);
            this.history.Push(now);
            now = root;
            foreach (string Name in Road)
            {
                if (now.selectChild(Name) != null)
                {
                    if (now.selectChild(Name).getType() == "文件夹") now = (Folder)now.selectChild(Name);
                    else
                    {
                        this.Open(now.selectChild(Name));
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("路径有误请重试！");
                    now = history.Pop();
                    Flush();
                    return;
                }
            }
            PrintIcon();
        }//跳转按钮事件

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (this.SearchText.Text != null)
            {
                if (now.getChild() != null)
                {
                    List<Entry> p = new List<Entry>();
                    p = now.getChild().Find(this.SearchText.Text);
                    this.AddressText.Text = "在" + now.getName() + "中搜索\"" + SearchText.Text + "\"";
                    PrintIcon(p);
                }
                else
                {
                    MessageBox.Show("此文件夹下没有文件");
                    this.AddressText.Text = "";
                }
            }
        }//搜索按钮事件

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            memory.Write();
            if (Directory.Exists("Folder"))
            {                
               // Directory.Delete("Folder", true);
                Directory.CreateDirectory("Folder");
            }
            if (root.getChild() != null) root.getChild().Write(0);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }//文件夹关闭时事件

        private void PropertyMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                Entry entry = now.selectChild(lvi.Text);
                Property pro = new Property(entry, this);
                pro.Show();
            }
        }//属性菜单事件

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            ListViewItem lvi = this.listView1.Items[e.Item];
            string temp = "";
            temp += e.Label;
            if (temp.IndexOf('/') != -1)
            {
                //MessageBox.Show("文件名中不可出现斜杠反斜杠");                
                //this.listView1.FocusedItem = lvi;
                //e.CancelEdit = true;
                //lvi.BeginEdit();
                listView1.FocusedItem.BeginEdit();
                return;
                
            }

            if (now.selectChild(this.listView1.Items[e.Item].Text) == null)//此处为创建文件
            {
                bool succeed = false;
                string name = null;
                if (e.Label == "")
                {
                    this.listView1.Items[e.Item].BeginEdit();

                }
                else if (e.Label == null)
                {
                    name = this.listView1.Items[e.Item].Text;
                }
                else
                {
                    name = e.Label;
                }
                switch (this.listView1.Items[e.Item].ImageIndex)
                {
                    case 0:
                        succeed = now.Create(name, "文件夹");
                        break;
                    case 1:
                        succeed = now.Create(name, "txt");
                        break;
                    case 2:
                        succeed = now.Create(name, "exe");
                        break;
                }
                if (!succeed)
                {
                    DialogResult result = MessageBox.Show("文件名重复");
                    this.listView1.Items[e.Item].BeginEdit();
                    return;
                }
            }

            else//给文件夹更名
            {
                int Count = this.listView1.SelectedItems.Count;
                for (int i = 0; i < Count; i++)
                {
                    Entry SelectedEntry = now.selectChild(this.listView1.SelectedItems[i].Text);
                    if (i == 0)
                    {
                        SelectedEntry.reName(e.Label);
                    }
                    else
                    {
                        SelectedEntry.reName(e.Label + "(" + (i + 1).ToString() + ")");
                        this.listView1.SelectedItems[i].Text = e.Label + "(" + (i + 1).ToString() + ")";
                    }
                }
            }
        }//标签更改后事件，用于重命名
    }
}
