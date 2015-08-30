# GEDCOM Library (.NET)

Target .NET-Framework Version: 4.5.2

This repository contains a tool for converting GEDCOM files to XML and a library which provides 
encapsulating GEDCOM files into .NET-classes and XML. A provisional validation of GEDCOM files in also included.
<br/>
The library can handle GEDCOM v5.5 files.

# Documentation

The <code>GedcomReader</code> class provides methods for encapsulating GEDCOM files.<br/><br/>
Parse GEDCOM file into XML:<br/>
<code>XDocument document = GedcomReader.ToXml("file.ged");</code>
<br/><br/>
Encapsulate GEDCOM file into class:<br/>
<code>GedcomFile file = GedcomReader.ToGedcomFile("file.ged");</code>


