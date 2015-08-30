using System.Xml.Serialization;

namespace GedcomLibrary
{
  /// <summary>
  /// Represents the head of the GEDCOM file.
  /// </summary>
  public class GedcomHead
  {
    [XmlElement("Sour")]
    public GedcomSource Source { get; set; }
  }
}