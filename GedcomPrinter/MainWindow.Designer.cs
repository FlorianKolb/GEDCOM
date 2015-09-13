namespace Gedcom.NET
{
  partial class MainWindow
  {
    /// <summary>
    /// Erforderliche Designervariable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Verwendete Ressourcen bereinigen.
    /// </summary>
    /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Vom Windows Form-Designer generierter Code

    /// <summary>
    /// Erforderliche Methode für die Designerunterstützung.
    /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
      this.familyTreeView = new System.Windows.Forms.TreeView();
      this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.gedcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.infToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.detailView = new System.Windows.Forms.ListView();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.recentFiles = new System.Windows.Forms.ToolStripMenuItem();
      this.beendenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.infoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.searchTextBox = new System.Windows.Forms.ToolStripTextBox();
      this.searchButton = new System.Windows.Forms.ToolStripButton();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
      this.toolStripContainer1.ContentPanel.SuspendLayout();
      this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
      this.toolStripContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // familyTreeView
      // 
      this.familyTreeView.AllowDrop = true;
      this.familyTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.familyTreeView.ImageIndex = 0;
      this.familyTreeView.ImageList = this.treeViewImageList;
      this.familyTreeView.Location = new System.Drawing.Point(0, 0);
      this.familyTreeView.Name = "familyTreeView";
      this.familyTreeView.SelectedImageIndex = 0;
      this.familyTreeView.Size = new System.Drawing.Size(398, 457);
      this.familyTreeView.TabIndex = 2;
      this.familyTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.familyTreeView_AfterSelect);
      // 
      // treeViewImageList
      // 
      this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
      this.treeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
      this.treeViewImageList.Images.SetKeyName(0, "female.png");
      this.treeViewImageList.Images.SetKeyName(1, "male.png");
      this.treeViewImageList.Images.SetKeyName(2, "heart.png");
      this.treeViewImageList.Images.SetKeyName(3, "group.png");
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.gedcomToolStripMenuItem,
            this.infoToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(723, 24);
      this.menuStrip1.TabIndex = 3;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // dateiToolStripMenuItem
      // 
      this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.öffnenToolStripMenuItem,
            this.toolStripMenuItem1,
            this.recentFiles,
            this.toolStripSeparator1,
            this.beendenToolStripMenuItem});
      this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
      this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
      this.dateiToolStripMenuItem.Text = "Datei";
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(204, 6);
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(204, 6);
      // 
      // gedcomToolStripMenuItem
      // 
      this.gedcomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infToolStripMenuItem});
      this.gedcomToolStripMenuItem.Name = "gedcomToolStripMenuItem";
      this.gedcomToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
      this.gedcomToolStripMenuItem.Text = "Gedcom";
      // 
      // infToolStripMenuItem
      // 
      this.infToolStripMenuItem.Name = "infToolStripMenuItem";
      this.infToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
      this.infToolStripMenuItem.Text = "Dateiinformation";
      this.infToolStripMenuItem.Click += new System.EventHandler(this.infToolStripMenuItem_Click);
      // 
      // infoToolStripMenuItem
      // 
      this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem1});
      this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
      this.infoToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
      this.infoToolStripMenuItem.Text = "Hilfe";
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(0, 0);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.familyTreeView);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
      this.splitContainer1.Size = new System.Drawing.Size(723, 457);
      this.splitContainer1.SplitterDistance = 398;
      this.splitContainer1.TabIndex = 4;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.detailView);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
      this.splitContainer2.Size = new System.Drawing.Size(321, 457);
      this.splitContainer2.SplitterDistance = 225;
      this.splitContainer2.TabIndex = 1;
      // 
      // detailView
      // 
      this.detailView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
      this.detailView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.detailView.FullRowSelect = true;
      this.detailView.Location = new System.Drawing.Point(0, 0);
      this.detailView.Name = "detailView";
      this.detailView.Size = new System.Drawing.Size(321, 225);
      this.detailView.TabIndex = 0;
      this.detailView.UseCompatibleStateImageBehavior = false;
      this.detailView.View = System.Windows.Forms.View.Details;
      // 
      // statusStrip1
      // 
      this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
      this.statusStrip1.Location = new System.Drawing.Point(0, 0);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(723, 22);
      this.statusStrip1.TabIndex = 5;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // statusLabel
      // 
      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Size = new System.Drawing.Size(0, 17);
      // 
      // toolStripContainer1
      // 
      // 
      // toolStripContainer1.BottomToolStripPanel
      // 
      this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
      // 
      // toolStripContainer1.ContentPanel
      // 
      this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
      this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(723, 457);
      this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
      this.toolStripContainer1.Name = "toolStripContainer1";
      this.toolStripContainer1.Size = new System.Drawing.Size(723, 504);
      this.toolStripContainer1.TabIndex = 6;
      this.toolStripContainer1.Text = "toolStripContainer1";
      // 
      // toolStripContainer1.TopToolStripPanel
      // 
      this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(321, 228);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // öffnenToolStripMenuItem
      // 
      this.öffnenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("öffnenToolStripMenuItem.Image")));
      this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
      this.öffnenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
      this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
      this.öffnenToolStripMenuItem.Text = "Öffnen...";
      this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.öffnenToolStripMenuItem_Click);
      // 
      // recentFiles
      // 
      this.recentFiles.Image = ((System.Drawing.Image)(resources.GetObject("recentFiles.Image")));
      this.recentFiles.Name = "recentFiles";
      this.recentFiles.Size = new System.Drawing.Size(207, 22);
      this.recentFiles.Text = "Zuletzt geöffnete Dateien";
      // 
      // beendenToolStripMenuItem
      // 
      this.beendenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("beendenToolStripMenuItem.Image")));
      this.beendenToolStripMenuItem.Name = "beendenToolStripMenuItem";
      this.beendenToolStripMenuItem.Size = new System.Drawing.Size(207, 22);
      this.beendenToolStripMenuItem.Text = "Beenden";
      this.beendenToolStripMenuItem.Click += new System.EventHandler(this.beendenToolStripMenuItem_Click);
      // 
      // infoToolStripMenuItem1
      // 
      this.infoToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("infoToolStripMenuItem1.Image")));
      this.infoToolStripMenuItem1.Name = "infoToolStripMenuItem1";
      this.infoToolStripMenuItem1.Size = new System.Drawing.Size(95, 22);
      this.infoToolStripMenuItem1.Text = "Info";
      this.infoToolStripMenuItem1.Click += new System.EventHandler(this.infoToolStripMenuItem1_Click);
      // 
      // columnHeader5
      // 
      this.columnHeader5.Text = "";
      // 
      // columnHeader6
      // 
      this.columnHeader6.Text = "";
      // 
      // toolStrip1
      // 
      this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
      this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchTextBox,
            this.searchButton});
      this.toolStrip1.Location = new System.Drawing.Point(3, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(202, 25);
      this.toolStrip1.TabIndex = 0;
      // 
      // searchTextBox
      // 
      this.searchTextBox.Name = "searchTextBox";
      this.searchTextBox.Size = new System.Drawing.Size(100, 25);
      this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
      // 
      // searchButton
      // 
      this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
      this.searchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.searchButton.Name = "searchButton";
      this.searchButton.Size = new System.Drawing.Size(66, 22);
      this.searchButton.Text = "Suchen";
      this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
      // 
      // MainWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(723, 528);
      this.Controls.Add(this.toolStripContainer1);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainWindow";
      this.Text = "Gedcom.NET";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.Form1_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
      this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
      this.toolStripContainer1.ContentPanel.ResumeLayout(false);
      this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
      this.toolStripContainer1.TopToolStripPanel.PerformLayout();
      this.toolStripContainer1.ResumeLayout(false);
      this.toolStripContainer1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.TreeView familyTreeView;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem beendenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem1;
    private System.Windows.Forms.ImageList treeViewImageList;
    private System.Windows.Forms.SplitContainer splitContainer1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.ListView detailView;
    private System.Windows.Forms.ToolStripMenuItem recentFiles;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem gedcomToolStripMenuItem;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    private System.Windows.Forms.ToolStripContainer toolStripContainer1;
    private System.Windows.Forms.ToolStripMenuItem infToolStripMenuItem;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.ColumnHeader columnHeader6;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripTextBox searchTextBox;
    private System.Windows.Forms.ToolStripButton searchButton;
  }
}

