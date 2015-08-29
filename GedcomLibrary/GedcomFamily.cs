using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GedcomLibrary
{
  public class GedcomFamily
  {
    [XmlAttribute("Id")]
    public string Identifier { get; set; }
    [XmlElement("Husb")]
    public GedcomIndividual Husband { get; set; }
    [XmlElement("Wife")]
    public GedcomIndividual Wife { get; set; }
    [XmlElement("Chil")]
    public List<GedcomIndividual> Children { get; set; }
  }
}