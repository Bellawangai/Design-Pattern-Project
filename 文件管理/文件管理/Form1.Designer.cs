namespace 文件管理
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listView1 = new System.Windows.Forms.ListView();
            this.AddressText = new System.Windows.Forms.TextBox();
            this.SearchText = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.GotoButton = new System.Windows.Forms.Button();
            this.UpwordButton = new System.Windows.Forms.Button();
            this.ForwardButton = new System.Windows.Forms.Button();
            this.BackwordButton = new System.Windows.Forms.Button();
            this.MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreatetxtMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateexeStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FlushMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EntryMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PropertyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MainMenu.SuspendLayout();
            this.EntryMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.LabelEdit = true;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(0, 38);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(887, 413);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView1_AfterLabelEdit);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // AddressText
            // 
            this.AddressText.Location = new System.Drawing.Point(120, 9);
            this.AddressText.Name = "AddressText";
            this.AddressText.Size = new System.Drawing.Size(578, 21);
            this.AddressText.TabIndex = 4;
            // 
            // SearchText
            // 
            this.SearchText.Location = new System.Drawing.Point(704, 9);
            this.SearchText.Name = "SearchText";
            this.SearchText.Size = new System.Drawing.Size(170, 21);
            this.SearchText.TabIndex = 5;
            // 
            // SearchButton
            // 
            this.SearchButton.Image = global::文件管理.Properties.Resources.magnifying_glass;
            this.SearchButton.Location = new System.Drawing.Point(841, 0);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(33, 34);
            this.SearchButton.TabIndex = 7;
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // GotoButton
            // 
            this.GotoButton.Image = global::文件管理.Properties.Resources.arrow_right;
            this.GotoButton.Location = new System.Drawing.Point(665, 1);
            this.GotoButton.Name = "GotoButton";
            this.GotoButton.Size = new System.Drawing.Size(33, 34);
            this.GotoButton.TabIndex = 6;
            this.GotoButton.UseVisualStyleBackColor = true;
            this.GotoButton.Click += new System.EventHandler(this.GotoButton_Click);
            // 
            // UpwordButton
            // 
            this.UpwordButton.Image = global::文件管理.Properties.Resources.arrow_up_alt1;
            this.UpwordButton.Location = new System.Drawing.Point(81, 3);
            this.UpwordButton.Name = "UpwordButton";
            this.UpwordButton.Size = new System.Drawing.Size(33, 34);
            this.UpwordButton.TabIndex = 3;
            this.UpwordButton.UseVisualStyleBackColor = true;
            this.UpwordButton.Click += new System.EventHandler(this.UpwordButton_Click);
            // 
            // ForwardButton
            // 
            this.ForwardButton.Image = global::文件管理.Properties.Resources.arrow_right_alt1;
            this.ForwardButton.Location = new System.Drawing.Point(42, 3);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(33, 34);
            this.ForwardButton.TabIndex = 2;
            this.ForwardButton.UseVisualStyleBackColor = true;
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButton_Click);
            // 
            // BackwordButton
            // 
            this.BackwordButton.Image = global::文件管理.Properties.Resources.arrow_left_alt1;
            this.BackwordButton.Location = new System.Drawing.Point(3, 3);
            this.BackwordButton.Name = "BackwordButton";
            this.BackwordButton.Size = new System.Drawing.Size(33, 34);
            this.BackwordButton.TabIndex = 1;
            this.BackwordButton.UseVisualStyleBackColor = true;
            this.BackwordButton.Click += new System.EventHandler(this.BackwordButton_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateMenuItem,
            this.FlushMenuItem,
            this.FormatMenuItem});
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(113, 70);
            // 
            // CreateMenuItem
            // 
            this.CreateMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateFolderMenuItem,
            this.CreatetxtMenuItem,
            this.CreateexeStripMenuItem});
            this.CreateMenuItem.Name = "CreateMenuItem";
            this.CreateMenuItem.Size = new System.Drawing.Size(112, 22);
            this.CreateMenuItem.Text = "新建";
            // 
            // CreateFolderMenuItem
            // 
            this.CreateFolderMenuItem.Name = "CreateFolderMenuItem";
            this.CreateFolderMenuItem.Size = new System.Drawing.Size(160, 22);
            this.CreateFolderMenuItem.Text = "新建文件夹";
            this.CreateFolderMenuItem.Click += new System.EventHandler(this.CreateFolderMenuItem_Click);
            // 
            // CreatetxtMenuItem
            // 
            this.CreatetxtMenuItem.Name = "CreatetxtMenuItem";
            this.CreatetxtMenuItem.Size = new System.Drawing.Size(160, 22);
            this.CreatetxtMenuItem.Text = "新建文本文件";
            this.CreatetxtMenuItem.Click += new System.EventHandler(this.CreatetxtMenuItem_Click);
            // 
            // CreateexeStripMenuItem
            // 
            this.CreateexeStripMenuItem.Name = "CreateexeStripMenuItem";
            this.CreateexeStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.CreateexeStripMenuItem.Text = "新建可执行文件";
            this.CreateexeStripMenuItem.Click += new System.EventHandler(this.CreateexeStripMenuItem_Click);
            // 
            // FlushMenuItem
            // 
            this.FlushMenuItem.Name = "FlushMenuItem";
            this.FlushMenuItem.Size = new System.Drawing.Size(112, 22);
            this.FlushMenuItem.Text = "刷新";
            this.FlushMenuItem.Click += new System.EventHandler(this.FlushMenuItem_Click);
            // 
            // FormatMenuItem
            // 
            this.FormatMenuItem.Name = "FormatMenuItem";
            this.FormatMenuItem.Size = new System.Drawing.Size(112, 22);
            this.FormatMenuItem.Text = "格式化";
            this.FormatMenuItem.Click += new System.EventHandler(this.FormatMenuItem_Click);
            // 
            // EntryMenu
            // 
            this.EntryMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMenuItem,
            this.RenameMenuItem,
            this.DeleteMenuItem,
            this.PropertyMenuItem});
            this.EntryMenu.Name = "EntryMenu";
            this.EntryMenu.Size = new System.Drawing.Size(113, 92);
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.Size = new System.Drawing.Size(112, 22);
            this.OpenMenuItem.Text = "打开";
            this.OpenMenuItem.Click += new System.EventHandler(this.OpenMenuItem_Click);
            // 
            // RenameMenuItem
            // 
            this.RenameMenuItem.Name = "RenameMenuItem";
            this.RenameMenuItem.Size = new System.Drawing.Size(112, 22);
            this.RenameMenuItem.Text = "重命名";
            this.RenameMenuItem.Click += new System.EventHandler(this.RenameMenuItem_Click);
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.Size = new System.Drawing.Size(112, 22);
            this.DeleteMenuItem.Text = "删除";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // PropertyMenuItem
            // 
            this.PropertyMenuItem.Name = "PropertyMenuItem";
            this.PropertyMenuItem.Size = new System.Drawing.Size(112, 22);
            this.PropertyMenuItem.Text = "属性";
            this.PropertyMenuItem.Click += new System.EventHandler(this.PropertyMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "txt_file.png");
            this.imageList1.Images.SetKeyName(2, "application-x-executable.png");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 453);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.GotoButton);
            this.Controls.Add(this.SearchText);
            this.Controls.Add(this.AddressText);
            this.Controls.Add(this.UpwordButton);
            this.Controls.Add(this.ForwardButton);
            this.Controls.Add(this.BackwordButton);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "模拟文件管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.MainMenu.ResumeLayout(false);
            this.EntryMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button BackwordButton;
        private System.Windows.Forms.Button ForwardButton;
        private System.Windows.Forms.Button UpwordButton;
        private System.Windows.Forms.TextBox AddressText;
        private System.Windows.Forms.TextBox SearchText;
        private System.Windows.Forms.Button GotoButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ContextMenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem CreateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateFolderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreatetxtMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateexeStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FlushMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FormatMenuItem;
        private System.Windows.Forms.ContextMenuStrip EntryMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PropertyMenuItem;
        private System.Windows.Forms.ImageList imageList1;
    }
}

