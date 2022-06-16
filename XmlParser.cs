using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;

namespace XgApiWrapper
{
    public class XmlParser
    {
        /// <summary>
        /// Parse XML without checking login status
        /// </summary>
        public static List<T> ParseXmlResponse<T>(string xmlResponse)
        {
            List<T> dataItemList = new List<T>();
            using (TextReader textReader = new StringReader(xmlResponse))
            {
                // Read Header
                XmlRootAttribute xRoot = new XmlRootAttribute() { ElementName = "Response" };
                XmlSerializer headerSerializer = new XmlSerializer(typeof(Response), xRoot);
                Response response = (Response)headerSerializer.Deserialize(textReader);

                // Read Data
                XmlSerializer dataSerializer = new XmlSerializer(typeof(T));
                foreach (XElement item in response.Elements)
                {
                    using (XmlReader xmlItemReader = item.CreateReader())
                    {
                        dataItemList.Add((T)dataSerializer.Deserialize(xmlItemReader));
                    }
                }
            }

            return dataItemList;
        }

        /// <summary>
        /// Parse XML with checking login status
        /// </summary>
        public static List<T> ParseXmlResponseAdv<T>(string xmlResponse, out string[] login)
        {
            List<T> dataItemList = new List<T>();
            using (TextReader textReader = new StringReader(xmlResponse))
            {
                // Read Header
                XmlRootAttribute xRoot = new XmlRootAttribute() { ElementName = "Response" };
                XmlSerializer headerSerializer = new XmlSerializer(typeof(Response), xRoot);
                Response response = (Response)headerSerializer.Deserialize(textReader);

                // Set Login
                login = response.Login;

                // Read Data
                XmlSerializer dataSerializer = new XmlSerializer(typeof(T));
                foreach (XElement item in response.Elements)
                {
                    using (XmlReader xmlItemReader = item.CreateReader())
                    {
                        dataItemList.Add((T)dataSerializer.Deserialize(xmlItemReader));
                    }
                }
            }

            return dataItemList;
        }

        /// <summary>
        /// Parse Object to Xml
        /// </summary>
        public static void ParseObjectToXml<T>(T inputObject, XmlWriter xmlWriter)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            xmlSerializer.Serialize(xmlWriter, inputObject);
        }




    }
}
