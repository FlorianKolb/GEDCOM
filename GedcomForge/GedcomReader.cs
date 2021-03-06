﻿using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace GedcomForge
{
  /// <summary>
  /// Provides methods for encapsulating GEDCOM files.
  /// </summary>
  public static class GedcomReader
  {
    private enum GedcomEntryLevel
    {
      Zero = 0,
      One = 1,
      Two = 2,
      Three = 3
    }

    private static readonly RegexEx indiStartRegex = new RegexEx(@"\s*\d\s@(?<ID>.*)@\sINDI");
    private static readonly RegexEx familyStartRegex = new RegexEx(@"\s*\d\s@(?<ID>.*)@\sFAM");
    private static readonly RegexEx valueRegex = new RegexEx(@"\s*(?<NUMBER>\d)\s(?<CAPTURE>.*?)\s(?<VALUE>.*)");
    private static readonly RegexEx groupRegex = new RegexEx(@"\s*(?<NUMBER>\d)\s(?<CAPTURE>[A-Z|_]*)\Z");

    private static readonly string headerDefinition = "0 HEAD";
    private static readonly string endOfFileDefinition = "0 TRLR";

    public delegate void ReaderProgressDelegate(string progress);
    public static event ReaderProgressDelegate ReaderProgress;

    private static bool cancel = false;

    private static void RaiseProgress(string progress)
    {
      if (ReaderProgress != null)
        ReaderProgress(progress);
    }

    public static void Cancel()
    {
      cancel = true;
    }

    /// <summary>
    /// Check if GEDCOM file has header/EOF definition and if it's in correct format.
    /// That means every entry should match at least to one of the regex expressions.
    /// </summary>
    /// <param name="filename">The path to the GEDCOM file</param>
    private static void Validate(string filename)
    {
      RaiseProgress("Start validating");

      bool headerIsMatched = false;
      bool endOfFileIsMatched = false;

      using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
      {
        using (StreamReader reader = new StreamReader(fileStream))
        {
          int i = 1;

          while (!reader.EndOfStream)
          {
            string currentLine = reader.ReadLine();

            if (currentLine.TrimStart().StartsWith(headerDefinition))
            {
              RaiseProgress("Found header definition");
              //everything is ok in this line, and we matched the header
              headerIsMatched = true;
            }
            if (currentLine.TrimStart().StartsWith(endOfFileDefinition))
            {
              RaiseProgress("Found end of file definition");
              //everything is ok in this line, and we matched EOF
              endOfFileIsMatched = true;
            }
            else if (indiStartRegex.IsMatch(currentLine) || familyStartRegex.IsMatch(currentLine) ||
               valueRegex.IsMatch(currentLine) || groupRegex.IsMatch(currentLine))
            {
              //everything is ok in this line
            }
            else
            {
              throw new GedcomException(string.Format("Line {0} is invalid: '{1}'", i, currentLine));
            }

            i++;
          }

          if (!headerIsMatched)
            throw new GedcomException("The given GEDCOM file does not contain a header definition! (0 HEAD)");

          if (!endOfFileIsMatched)
            throw new GedcomException("The given GEDCOM file does not contain a end of file definition! (0 TRLR)");
        }
      }

      RaiseProgress("Gedcom file is valid");
    }

    /// <summary>
    /// Encapsulates the given GEDCOM file. 
    /// </summary>
    /// <param name="filename">Path to the GEDCOM file</param>
    /// <returns></returns>
    public static GedcomFile ToGedcomFile(string filename)
    {
      cancel = false;
      XDocument doc = ToXml(filename);

      XDocument outputDocument = new XDocument();

      XslCompiledTransform transform = new XslCompiledTransform();

      using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("GedcomForge.XML.Transform.GedcomFamilyTransform.xslt"))
      {
        using (StreamReader reader = new StreamReader(stream))
        {
          string result = reader.ReadToEnd();
          using (MemoryStream memory = new MemoryStream())
          {
            byte[] data = Encoding.Default.GetBytes(result);
            memory.Write(data, 0, data.Length);
            memory.Seek(0, SeekOrigin.Begin);

            transform.Load(XmlReader.Create(memory));

            StringBuilder sb = new StringBuilder();

            using (XmlWriter xmlWriter = XmlWriter.Create(sb))
            {
              transform.Transform(doc.CreateReader(), xmlWriter);
            }

            outputDocument = XDocument.Parse(sb.ToString());
          }
        }
      }
      
      RaiseProgress("Deserialize XML");

      XmlSerializer serializer = new XmlSerializer(typeof(GedcomFile));

      return (GedcomFile)serializer.Deserialize(outputDocument.CreateReader());
    }

    /// <summary>
    /// Encapsulates a GEDCOM file to XML.
    /// </summary>
    /// <param name="filename">The path to the GEDCOM file</param>
    /// <returns></returns>
    public static XDocument ToXml(string filename)
    {
      Validate(filename);

      RaiseProgress("Transform to XML");

      XDocument doc = XDocument.Parse("<GedcomFile/>");

      using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
      {
        using (StreamReader reader = new StreamReader(fileStream))
        {
          XElement currentElement = null;
          XElement previousElement = null;
          GedcomEntryLevel previousLevel = GedcomEntryLevel.Zero;
          Match match = null;
          string currentLine, id, capture, number, value, elementName = string.Empty;

          while (!reader.EndOfStream)
          {
            if (cancel)
              break;

            currentLine = reader.ReadLine();

            if (indiStartRegex.Match(currentLine, out match))
            {
              if (currentElement != null)
                doc.Root.Add(currentElement);

              previousElement = null;
              id = match.Groups["ID"].Value;

              RaiseProgress(string.Concat("Parse individual ", id));

              currentElement = new XElement("Individual", new XAttribute("Id", id));
            }
            else if (familyStartRegex.Match(currentLine, out match))
            {
              if (currentElement != null)
                doc.Root.Add(currentElement);

              previousElement = null;
              id = match.Groups["ID"].Value;
              
              RaiseProgress(string.Concat("Parse family ", id));

              currentElement = new XElement("Family", new XAttribute("Id", id));
            }
            else if (groupRegex.Match(currentLine, out match))
            {
              capture = match.Groups["CAPTURE"].Value;
              number = match.Groups["NUMBER"].Value;
              
              GedcomEntryLevel level = (GedcomEntryLevel)Enum.Parse(typeof(GedcomEntryLevel), number);

              elementName = capture.ToLower().Remove(0, 1).Insert(0, capture[0].ToString().ToUpper());
              XElement element = new XElement(elementName);

              if (previousElement != null && previousLevel > GedcomEntryLevel.Zero &&
                ((level > previousLevel && previousLevel > GedcomEntryLevel.Zero)) ||
                ((level == previousLevel && level > GedcomEntryLevel.One))
                )
              {
                previousElement.Add(element);
              }
              else if (currentElement != null)
              {
                currentElement.Add(element);
              }
              else
              {
                currentElement = element;
              }

              previousElement = element;
              previousLevel = level;
            }
            else if (valueRegex.Match(currentLine, out match))
            {
              capture = match.Groups["CAPTURE"].Value;
              value = match.Groups["VALUE"].Value;
              number = match.Groups["NUMBER"].Value;

              GedcomEntryLevel level = (GedcomEntryLevel)Enum.Parse(typeof(GedcomEntryLevel), number);
              elementName = capture.ToLower().Remove(0, 1).Insert(0, capture[0].ToString().ToUpper()).Replace("@", string.Empty);

              XElement element = new XElement(elementName,
                new XAttribute("Content", value.StartsWith("@") ?
                value.Replace("@", string.Empty).Trim() : 
                value.Replace("$$", string.Empty).Trim()));

              if (previousElement != null && previousLevel > GedcomEntryLevel.Zero &&
                ((level > previousLevel && previousLevel > GedcomEntryLevel.Zero)) ||
                ((level == previousLevel && level > GedcomEntryLevel.One))
                )
              {
                previousElement.Add(element);
              }
              else
              {
                previousElement = element;
                currentElement.Add(element);
              }

              previousLevel = level;
            }
          }
        }
      }

      RaiseProgress("Transformed to XML");

      return doc;
    }
  }
}