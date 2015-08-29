using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedcomLibrary
{
  public class GedcomRelation
  {
    public enum GedcomRelationType
    {
      Wife,
      Husband,
      Widow,
      Child
    }

    public GedcomRelationType RelationType { get; set; }
    public GedcomIndividual Target { get; set; }
  }
}
