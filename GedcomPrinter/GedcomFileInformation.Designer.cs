namespace Gedcom.NET
{
  partial class GedcomFileInformation
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GedcomFileInformation));
      this.noteRichTextBox = new System.Windows.Forms.RichTextBox();
      this.propertyListView = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.SuspendLayout();
      // 
      // noteRichTextBox
      // 
      this.noteRichTextBox.Location = new System.Drawing.Point(12, 133);
      this.noteRichTextBox.Name = "noteRichTextBox";
      this.noteRichTextBox.ReadOnly = true;
      this.noteRichTextBox.Size = new System.Drawing.Size(393, 121);
      this.noteRichTextBox.TabIndex = 0;
      this.noteRichTextBox.Text = "";
      // 
      // propertyListView
      // 
      this.propertyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
      this.propertyListView.FullRowSelect = true;
      this.propertyListView.Location = new System.Drawing.Point(12, 12);
      this.propertyListView.Name = "propertyListView";
      this.propertyListView.Size = new System.Drawing.Size(393, 115);
      this.propertyListView.TabIndex = 1;
      this.propertyListView.UseCompatibleStateImageBehavior = false;
      this.propertyListView.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "";
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "";
      // 
      // GedcomFileInformation
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(417, 282);
      this.Controls.Add(this.propertyListView);
      this.Controls.Add(this.noteRichTextBox);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "GedcomFileInformation";
      this.Text = "Gedcom Dateiinformation";
      this.Load += new System.EventHandler(this.GedcomFileInformation_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.RichTextBox noteRichTextBox;
    private System.Windows.Forms.ListView propertyListView;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
  }
}