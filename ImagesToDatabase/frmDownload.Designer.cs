namespace ImagesToDatabase
{
    partial class frmDownload
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
            this.txtSelectedFolder = new System.Windows.Forms.TextBox();
            this.btnSelectDownloadFolder = new System.Windows.Forms.Button();
            this.btnLoadAndVarify = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTotalFilesFound = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblNewFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lblAlreadyUploadedFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnDownlaodFiles = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSelectedFolder
            // 
            this.txtSelectedFolder.Location = new System.Drawing.Point(2, 3);
            this.txtSelectedFolder.Name = "txtSelectedFolder";
            this.txtSelectedFolder.Size = new System.Drawing.Size(1180, 20);
            this.txtSelectedFolder.TabIndex = 1;
            // 
            // btnSelectDownloadFolder
            // 
            this.btnSelectDownloadFolder.Location = new System.Drawing.Point(88, 29);
            this.btnSelectDownloadFolder.Name = "btnSelectDownloadFolder";
            this.btnSelectDownloadFolder.Size = new System.Drawing.Size(257, 26);
            this.btnSelectDownloadFolder.TabIndex = 4;
            this.btnSelectDownloadFolder.Text = "Select Downlaod Folder";
            this.btnSelectDownloadFolder.UseVisualStyleBackColor = true;
            this.btnSelectDownloadFolder.Click += new System.EventHandler(this.btnSelectDownloadFolder_Click);
            // 
            // btnLoadAndVarify
            // 
            this.btnLoadAndVarify.Enabled = false;
            this.btnLoadAndVarify.Location = new System.Drawing.Point(351, 29);
            this.btnLoadAndVarify.Name = "btnLoadAndVarify";
            this.btnLoadAndVarify.Size = new System.Drawing.Size(257, 26);
            this.btnLoadAndVarify.TabIndex = 5;
            this.btnLoadAndVarify.Text = "Laod and Verify Database files with Folder files";
            this.btnLoadAndVarify.UseVisualStyleBackColor = true;
            this.btnLoadAndVarify.Click += new System.EventHandler(this.btnLoadAndVarify_Click);
            // 
            // listView1
            // 
            this.listView1.CheckBoxes = true;
            this.listView1.Location = new System.Drawing.Point(3, 61);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1179, 442);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTotalFilesFound,
            this.toolStripSplitButton1,
            this.lblNewFiles,
            this.toolStripSplitButton2,
            this.lblAlreadyUploadedFiles});
            this.statusStrip1.Location = new System.Drawing.Point(0, 506);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1189, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTotalFilesFound
            // 
            this.lblTotalFilesFound.Name = "lblTotalFilesFound";
            this.lblTotalFilesFound.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownButtonWidth = 0;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1});
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripSplitButton1.Size = new System.Drawing.Size(15, 20);
            this.toolStripSplitButton1.Text = ":";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(57, 6);
            // 
            // lblNewFiles
            // 
            this.lblNewFiles.Name = "lblNewFiles";
            this.lblNewFiles.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton2.DropDownButtonWidth = 0;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2});
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.toolStripSplitButton2.Size = new System.Drawing.Size(15, 20);
            this.toolStripSplitButton2.Text = ":";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(57, 6);
            // 
            // lblAlreadyUploadedFiles
            // 
            this.lblAlreadyUploadedFiles.Name = "lblAlreadyUploadedFiles";
            this.lblAlreadyUploadedFiles.Size = new System.Drawing.Size(0, 17);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(3, 35);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(70, 17);
            this.chkSelectAll.TabIndex = 11;
            this.chkSelectAll.Text = "Select All";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnDownlaodFiles
            // 
            this.btnDownlaodFiles.Location = new System.Drawing.Point(614, 29);
            this.btnDownlaodFiles.Name = "btnDownlaodFiles";
            this.btnDownlaodFiles.Size = new System.Drawing.Size(257, 26);
            this.btnDownlaodFiles.TabIndex = 12;
            this.btnDownlaodFiles.Text = "Downlaod Files";
            this.btnDownlaodFiles.UseVisualStyleBackColor = true;
            this.btnDownlaodFiles.Click += new System.EventHandler(this.btnDownlaodFiles_Click);
            // 
            // frmDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 528);
            this.Controls.Add(this.btnDownlaodFiles);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnLoadAndVarify);
            this.Controls.Add(this.btnSelectDownloadFolder);
            this.Controls.Add(this.txtSelectedFolder);
            this.Name = "frmDownload";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Download Fiels from database";
            this.Load += new System.EventHandler(this.frmDownload_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSelectedFolder;
        private System.Windows.Forms.Button btnSelectDownloadFolder;
        private System.Windows.Forms.Button btnLoadAndVarify;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalFilesFound;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel lblNewFiles;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel lblAlreadyUploadedFiles;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnDownlaodFiles;
    }
}