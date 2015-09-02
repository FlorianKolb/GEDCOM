using System.Xml.Serialization;

namespace GedcomForge
{
  public class GedcomValue
  {
    [XmlAttribute("Content")]
    public string Content { get; set; }
    
    public override string ToString()
    {
      return this.Content?.ToString();
    }
  }
}