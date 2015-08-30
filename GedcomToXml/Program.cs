using CommandLine;
using GedcomLibrary;
using System;
using System.Xml.Linq;

namespace GedcomToXml
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Title = "GedcomToXml";

      Options commandLineOptions = new Options();
      Parser.Default.ParseArguments(args, commandLineOptions);

      XDocument document = GedcomReader.ToXml(commandLineOptions.GedcomFile);
      document.Save(commandLineOptions.OutputFile);
    }
  }

  public class Options
  {
    [Option('i', "input", Required = true, HelpText = "Input GEDCOM file")]
    public string GedcomFile { get; set; }
    [Option('o', "output", Required = true, HelpText = "Output XML file")]
    public string OutputFile { get; set; }
  }
}