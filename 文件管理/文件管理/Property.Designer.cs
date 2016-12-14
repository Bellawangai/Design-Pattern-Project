namespace 文件管理
{
    partial class Property
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Property));
            this.EntryName = new System.Windows.Forms.TextBox();
            this.EntryTypePro = new System.Windows.Forms.Label();
            this.EntrySizePro = new System.Windows.Forms.Label();
            this.EntryBlockPro = new System.Windows.Forms.Label();
            this.EntryPositionPro = new System.Windows.Forms.Label();
            this.ChangedTimePro = new System.Windows.Forms.Label();
            this.EntryType = new System.Windows.Forms.Label();
            this.EntrySize = new System.Windows.Forms.Label();
            this.EntryBlock = new System.Windows.Forms.Label();
            this.EntryPosition = new System.Windows.Forms.Label();
            this.ChangedTime = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.EntryPic = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.EntryPic)).BeginInit();
            this.SuspendLayout();
            // 
            // EntryName
            // 
            this.EntryName.Location = new System.Drawing.Point(126, 59);
            this.EntryName.Name = "EntryName";
            this.EntryName.Size = new System.Drawing.Size(206, 21);
            this.EntryName.TabIndex = 1;
            this.EntryName.TextChanged += new System.EventHandler(this.EntryName_TextChanged);
            // 
            // EntryTypePro
            // 
            this.EntryTypePro.AutoSize = true;
            this.EntryTypePro.Location = new System.Drawing.Point(71, 148);
            this.EntryTypePro.Name = "EntryTypePro";
            this.EntryTypePro.Size = new System.Drawing.Size(65, 12);
            this.EntryTypePro.TabIndex = 3;
            this.EntryTypePro.Text = "文件类型：";
            // 
            // EntrySizePro
            // 
            this.EntrySizePro.AutoSize = true;
            this.EntrySizePro.Location = new System.Drawing.Point(71, 185);
            this.EntrySizePro.Name = "EntrySizePro";
            this.EntrySizePro.Size = new System.Drawing.Size(65, 12);
            this.EntrySizePro.TabIndex = 4;
            this.EntrySizePro.Text = "文件大小：";
            // 
            // EntryBlockPro
            // 
            this.EntryBlockPro.AutoSize = true;
            this.EntryBlockPro.Location = new System.Drawing.Point(71, 225);
            this.EntryBlockPro.Name = "EntryBlockPro";
            this.EntryBlockPro.Size = new System.Drawing.Size(65, 12);
            this.EntryBlockPro.TabIndex = 5;
            this.EntryBlockPro.Text = "占用空间：";
            // 
            // EntryPositionPro
            // 
            this.EntryPositionPro.AutoSize = true;
            this.EntryPositionPro.Location = new System.Drawing.Point(71, 264);
            this.EntryPositionPro.Name = "EntryPositionPro";
            this.EntryPositionPro.Size = new System.Drawing.Size(65, 12);
            this.EntryPositionPro.TabIndex = 6;
            this.EntryPositionPro.Text = "文件位置：";
            // 
            // ChangedTimePro
            // 
            this.ChangedTimePro.AutoSize = true;
            this.ChangedTimePro.Location = new System.Drawing.Point(71, 303);
            this.ChangedTimePro.Name = "ChangedTimePro";
            this.ChangedTimePro.Size = new System.Drawing.Size(65, 12);
            this.ChangedTimePro.TabIndex = 7;
            this.ChangedTimePro.Text = "修改时间：";
            // 
            // EntryType
            // 
            this.EntryType.AutoSize = true;
            this.EntryType.Location = new System.Drawing.Point(164, 148);
            this.EntryType.Name = "EntryType";
            this.EntryType.Size = new System.Drawing.Size(29, 12);
            this.EntryType.TabIndex = 8;
            this.EntryType.Text = "Edit";
            // 
            // EntrySize
            // 
            this.EntrySize.AutoSize = true;
            this.EntrySize.Location = new System.Drawing.Point(164, 185);
            this.EntrySize.Name = "EntrySize";
            this.EntrySize.Size = new System.Drawing.Size(29, 12);
            this.EntrySize.TabIndex = 9;
            this.EntrySize.Text = "Edit";
            // 
            // EntryBlock
            // 
            this.EntryBlock.AutoSize = true;
            this.EntryBlock.Location = new System.Drawing.Point(164, 225);
            this.EntryBlock.Name = "EntryBlock";
            this.EntryBlock.Size = new System.Drawing.Size(29, 12);
            this.EntryBlock.TabIndex = 10;
            this.EntryBlock.Text = "Edit";
            // 
            // EntryPosition
            // 
            this.EntryPosition.AutoSize = true;
            this.EntryPosition.Location = new System.Drawing.Point(164, 264);
            this.EntryPosition.Name = "EntryPosition";
            this.EntryPosition.Size = new System.Drawing.Size(29, 12);
            this.EntryPosition.TabIndex = 11;
            this.EntryPosition.Text = "Edit";
            // 
            // ChangedTime
            // 
            this.ChangedTime.AutoSize = true;
            this.ChangedTime.Location = new System.Drawing.Point(164, 303);
            this.ChangedTime.Name = "ChangedTime";
            this.ChangedTime.Size = new System.Drawing.Size(29, 12);
            this.ChangedTime.TabIndex = 12;
            this.ChangedTime.Text = "Edit";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(73, 358);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 13;
            this.ConfirmButton.Text = "确定";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(215, 358);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 14;
            this.CancelButton.Text = "取消";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EntryPic
            // 
            this.EntryPic.Location = new System.Drawing.Point(33, 33);
            this.EntryPic.Name = "EntryPic";
            this.EntryPic.Size = new System.Drawing.Size(69, 74);
            this.EntryPic.TabIndex = 0;
            this.EntryPic.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder.png");
            this.imageList1.Images.SetKeyName(1, "txt_file.png");
            this.imageList1.Images.SetKeyName(2, "application-x-executable.png");
            // 
            // Property
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 412);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.ChangedTime);
            this.Controls.Add(this.EntryPosition);
            this.Controls.Add(this.EntryBlock);
            this.Controls.Add(this.EntrySize);
            this.Controls.Add(this.EntryType);
            this.Controls.Add(this.ChangedTimePro);
            this.Controls.Add(this.EntryPositionPro);
            this.Controls.Add(this.EntryBlockPro);
            this.Controls.Add(this.EntrySizePro);
            this.Controls.Add(this.EntryTypePro);
            this.Controls.Add(this.EntryName);
            this.Controls.Add(this.EntryPic);
            this.Name = "Property";
            this.Text = "Property";
            ((System.ComponentModel.ISupportInitialize)(this.EntryPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox EntryPic;
        private System.Windows.Forms.TextBox EntryName;
        private System.Windows.Forms.Label EntryTypePro;
        private System.Windows.Forms.Label EntrySizePro;
        private System.Windows.Forms.Label EntryBlockPro;
        private System.Windows.Forms.Label EntryPositionPro;
        private System.Windows.Forms.Label ChangedTimePro;
        private System.Windows.Forms.Label EntryType;
        private System.Windows.Forms.Label EntrySize;
        private System.Windows.Forms.Label EntryBlock;
        private System.Windows.Forms.Label EntryPosition;
        private System.Windows.Forms.Label ChangedTime;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.ImageList imageList1;
    }
}