using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace GedcomForge
{
  public class GedcomException : Exception
  {
    public GedcomException() : base() { }

    public GedcomException(string message) : base(message) { }
  }
}