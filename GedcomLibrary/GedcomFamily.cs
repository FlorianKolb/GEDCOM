using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedcomLibrary
{
  public class GedcomFamily
  {
    public string Identifier { get; set; }
    public GedcomIndividual Husband { get; set; }
    public GedcomIndividual Wife { get; set; }
    public List<GedcomIndividual> Children { get; set; }
  }
}