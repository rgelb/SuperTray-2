namespace SuperTray2
{
    partial class frmAppList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAppList));
            this.toolBarForm = new SuperTray2.ToolStripExtended();
            this.btnAddEntry = new System.Windows.Forms.ToolStripButton();
            this.btnEditEntry = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveEntry = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMoveDownEntry = new System.Windows.Forms.ToolStripButton();
            this.btnMoveUpEntry = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSaveChanges = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvAppList = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chExecutablePath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.toolBarForm.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBarForm
            // 
            this.toolBarForm.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolBarForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddEntry,
            this.btnEditEntry,
            this.btnRemoveEntry,
            this.toolStripSeparator1,
            this.btnMoveDownEntry,
            this.btnMoveUpEntry,
            this.toolStripSeparator2,
            this.btnSaveChanges});
            this.toolBarForm.Location = new System.Drawing.Point(0, 0);
            this.toolBarForm.Name = "toolBarForm";
            this.toolBarForm.Size = new System.Drawing.Size(581, 31);
            this.toolBarForm.TabIndex = 5;
            this.toolBarForm.Text = "toolStrip1";
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnAddEntry.Image")));
            this.btnAddEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(57, 28);
            this.btnAddEntry.Text = "Add";
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // btnEditEntry
            // 
            this.btnEditEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnEditEntry.Image")));
            this.btnEditEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditEntry.Name = "btnEditEntry";
            this.btnEditEntry.Size = new System.Drawing.Size(55, 28);
            this.btnEditEntry.Text = "Edit";
            this.btnEditEntry.Click += new System.EventHandler(this.btnEditEntry_Click);
            // 
            // btnRemoveEntry
            // 
            this.btnRemoveEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveEntry.Image")));
            this.btnRemoveEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveEntry.Name = "btnRemoveEntry";
            this.btnRemoveEntry.Size = new System.Drawing.Size(78, 28);
            this.btnRemoveEntry.Text = "Remove";
            this.btnRemoveEntry.Click += new System.EventHandler(this.btnRemoveEntry_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnMoveDownEntry
            // 
            this.btnMoveDownEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveDownEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDownEntry.Image")));
            this.btnMoveDownEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveDownEntry.Name = "btnMoveDownEntry";
            this.btnMoveDownEntry.Size = new System.Drawing.Size(28, 28);
            this.btnMoveDownEntry.Text = "toolStripButton4";
            this.btnMoveDownEntry.Click += new System.EventHandler(this.btnMoveDownEntry_Click);
            // 
            // btnMoveUpEntry
            // 
            this.btnMoveUpEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMoveUpEntry.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUpEntry.Image")));
            this.btnMoveUpEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveUpEntry.Name = "btnMoveUpEntry";
            this.btnMoveUpEntry.Size = new System.Drawing.Size(28, 28);
            this.btnMoveUpEntry.Text = "toolStripButton5";
            this.btnMoveUpEntry.Click += new System.EventHandler(this.btnMoveUpEntry_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveChanges.Image")));
            this.btnSaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(108, 28);
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.lvAppList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(581, 359);
            this.panel1.TabIndex = 6;
            // 
            // lvAppList
            // 
            this.lvAppList.AllowDrop = true;
            this.lvAppList.BackColor = System.Drawing.Color.DarkSalmon;
            this.lvAppList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chExecutablePath});
            this.lvAppList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAppList.FullRowSelect = true;
            this.lvAppList.LargeImageList = this.imgList;
            this.lvAppList.Location = new System.Drawing.Point(0, 0);
            this.lvAppList.Margin = new System.Windows.Forms.Padding(2);
            this.lvAppList.MultiSelect = false;
            this.lvAppList.Name = "lvAppList";
            this.lvAppList.Size = new System.Drawing.Size(581, 359);
            this.lvAppList.SmallImageList = this.imgList;
            this.lvAppList.TabIndex = 1;
            this.lvAppList.UseCompatibleStateImageBehavior = false;
            this.lvAppList.View = System.Windows.Forms.View.Details;
            this.lvAppList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvAppList_DragDrop);
            this.lvAppList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvAppList_DragEnter);
            this.lvAppList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAppList_MouseDoubleClick);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 100;
            // 
            // chExecutablePath
            // 
            this.chExecutablePath.Text = "Executable Path";
            this.chExecutablePath.Width = 400;
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgList.ImageSize = new System.Drawing.Size(32, 32);
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmAppList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 390);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolBarForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAppList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Super Tray App List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAppList_FormClosing);
            this.toolBarForm.ResumeLayout(false);
            this.toolBarForm.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ToolStripExtended toolBarForm;
        private System.Windows.Forms.ToolStripButton btnAddEntry;
        private System.Windows.Forms.ToolStripButton btnEditEntry;
        private System.Windows.Forms.ToolStripButton btnRemoveEntry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnMoveDownEntry;
        private System.Windows.Forms.ToolStripButton btnMoveUpEntry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnSaveChanges;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lvAppList;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ColumnHeader chExecutablePath;
    }
}