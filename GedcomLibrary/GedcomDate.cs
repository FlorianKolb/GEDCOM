using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GedcomLibrary
{
  [DebuggerDisplay("{Date} ({Address})")]
  public class GedcomDate
  {
    [XmlElement("Date")]
    public GedcomValue Date { get; set; }
    [XmlElement("Addr")]
    public GedcomAddress Address { get; set; }
  }
}