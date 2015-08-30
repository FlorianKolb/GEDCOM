using System.Diagnostics;
using System.Xml.Serialization;

namespace GedcomLibrary
{
  [DebuggerDisplay("{Name} {Version}")]
  public class GedcomSource
  {
    [XmlAttribute("Content")]
    public string Name { get; set; }

    [XmlElement("Vers")]
    public GedcomValue Version { get; set; }
  }
}