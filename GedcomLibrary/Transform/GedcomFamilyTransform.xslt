<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="Wife | Husb | Chil">
    <xsl:variable name="id" select="@Content"/>
    <xsl:copy>
      <xsl:copy-of select="//Individual[@Id=$id]"/>
    </xsl:copy>
  </xsl:template>

  <!--<xsl:template match="Individual"/>-->
  
  <xsl:template match="node() | @*">
    <xsl:copy>
      <xsl:copy-of select="@*"/>
      <xsl:apply-templates select="@* | node()"/>
    </xsl:copy>
  </xsl:template>
</xsl:stylesheet>