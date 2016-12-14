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
    public partial class TextEditor : Form
    {
        private File file = null;
        private bool changed = false;
        public TextEditor()
        {
            InitializeComponent();
        }
        public TextEditor(File file)
        {
            InitializeComponent();
            this.file = file;
            this.richTextBox1.Text = file.Open();
            this.Text = file.getName();
            //if (!Clipboard.GetDataObject().GetDataPresent(DataFormats.Text)) 粘贴ToolStripMenuItem.Enabled = false;
            
        }

        
        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                Clipboard.SetDataObject(richTextBox1.SelectedText, true);
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = this.richTextBox1.Text;
            file.Save(text);
            if (changed == true)
            {
                this.Text = this.Text.Substring(0, Text.Length - 1);
                changed = false;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(!changed)
            {
                changed = true;
                Text += "*";
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changed)
            {
                DialogResult dr = MessageBox.Show("文档进行了修改，是否保存？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                if (dr == DialogResult.Yes)
                {
                    file.Save(this.richTextBox1.Text);
                    this.Text = this.Text.Substring(0, Text.Length - 1);
                    changed = false;
                }
            }
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("简易文本编辑器——刀刀崔");
        }

        private void 全选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectAll();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                粘贴ToolStripMenuItem.Enabled = true;
                richTextBox1.Paste();
            }
            else
            {
                粘贴ToolStripMenuItem.Enabled = false;
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.SelectedText = "";
            }
        }

        private void 撤销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void 恢复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

    }
}
