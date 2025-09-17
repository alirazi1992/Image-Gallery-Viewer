namespace ImageGalleryViewer
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.FlowLayoutPanel flowGrid;
        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowGrid = new System.Windows.Forms.FlowLayoutPanel();
            this.topBar = new System.Windows.Forms.Panel();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lblPath = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.topBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowGrid
            // 
            this.flowGrid.AutoScroll = true;
            this.flowGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowGrid.Location = new System.Drawing.Point(0, 76);
            this.flowGrid.Name = "flowGrid";
            this.flowGrid.Padding = new System.Windows.Forms.Padding(12);
            this.flowGrid.Size = new System.Drawing.Size(1100, 624);
            this.flowGrid.TabIndex = 0;
            this.flowGrid.WrapContents = true;
            // 
            // topBar
            // 
            this.topBar.Controls.Add(this.btnSelectFolder);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(1100, 48);
            this.topBar.TabIndex = 1;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.AutoSize = true;
            this.btnSelectFolder.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Padding = new System.Windows.Forms.Padding(8);
            this.btnSelectFolder.Size = new System.Drawing.Size(109, 33);
            this.btnSelectFolder.TabIndex = 0;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoEllipsis = true;
            this.lblPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPath.Location = new System.Drawing.Point(0, 48);
            this.lblPath.Name = "lblPath";
            this.lblPath.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.lblPath.Size = new System.Drawing.Size(1100, 28);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "No folder selected";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.flowGrid);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.topBar);
            this.Name = "MainForm";
            this.Text = "🖼 Image Gallery Viewer";
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
