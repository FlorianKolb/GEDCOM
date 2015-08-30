using System.Diagnostics;
using System.Xml.Serialization;

namespace GedcomLibrary
{
  [XmlRoot("Name")]
  [DebuggerDisplay("{Name} ({Givenname} {Surname})")]
  public class GedcomName
  {
    [XmlElement("Givn")]
    public GedcomValue Givenname { get; set; }
    [XmlElement("Surn")]
    public GedcomValue Surname { get; set; }
    [XmlElement("_mar")]
    public GedcomValue MarriedName { get; set; }
    [XmlElement("Nick")]
    public GedcomValue Nick { get; set; }
    [XmlAttribute("Content")]
    public string Name { get; set; }

    public override string ToString()
    {
      return this.Name;
    }
  }
}