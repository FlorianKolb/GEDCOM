using GedcomForge;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Gedcom.NET
{
  public partial class MainWindow : Form
  {
    GedcomFile file;

    public MainWindow()
    {
      InitializeComponent();
      RecentFilesManager.RecentFilesChanged += ReloadRecentFiles;
      this.ReloadRecentFiles();
    }

    private void ReloadRecentFiles()
    {
      recentFiles.DropDownItems.Clear();

      foreach (KeyValuePair<int, string> file in RecentFilesManager.Files)
      {
        ToolStripMenuItem item = new ToolStripMenuItem();
        item.Text = string.Format("{0} {1}", file.Key, file.Value);
        item.Image = Properties.Resources.bullet_orange;
        item.Click +=
          (sender, e) =>
          {
            if (File.Exists(file.Value))
            {
              this.LoadFile(file.Value);
            }
            else
            {
              if (MessageBox.Show(string.Format("Die Datei '{0}' konnte nicht mehr gefunden werden. Möchten Sie diese aus der Liste der zuletzt geöffneten Dateien entfernen?", file.Value), "Zuletzt geöffnete Dateien", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
              {
                RecentFilesManager.RemoveFile(file.Value);
              }
            }
          };

        recentFiles.DropDownItems.Add(item);
      }

      if (RecentFilesManager.Files.Count > 0)
      {
        ToolStripSeparator separator = new ToolStripSeparator();
        recentFiles.DropDownItems.Add(separator);

        ToolStripMenuItem clearRecentFiles = new ToolStripMenuItem();
        clearRecentFiles.Text = "Liste leeren";
        clearRecentFiles.Image = Properties.Resources.delete;
        clearRecentFiles.Click +=
         (sender, e) =>
         {
           if (MessageBox.Show("Möchten Sie die Liste der zuletzt geöffneten Dateien wirklich löschen?", "Zuletzt geöffnete Dateien", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
           {
             RecentFilesManager.RemoveAllFiles();
           }
         };

        recentFiles.DropDownItems.Add(clearRecentFiles);
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void LoadFile(string filename)
    {
      Progress progress = new Progress();
      progress.Show();

      familyTreeView.Nodes.Clear();

      progress.ReportProgress(2);
      Application.DoEvents();
      this.file = GedcomReader.ToGedcomFile(filename);
      progress.ReportProgress(5);
      Application.DoEvents();

      double increaseValue = (double)95 / file.Families.Count;
      double currentValue = 5;

      foreach (GedcomFamily family in file.Families)
      {
        if (family.Children.Count == 0)
          progress.ReportProgress(string.Concat("Load family ", family.Identifier));

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
          progress.ReportProgress(string.Concat("Load family ", family.Identifier, " (", family.Children.Count, " children)"));

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
        progress.ReportProgress((int)currentValue);
        Application.DoEvents();
        currentValue += increaseValue;

        famNode.ExpandAll();
      }

      familyTreeView.Nodes[0].EnsureVisible();

      progress.ReportProgress(100);

      statusLabel.Text = string.Format("GEDCOM Source: {0} ({1})", this.file.Head.Source.Name, this.file.Head.Source.Version);

      progress.Close();
    }

    private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void öffnenToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.OpenFile();
    }

    private void OpenFile()
    {
      OpenFileDialog ofd = new OpenFileDialog();
      ofd.Filter = "Gedcom Datei (*.ged)|*.ged";

      if (ofd.ShowDialog() == DialogResult.OK)
      {
        this.LoadFile(ofd.FileName);
        RecentFilesManager.AddFile(ofd.FileName);
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
          string file = individual.Objects.Where(p => p.Form.Content.StartsWith("image/")).FirstOrDefault()?.File.Content;

          pictureBox1.ImageLocation = file;
        }
        else
        {
          pictureBox1.ImageLocation = string.Empty;
        }
      }
    }

    private void infToolStripMenuItem_Click(object sender, EventArgs e)
    {
      GedcomFileInformation info = new GedcomFileInformation();
      info.LoadFile(this.file);
      info.ShowDialog();
    }
  }
}