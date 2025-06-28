using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string xmlPath = "Hotels.xml";
            string xsdPath = "Hotels.xsd";
            string xslPath = "Hotels.xsl";
            string outputPath = "Hotels.html";

            // 1. Validate XML against Schema
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, xsdPath);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);

            using (XmlReader reader = XmlReader.Create(xmlPath, settings))
            {
                while (reader.Read()) { }
            }

            Console.WriteLine("XML validation complete.");

            // 2. Transform XML to HTML using XSL
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xslPath);
            xslt.Transform(xmlPath, outputPath);

            Console.WriteLine("Transformation complete. Output: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR: " + ex.Message);
        }
    }

    static void ValidationCallback(object sender, ValidationEventArgs e)
    {
        if (e.Severity == XmlSeverityType.Warning)
            Console.WriteLine("WARNING: " + e.Message);
        else if (e.Severity == XmlSeverityType.Error)
            Console.WriteLine("ERROR: " + e.Message);
    }
}
