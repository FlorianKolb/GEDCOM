﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace GedcomForge
{
  /// <summary>
  /// Represents an individual in a GEDCOM file.
  /// </summary>
  [DebuggerDisplay("{Name} ({Identifier})")]
  public class GedcomIndividual
  {
    [XmlAttribute("Id")]
    public string Identifier { get; set; }
    [XmlElement("Name")]
    public GedcomName Name { get; set; }
    [XmlElement("Sex")]
    public GedcomValue Sex { get; set; }
    [XmlElement("Birt")]
    public GedcomDate Birth { get; set; }
    [XmlElement("Deat")]
    public GedcomDate Death { get; set; }
    [XmlElement("Buri")]
    public GedcomDate Buried { get; set; }
    [XmlElement("Note")]
    public GedcomNote Note { get; set; }
    [XmlElement("_email")]
    public GedcomValue Email { get; set; }
    [XmlElement("Obje")]
    public List<GedcomObject> Objects { get; set; }
    [XmlElement("Chan")]
    public GedcomChange Changed { get; set; }

    public override string ToString()
    {
      return string.Format("{0} ({1})", this.Name.ToString(), this.Identifier);
    }
  }
}