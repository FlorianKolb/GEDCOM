# GedcomForge
###### Travis CI Status: ![Build Status](https://travis-ci.org/FlorianKolb/GEDCOM.svg)

Target .NET-Framework Version: 3.5

GedcomForge is a wrapper library for GEDCOM files. It also contains validation of GEDCOM files and serialization to XML.
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
