using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GedcomLibrary
{
  public class GedcomValue
  {
    [XmlAttribute("Content")]
    public string Content { get; set; }

    public override string ToString()
    {
      return this.Content;
    }
  }
}