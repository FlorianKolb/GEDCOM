using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GedcomLibrary
{
  [XmlRoot("Individual")]
  [DebuggerDisplay("{Name} ({Identifier})")]
  public class GedcomIndividual
  {
    [XmlAttribute("Id")]
    public string Identifier { get; set; }
    [XmlElement("Name")]
    public GedcomName Name { get; set; }
    [XmlElement("Sex")]
    public GedcomSex Sex { get; set; }

    public List<GedcomRelation> Relations { get; set; }

    public override string ToString()
    {
      return string.Format("{0} ({1})", this.Name.ToString(), this.Identifier);
    }
  }
}