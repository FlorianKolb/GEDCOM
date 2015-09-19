using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Gedcom.NET
{
  public static class Shared
  {
    public static void AlternateHighlightRows(this ListView listView)
    {
      int i = 0;
      foreach (ListViewItem item in listView.Items)
      {
        if (i % 2 == 1)
          item.BackColor = Color.LightYellow;
        i++;
      }
    }

    public static string FormatBytes(this long input)
    {
      string[] sizes = { "B", "KB", "MB", "GB" };
      double len = input;
      int order = 0;
      while (len >= 1024 && order + 1 < sizes.Length)
      {
        order++;
        len = len / 1024;
      }
      string result = string.Format("{0:0.##} {1}", len, sizes[order]);
      return result;
    }
  }
}