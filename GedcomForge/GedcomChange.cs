using System.Diagnostics;
using System.Xml.Serialization;

namespace GedcomForge
{
  [DebuggerDisplay("{Date} {Time}")]
  public class GedcomChange
  {
    [XmlElement("Date")]
    public GedcomValue Date { get; set; }
    [XmlElement("Time")]
    public GedcomValue Time { get; set; }
  }
}