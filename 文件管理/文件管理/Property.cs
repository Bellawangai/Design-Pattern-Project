using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 文件管理
{
    public partial class Property : Form
    {
        private bool changed = false;
        Entry entry = null;
        Form1 form = null;
        public Property()
        {
            InitializeComponent();
        }
        public Property(Entry entry, Form1 form1)
        {
            InitializeComponent();
            this.entry = entry;
            this.EntryName.Text = entry.getName();
            this.EntryType.Text = entry.getType();
            this.EntrySize.Text = entry.getSize().ToString() + "字节";
            this.EntryBlock.Text = entry.getBlock().ToString() + "个硬盘块" + (entry.getBlock() * 512) + "字节";
            this.EntryPosition.Text = entry.getRoad_string() + "/" + entry.getName();
            this.ChangedTime.Text = entry.getChangedTime();
            if (entry.getType() == "文件夹")
            {
                this.EntryPic.Image = this.imageList1.Images[0];
            }
            else if (entry.getType() == "txt")
            {
                this.EntryPic.Image = this.imageList1.Images[1];
            }
            else
            {
                this.EntryPic.Image = this.imageList1.Images[2];
            }
            this.form = form1;
        }

        private void EntryName_TextChanged(object sender, EventArgs e)
        {
            this.changed = true;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (changed == true)
            {
                if (this.EntryName.Text.IndexOf("/") == -1)
                {
                    this.entry.reName(this.EntryName.Text);
                    form.Flush();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("文件名不能包含‘/’");                   
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
