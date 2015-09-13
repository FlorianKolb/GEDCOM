﻿using GedcomForge;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Gedcom.NET
{
  public partial class MainWindow : Form
  {
    GedcomFile file;
    private bool progressCanceled = false;

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
      this.Enabled = false;

      Progress progress = new Progress();
      progress.Canceled += Progress_Canceled;
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
        if (this.progressCanceled)
          break;

        if (family.Children.Count == 0)
          progress.ReportProgress(string.Concat("Load family ", family.Identifier));

        TreeNode famNode = new TreeNode("Familie") { ImageIndex = 3, SelectedImageIndex = 3 };
        TreeNode husband = new TreeNode() { ImageIndex = 1, SelectedImageIndex = 1, Tag = family.Husband };
        husband.Text = family.Husband != null ? family.Husband.Name.ToString() : string.Empty;
        TreeNode wife = new TreeNode() { ImageIndex = 0, SelectedImageIndex = 0, Tag = family.Wife };
        wife.Text = family.Wife != null ? family.Wife.Name.ToString() : string.Empty;

        famNode.Nodes.AddRange(new TreeNode[] { husband, wife });

        DateTime marriage = new DateTime();
        if (family.Marriage != null && family.Marriage.Date?.Content != null && DateTime.TryParse(family.Marriage.Date.Content, out marriage))
          famNode.Nodes.Add(Guid.NewGuid().ToString(), "Heirat: " + marriage.ToShortDateString(), 2, 2);

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

      if (!this.progressCanceled)
      {
        familyTreeView.Nodes[0].EnsureVisible();
        progress.ReportProgress(100);
        statusLabel.Text = string.Format("GEDCOM Source: {0} ({1})", this.file.Head.Source.Name, this.file.Head.Source.Version);
      }

      progress.Close();

      this.Enabled = true;
      this.progressCanceled = false;

      if (!this.Focused)
        this.Focus();
    }

    private void Progress_Canceled(object sender, EventArgs e)
    {
      this.progressCanceled = true;
      GedcomReader.Cancel();
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

        detailView.Items.Add(new ListViewItem(new string[] { "Name", individual.Name.ToString() }));
        detailView.Items.Add(new ListViewItem(new string[] { "Geschlecht", individual.Sex.ToString().ToLower() == "f" ? "W" : "M" }));
        detailView.Items.Add(new ListViewItem(new string[] { "E-Mail", individual.Email?.ToString() }));
        detailView.Items.Add(new ListViewItem(new string[] { "Geburt", individual.Birth != null && individual.Birth.Date != null ? DateTime.Parse(individual.Birth.Date.Content).ToShortDateString() : string.Empty }));

        if (individual.Death != null && individual.Death.Date != null)
          detailView.Items.Add(new ListViewItem(new string[] { "Tod", DateTime.Parse(individual.Death.Date.Content).ToShortDateString() }));

        detailView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

        if (individual.Objects.Count > 0)
        {
          GedcomObject gedcomObject = individual.Objects.Where(p => p.Form.Content.StartsWith("image/")).FirstOrDefault();

          if (!string.IsNullOrEmpty(gedcomObject.File?.Content))
          {
            pictureBox1.ImageLocation = gedcomObject.File?.Content;
            pictureBox1.Tag = new Tuple<string, string>(gedcomObject.Form.Content, gedcomObject.File?.Content);
          }
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

    private void searchButton_Click(object sender, EventArgs e)
    {
      this.Search();
    }

    private void Search()
    {
      if (!string.IsNullOrEmpty(searchTextBox.Text) && this.file != null)
      {
        bool found = false;
        GedcomIndividual individual = this.file.Individuals.Where(p => p.Name.ToString().Contains(searchTextBox.Text)).FirstOrDefault();
        if (individual != null)
        {
          foreach (TreeNode node in familyTreeView.Nodes)
          {
            if (RecursiveSearch(node, individual))
              found = true;
          }
        }

        if (!found)
        {
          MessageBox.Show(string.Concat("Der Suchbegriff '", searchTextBox.Text, "' wurde nicht gefunden"), "Suche", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        familyTreeView.Focus();
      }
    }

    private bool RecursiveSearch(TreeNode node, GedcomIndividual individual)
    {
      if (node.Tag != null)
      {
        GedcomIndividual tag = (GedcomIndividual)node.Tag;

        if (tag.Name.ToString().Equals(individual.Name.ToString()))
        {
          familyTreeView.SelectedNode = node;
          node.EnsureVisible();
          return true;
        }
      }

      if (node.Nodes.Count > 0)
        foreach (TreeNode child in node.Nodes)
          return RecursiveSearch(child, individual);

      return false;
    }

    private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData == Keys.Enter && e.Modifiers == Keys.None)
      {
        this.Search();
      }
    }

    private void bildSpeichernToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Tuple<string, string> data = (Tuple<string, string>)pictureBox1.Tag;

      string filetype = string.Empty;
      switch (data.Item1)
      {
        case "image/jpeg":
        case "image/jpg":
          filetype = "jpg";
          break;
      }

      if (data.Item2.StartsWith("http"))
      {
        WebClient client = new WebClient();
        string tmpFile = string.Concat(Path.GetTempFileName(), filetype);
        client.DownloadFile(data.Item2, tmpFile);

        SaveFileDialog sfd = new SaveFileDialog();
        sfd.Filter = string.Format("*.{0}|*.{0}", filetype);
        
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          File.Copy(tmpFile, sfd.FileName, true);
        }

        File.Delete(tmpFile);
      }
    }
  }
}