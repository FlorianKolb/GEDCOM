using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GedcomLibrary
{
  public class GedcomMappingAttribute : Attribute
  {
    public string Path { get; set; }
    
    public GedcomMappingAttribute(string path)
    {
      this.Path = path;
    }
  }
}