<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/hotels">
    <html>
      <body>
        <h2>Hotel Listings</h2>
        <table border="1">
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Location</th>
            <th>Rating</th>
            <th>Price/Night</th>
            <th>Available</th>
          </tr>
          <xsl:for-each select="hotel">
            <tr>
              <td><xsl:value-of select="@id"/></td>
              <td><xsl:value-of select="name"/></td>
              <td><xsl:value-of select="location"/></td>
              <td><xsl:value-of select="rating"/></td>
              <td><xsl:value-of select="pricePerNight"/></td>
              <td><xsl:value-of select="available"/></td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>
