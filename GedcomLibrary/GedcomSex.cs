using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GedcomLibrary
{
  [XmlRoot("Sex")]
  public class GedcomSex
  {
    [XmlAttribute("Content")]
    public string Sex { get; set; }

    public override string ToString()
    {
      return this.Sex;
    }
  }
}