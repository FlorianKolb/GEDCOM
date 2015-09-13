using System.Diagnostics;
using System.Xml.Serialization;

namespace GedcomForge
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
      if (!string.IsNullOrEmpty(this.Name))
        return this.Name.Replace("/", string.Empty);

      return string.Format("{0} {1}", this.Givenname, this.Surname);
    }
  }
}