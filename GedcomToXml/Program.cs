using CommandLine;
using CommandLine.Text;
using GedcomForge;
using System;
using System.Xml.Linq;

namespace GedcomToXml
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Console.Title = "GedcomToXml";

      if (args.Length > 0)
      {
        Options commandLineOptions = new Options();
        Parser.Default.ParseArguments(args, commandLineOptions);

        XDocument document = GedcomReader.ToXml(commandLineOptions.GedcomFile);
        document.Save(commandLineOptions.OutputFile);
      }
      else
      {
        Console.WriteLine("GedcomToXml");
        Console.WriteLine("Copyright (c) Florian Kolb 2015");
        Console.WriteLine();
        Console.WriteLine("Usage:");
        HelpText helpText = HelpText.AutoBuild(new Options());
        helpText.FormatOptionHelpText += HelpText_FormatOptionHelpText;
        helpText.AddOptions(new Options());
      }
    }

    private static void HelpText_FormatOptionHelpText(object sender, FormatOptionHelpTextEventArgs e)
    {
      Console.WriteLine("-{0} {1}", e.Option.ShortName, e.Option.HelpText);
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