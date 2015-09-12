using System.Diagnostics;
using System.Xml.Serialization;

namespace GedcomForge
{
  [DebuggerDisplay("{Date} ({Address})")]
  public class GedcomDate
  {
    [XmlElement("Date")]
    public GedcomValue Date { get; set; }
    [XmlElement("Plac")]
    public GedcomValue Place { get; set; }
    [XmlElement("Addr")]
    public GedcomAddress Address { get; set; }

    public override string ToString()
    {
      return this.Date?.ToString();
    }
  }
}