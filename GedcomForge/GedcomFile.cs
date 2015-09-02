using System.Collections.Generic;
using System.Xml.Serialization;

namespace GedcomForge
{
  /// <summary>
  /// Represents a GEDCOM file.
  /// </summary>
  [XmlRoot("GedcomFile")]
  public class GedcomFile
  {
    [XmlElement("Head")]
    public GedcomHead Head { get; set; }
    [XmlElement("Individual")]
    public List<GedcomIndividual> Individuals { get; set; }
    [XmlElement("Family")]
    public List<GedcomFamily> Families { get; set; }
  }
}