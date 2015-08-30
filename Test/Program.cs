using GedcomLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
  class Program
  {
    static void Main(string[] args)
    {
      GedcomReader reader = new GedcomReader();
      GedcomFile file = reader.ToGedcomFile(@"F:\export-BloodTree.ged");
      
      foreach (GedcomIndividual indi in file.Individuals)
      {
        Console.WriteLine(indi.ToString());
      }

      Console.ReadLine();
    }
  }
}
