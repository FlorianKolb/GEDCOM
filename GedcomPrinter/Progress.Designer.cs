namespace Gedcom.NET
{
  partial class Progress
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Progress));
      this.progressBar1 = new System.Windows.Forms.ProgressBar();
      this.progressLabel = new System.Windows.Forms.Label();
      this.valueLabel = new System.Windows.Forms.Label();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // progressBar1
      // 
      this.tableLayoutPanel2.SetColumnSpan(this.progressBar1, 2);
      this.progressBar1.Location = new System.Drawing.Point(3, 3);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(255, 23);
      this.progressBar1.TabIndex = 0;
      // 
      // progressLabel
      // 
      this.progressLabel.AutoSize = true;
      this.progressLabel.Location = new System.Drawing.Point(3, 30);
      this.progressLabel.Name = "progressLabel";
      this.progressLabel.Size = new System.Drawing.Size(10, 13);
      this.progressLabel.TabIndex = 1;
      this.progressLabel.Text = "-";
      // 
      // valueLabel
      // 
      this.valueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.valueLabel.AutoSize = true;
      this.valueLabel.Location = new System.Drawing.Point(248, 30);
      this.valueLabel.Name = "valueLabel";
      this.valueLabel.Size = new System.Drawing.Size(10, 13);
      this.valueLabel.TabIndex = 2;
      this.valueLabel.Text = "-";
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.19923F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.80077F));
      this.tableLayoutPanel2.Controls.Add(this.progressLabel, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.valueLabel, 1, 1);
      this.tableLayoutPanel2.Controls.Add(this.progressBar1, 0, 0);
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(261, 61);
      this.tableLayoutPanel2.TabIndex = 4;
      // 
      // Progress
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(261, 61);
      this.Controls.Add(this.tableLayoutPanel2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Progress";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Fortschritt";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.Progress_Load);
      this.tableLayoutPanel2.ResumeLayout(false);
      this.tableLayoutPanel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ProgressBar progressBar1;
    private System.Windows.Forms.Label progressLabel;
    private System.Windows.Forms.Label valueLabel;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
  }
}