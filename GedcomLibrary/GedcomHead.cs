using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GedcomLibrary
{
  public class GedcomHead
  {
    [XmlElement("Sour")]
    public GedcomValue Source { get; set; }
  }
}