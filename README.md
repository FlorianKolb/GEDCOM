# GEDCOM Library (.NET)

Target .NET-Framework Version: 4.5.2

This repository contains a tool for converting GEDCOM files to XML and a library which provides 
encapsulating GEDCOM files into .NET-classes and XML. A provisional validation of GEDCOM files in also implemented.
<br/>
The library can handle GEDCOM 5.5 files.

# Documentation

The <code>GedcomReader</code> class provides methods for encapsulating GEDCOM files.<br/><br/>
Parse GEDCOM file into XML:<br/>
<code>XDocument document = GedcomReader.ToXml("file.ged");</code>
<br/><br/>
Encapsulate GEDCOM file into class:<br/>
<code>GedcomFile file = GedcomReader.ToGedcomFile("file.ged");</code>

# License

Copyright (c) Florian Kolb 2015

License Agreement

The software may be used, copied and modified freely. 
It may not be sold, licensed or otherwise distributed 
with costs. A change in the source code of this software 
requires a copy of precisely this License Agreement in 
each modified source file and a clear indication to this 
License Agreement in the final product, which uses modified 
parts of this source code, or an entire modified source code 
of this software.
