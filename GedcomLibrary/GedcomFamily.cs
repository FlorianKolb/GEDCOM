using System.Collections.Generic;
using System.Xml.Serialization;

namespace GedcomLibrary
{
  /// <summary>
  /// Represents a family in a GEDCOM file.
  /// </summary>
  public class GedcomFamily
  {
    [XmlAttribute("Id")]
    public string Identifier { get; set; }
    [XmlElement("Husb")]
    public GedcomIndividual Husband { get; set; }
    [XmlElement("Wife")]
    public GedcomIndividual Wife { get; set; }
    [XmlElement("Marr")]
    public GedcomDate Marriage { get; set; }
    [XmlElement("Chil")]
    public List<GedcomIndividual> Children { get; set; }
  }
}