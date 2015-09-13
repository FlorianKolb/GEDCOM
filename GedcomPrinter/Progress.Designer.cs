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
      this.cancelButton = new System.Windows.Forms.Button();
      this.tableLayoutPanel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // progressBar1
      // 
      this.tableLayoutPanel2.SetColumnSpan(this.progressBar1, 2);
      this.progressBar1.Location = new System.Drawing.Point(3, 3);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new System.Drawing.Size(337, 23);
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
      this.valueLabel.Location = new System.Drawing.Point(330, 30);
      this.valueLabel.Name = "valueLabel";
      this.valueLabel.Size = new System.Drawing.Size(10, 13);
      this.valueLabel.TabIndex = 2;
      this.valueLabel.Text = "-";
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.5102F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.4898F));
      this.tableLayoutPanel2.Controls.Add(this.progressLabel, 0, 1);
      this.tableLayoutPanel2.Controls.Add(this.valueLabel, 1, 1);
      this.tableLayoutPanel2.Controls.Add(this.progressBar1, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.cancelButton, 1, 2);
      this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 3;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.3871F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.6129F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 133F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(343, 196);
      this.tableLayoutPanel2.TabIndex = 4;
      // 
      // cancelButton
      // 
      this.cancelButton.Location = new System.Drawing.Point(261, 65);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(75, 23);
      this.cancelButton.TabIndex = 3;
      this.cancelButton.Text = "Abbrechen";
      this.cancelButton.UseVisualStyleBackColor = true;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // Progress
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(343, 94);
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
    private System.Windows.Forms.Button cancelButton;
  }
}