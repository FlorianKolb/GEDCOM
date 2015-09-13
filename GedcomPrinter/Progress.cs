using GedcomForge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gedcom.NET
{
  public partial class Progress : Form
  {
    public event EventHandler Canceled;

    public Progress()
    {
      InitializeComponent();
      GedcomReader.ReaderProgress += GedcomReader_ReaderProgress;
    }

    private void GedcomReader_ReaderProgress(string progress)
    {
      progressLabel.Text = progress;
      Application.DoEvents();
    }

    private const int CP_NOCLOSE_BUTTON = 0x200;
    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams myCp = base.CreateParams;
        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        return myCp;
      }
    }

    public void ReportProgress(int progress)
    {
      if (progress <= 100)
      {
        this.progressBar1.Value = progress;
        this.valueLabel.Text = string.Concat(progress, "%");
      }
    }

    public void ReportProgress(string progress)
    {
      this.progressLabel.Text = progress;
    }

    private void Progress_Load(object sender, EventArgs e)
    {

    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
      if (this.Canceled != null)
        this.Canceled(this, new EventArgs());
    }
  }
}
