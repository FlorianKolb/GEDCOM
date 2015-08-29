using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace GedcomLibrary
{
  public class GedcomReader
  {
    private enum GedcomEntryLevel
    {
      Zero = 0,
      One = 1,
      Two = 2,
      Three = 3
    }

    private readonly Regex indiStartRegex = new Regex(@"\s*\d\s@(?<ID>.*)@\sINDI", RegexOptions.Compiled);
    private readonly Regex familyStartRegex = new Regex(@"\s*\d\s@(?<ID>.*)@\sFAM", RegexOptions.Compiled);
    private readonly Regex valueRegex = new Regex(@"\s(?<NUMBER>\d)\s(?<CAPTURE>.{3,4})\s(?<VALUE>.*)", RegexOptions.Compiled);
    private readonly Regex groupRegex = new Regex(@"\s*(?<NUMBER>\d)\s(?<CAPTURE>.{3,4})\Z", RegexOptions.Compiled);

    public GedcomFile ToGedcomFile(string filename)
    {
      XDocument doc = this.ToXml(filename);

      XDocument outputDocument = new XDocument();

      XslCompiledTransform transform = new XslCompiledTransform();

      using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("GedcomLibrary.Transform.GedcomFamilyTransform.xslt"))
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

      //outputDocument.Save("F:\\out.xml");

      XmlSerializer serializer = new XmlSerializer(typeof(GedcomFile));

      return (GedcomFile)serializer.Deserialize(outputDocument.CreateReader());
    }

    public XDocument ToXml(string filename)
    {
      XDocument doc = XDocument.Parse("<GedcomFile/>");

      using (FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
      {
        using (StreamReader reader = new StreamReader(fileStream))
        {
          XElement currentElement = null;
          XElement previousElement = null;
          GedcomEntryLevel previousLevel = GedcomEntryLevel.Zero;

          while (!reader.EndOfStream)
          {
            string currentLine = reader.ReadLine();

            if (indiStartRegex.IsMatch(currentLine))
            {
              if (currentElement != null)
                doc.Root.Add(currentElement);

              previousElement = null;
              Match match = indiStartRegex.Match(currentLine);
              string id = match.Groups["ID"].Value;
              currentElement = new XElement("Individual", new XAttribute("Id", id));
            }
            else if (familyStartRegex.IsMatch(currentLine))
            {
              if (currentElement != null)
                doc.Root.Add(currentElement);

              previousElement = null;
              Match match = familyStartRegex.Match(currentLine);
              string id = match.Groups["ID"].Value;
              currentElement = new XElement("Family", new XAttribute("Id", id));
            }
            else if (groupRegex.IsMatch(currentLine))
            {
              Match match = groupRegex.Match(currentLine);
              string capture = match.Groups["CAPTURE"].Value;
              string number = match.Groups["NUMBER"].Value;

              GedcomEntryLevel level = (GedcomEntryLevel)Enum.Parse(typeof(GedcomEntryLevel), number);

              string elementName = capture.ToLower().Remove(0, 1).Insert(0, capture[0].ToString().ToUpper());
              XElement e = new XElement(elementName);

              if (previousElement != null && previousLevel > GedcomEntryLevel.Zero &&
                ((level > previousLevel && previousLevel > GedcomEntryLevel.Zero)) ||
                ((level == previousLevel && level > GedcomEntryLevel.One))
                )
              {
                previousElement.Add(e);
              }
              else
              {
                currentElement.Add(e);
              }

              previousElement = e;
              previousLevel = level;
            }
            else if (valueRegex.IsMatch(currentLine))
            {
              Match match = valueRegex.Match(currentLine);
              string capture = match.Groups["CAPTURE"].Value;
              string value = match.Groups["VALUE"].Value;
              string number = match.Groups["NUMBER"].Value;

              GedcomEntryLevel level = (GedcomEntryLevel)Enum.Parse(typeof(GedcomEntryLevel), number);
              string elementName = capture.ToLower().Remove(0, 1).Insert(0, capture[0].ToString().ToUpper());

              XElement e = new XElement(elementName, new XAttribute("Content", value.Replace("/", string.Empty).Replace("@", string.Empty)));

              if (previousElement != null && previousLevel > GedcomEntryLevel.Zero &&
                ((level > previousLevel && previousLevel > GedcomEntryLevel.Zero)) ||
                ((level == previousLevel && level > GedcomEntryLevel.One))
                )
              {
                previousElement.Add(e);
              }
              else
              {
                previousElement = e;
                currentElement.Add(e);
              }

              previousLevel = level;
            }
          }
        }
      }

      return doc;
    }
  }
}