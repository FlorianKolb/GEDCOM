using GedcomForge;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Gedcom.NET
{
  public partial class GedcomFileInformation : Form
  {
    public GedcomFileInformation()
    {
      InitializeComponent();
    }

    private void GedcomFileInformation_Load(object sender, EventArgs e)
    {

    }

    public void LoadFile(GedcomFile file)
    {
      if (file != null && file.Head?.Note != null)
      {
        string[] lines = new string[]
        {
          file.Head.Note.Note
        }.Union(file.Head.Note.Contents.Select(p => p.Content.Trim()).ToArray()).ToArray();

        noteRichTextBox.Lines = lines;
      }

      propertyListView.Items.Clear();

      propertyListView.Items.Add(new ListViewItem(new string[] { "Source", file.Head.Source?.Name }));
      propertyListView.Items.Add(new ListViewItem(new string[] { "Version", file.Head.Source?.Version?.Content }));
      propertyListView.Items.Add(new ListViewItem(new string[] { "Original file", file.Head.OriginalFile?.Content }));
      propertyListView.Items.Add(new ListViewItem(new string[] { "Family count", file.Families.Count.ToString() }));
      propertyListView.Items.Add(new ListViewItem(new string[] { "Individual count", file.Individuals.Count.ToString() }));
      propertyListView.Items.Add(new ListViewItem(new string[] { "Date", file.Head.Date?.Content }));
      propertyListView.Items.Add(new ListViewItem(new string[] { "Address", file.Head.Address?.Content }));
      propertyListView.Items.Add(new ListViewItem(new string[] { "Language", file.Head.Language?.Content }));
      propertyListView.Items.Add(new ListViewItem(new string[] { "Email", file.Head.Email?.Content }));

      propertyListView.AlternateHighlightRows();
      propertyListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
    }

    private void okButton_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
