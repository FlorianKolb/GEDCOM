using GedcomForge;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gedcom.NET
{
  public partial class MainWindow : Form
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void LoadFile(string filename)
    {
      GedcomFile file = GedcomReader.ToGedcomFile(filename);

      foreach (GedcomFamily family in file.Families)
      {
        TreeNode famNode = new TreeNode("Familie") { ImageIndex = 3, SelectedImageIndex = 3 };
        TreeNode husband = new TreeNode() { ImageIndex = 1, SelectedImageIndex = 1, Tag = family.Husband };
        husband.Text = family.Husband != null ? family.Husband.Name.ToString() : string.Empty;
        TreeNode wife = new TreeNode() { ImageIndex = 0, SelectedImageIndex = 0, Tag = family.Wife };
        wife.Text = family.Wife != null ? family.Wife.Name.ToString() : string.Empty;

        famNode.Nodes.AddRange(new TreeNode[] { husband, wife });

        if (family.Marriage != null)
          famNode.Nodes.Add(Guid.NewGuid().ToString(), "Heirat: " + family.Marriage, 2, 2);

        if (family.Children.Count > 0)
        {
          TreeNode children = new TreeNode("Kinder") { ImageIndex = 3, SelectedImageIndex = 3 };
          
          children.Nodes.AddRange(family.Children.Select(p => new TreeNode(p.Name.ToString()
            )
          {
            ImageIndex =
            p.Sex.Content.ToLower().Equals("m") ? 1 : 0,
            SelectedImageIndex =
            p.Sex.Content.ToLower().Equals("m") ? 1 : 0,
            Tag = p
          }).ToArray());
          famNode.Nodes.Add(children);
        }

        familyTreeView.Nodes.Add(famNode);
      }

      familyTreeView.ExpandAll();

      familyTreeView.Nodes[0].EnsureVisible();
    }

    private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "Gedcom Datei (*.ged)|*.ged";

      if (ofd.ShowDialog() == DialogResult.OK)
      {
        this.LoadFile(ofd.FileName);
      }
    }

    private void infoToolStripMenuItem1_Click(object sender, EventArgs e)
    {
      AboutBox aboutBox = new AboutBox();
      aboutBox.ShowDialog();
    }

    private void familyTreeView_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (e.Node.Tag != null)
      {
        GedcomIndividual individual = (GedcomIndividual)e.Node.Tag;

        detailView.Items.Clear();
        ListViewItem item = new ListViewItem(
          new string[]
          {
            individual.Name.ToString(),
            individual.Sex.ToString(),
            individual.Birth?.ToString(),
            individual.Death?.ToString()
          }
          );

        detailView.Items.Add(item);
        detailView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        if (individual.Objects.Count > 0)
        {
          string file = individual.Objects.Where(p => p.Form.Content.StartsWith("image/")).FirstOrDefault().File.Content;

          pictureBox1.ImageLocation = file;
        }
        else
        {
          pictureBox1.ImageLocation = string.Empty;
        }
      }
    }

    private void familyTreeView_DragDrop(object sender, DragEventArgs e)
    {

    }
  }
}