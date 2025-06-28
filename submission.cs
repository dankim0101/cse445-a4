using System;
using System.Xml;
using System.Xml.Schema;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    public class Program
    {
        // TODO: 자신의 GitHub Pages URL로 변경하세요.
        public static string xmlURL = "https://yourusername.github.io/cse445-a4/Hotels.xml";
        public static string xmlErrorURL = "https://yourusername.github.io/cse445-a4/HotelsErrors.xml";
        public static string xsdURL = "https://yourusername.github.io/cse445-a4/Hotels.xsd";

        public static void Main(string[] args)
        {
            // 1) 정상 XML 검증
            string result = Verification(xmlURL, xsdURL);
            Console.WriteLine(result);

            // 2) 오류 XML 검증
            result = Verification(xmlErrorURL, xsdURL);
            Console.WriteLine(result);

            // 3) 정상 XML을 JSON으로 변환
            result = Xml2Json(xmlURL);
            Console.WriteLine(result);
        }

        // Q2.1: XML을 XSD로 검증. 유효하면 "No Error", 아니면 예외 메시지 반환.
        public static string Verification(string xmlUrl, string xsdUrl)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, xsdUrl);
                settings.ValidationType = ValidationType.Schema;
                settings.ValidationEventHandler += (sender, e) =>
                {
                    throw new Exception(e.Message);
                };

                using (XmlReader reader = XmlReader.Create(xmlUrl, settings))
                {
                    while (reader.Read()) { }
                }

                return "No Error";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        // Q2.2: XML을 로드하여 JSON으로 직렬화
        public static string Xml2Json(string xmlUrl)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlUrl);
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            return jsonText;
        }
    }
}
