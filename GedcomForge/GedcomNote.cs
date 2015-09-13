using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace GedcomForge
{
  public class GedcomNote
  {
    [XmlAttribute("Content")]
    public string Note { get; set; }

    [XmlElement("Cont")]
    public List<GedcomValue> Contents { get; set; }
  }
}