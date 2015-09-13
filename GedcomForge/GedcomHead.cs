using System.Xml.Serialization;

namespace GedcomForge
{
  /// <summary>
  /// Represents the head of the GEDCOM file.
  /// </summary>
  public class GedcomHead
  {
    [XmlElement("Sour")]
    public GedcomSource Source { get; set; }
    [XmlElement("File")]
    public GedcomValue OriginalFile { get; set; }
    [XmlElement("Note")]
    public GedcomNote Note { get; set; }
    [XmlElement("Date")]
    public GedcomValue Date { get; set; }
    [XmlElement("Addr")]
    public GedcomValue Address { get; set; }
    [XmlElement("Lang")]
    public GedcomValue Language { get; set; }
    [XmlElement("Email")]
    public GedcomValue Email { get; set; }
  }
}