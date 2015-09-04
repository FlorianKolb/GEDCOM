using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GedcomForge
{
  /// <summary>
  /// Extended Regex
  /// </summary>
  public class RegexEx : Regex
  {
    public RegexEx() : base()
    {

    }

    public RegexEx(string pattern) : base(pattern, RegexOptions.Compiled)
    {

    }

    public bool Match(string input, out Match match)
    {
      match = base.Match(input);
      return match.Success;
    }
  }
}