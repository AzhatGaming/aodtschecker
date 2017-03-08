using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Common
{
    public static class XmlTools
    {
        public static T DeserializeXMLFromString<T>(string xmlString)
        {
            T returnObject = default(T);
            if (string.IsNullOrEmpty(xmlString)) return default(T);

            try
            {
                xmlString = xmlString.Substring(xmlString.IndexOf("<?xml"));

                var serializer = new XmlSerializer(typeof(T));
                using (TextReader reader = new StringReader(xmlString))
                {
                    returnObject = (T)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("{0}, {1}", ex, DateTime.Now));
            }
            return returnObject;
        }

        public static XmlDocument SerializeXmlObject<T>(T xmlObject)
        {
            var returnObject = new XmlDocument();
            var xmlDeclaration = returnObject.CreateXmlDeclaration("1.0", "UTF-8", null);
            var xmlRoot = returnObject.DocumentElement;
            returnObject.InsertBefore(xmlDeclaration, xmlRoot);

            var xmlSerializer = new XmlSerializer(typeof(T));
            using (var stringWriter = new StringWriter())
            {
                using (var xmlWriter = XmlWriter.Create(stringWriter))
                {
                    xmlSerializer.Serialize(xmlWriter, xmlObject);
                    returnObject.LoadXml(stringWriter.ToString());
                }
            }
            return returnObject;
        }
    }
}
