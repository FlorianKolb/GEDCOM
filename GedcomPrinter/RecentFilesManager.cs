using Gedcom.NET.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gedcom.NET
{
  public static class RecentFilesManager
  {
    public delegate void RecentFilesEventHandler();
    public static event RecentFilesEventHandler RecentFilesChanged;

    static RecentFilesManager()
    {
      if (Settings.Default.RecentFiles == null)
        Settings.Default.RecentFiles = new StringCollection();
    }

    public static void AddFile(string file)
    {
      if (!Settings.Default.RecentFiles.Contains(file))
      {
        Settings.Default.RecentFiles.Add(file);
        Settings.Default.Save();

        if (RecentFilesChanged != null)
          RecentFilesChanged();
      }
    }

    public static void RemoveFile(string file)
    {
      Settings.Default.RecentFiles.Remove(file);
      Settings.Default.Save();

      if (RecentFilesChanged != null)
        RecentFilesChanged();
    }

    public static void RemoveAllFiles()
    {
      Settings.Default.RecentFiles.Clear();
      Settings.Default.Save();

      if (RecentFilesChanged != null)
        RecentFilesChanged();
    }

    public static Dictionary<int, string> Files
    {
      get
      {
        Dictionary<int, string> result = new Dictionary<int, string>();

        if (Settings.Default.RecentFiles != null)
        {
          int i = 1;
          foreach (string file in Settings.Default.RecentFiles)
          {
            result.Add(i, file);
            i++;
          }
        }

        return result;
      }
    }
  }
}