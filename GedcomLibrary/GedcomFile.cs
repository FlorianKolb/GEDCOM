using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GedcomLibrary
{
  [XmlRoot("GedcomFile")]
  public class GedcomFile
  {
    [XmlElement("Individual")]
    public List<GedcomIndividual> Individuals { get; set; }
    [XmlElement("Family")]
    public List<GedcomFamily> Families { get; set; }
  }
}