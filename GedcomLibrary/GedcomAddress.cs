using System.Diagnostics;
using System.Xml.Serialization;

namespace GedcomLibrary
{
  [DebuggerDisplay("{City} {State} {Country}")]
  public class GedcomAddress
  {
    [XmlElement("City")]
    public GedcomValue City { get; set; }
    [XmlElement("Stae")]
    public GedcomValue State { get; set; }
    [XmlElement("Ctry")]
    public GedcomValue Country { get; set; }

    public override string ToString()
    {
      return string.Format("{0} {1} {2}", this.City.Content, this.State.Content, this.Country.Content);
    }
  }
}