using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace XgApiWrapper
{
    public enum RequestType { Get, Set, Remove };

    public class Request
    {
        public Connection ConnectionData { get; set; }
        public RequestType RequestType { get; set; }
        public Type InputType { get; set; }
        public object InputObject { get; set; }

        public Request(Connection connection, RequestType requestType, Type inputType)
        {
            ConnectionData = connection;
            RequestType = requestType;
            InputType = inputType;
        }


        /// <summary>
        /// Create XML List Request
        /// </summary>
        public string CreateXmlForList()
        {
            // Start
            XmlWriter xmlWriter = OpenXml(out StringBuilder stringXmlOutput);

            // Object
            xmlWriter.WriteStartElement(InputType.Name);
            xmlWriter.WriteEndElement();

            // Finish
            CloseXml(xmlWriter);

            // Cleanup
            string outputObject = CleanupXmlString(stringXmlOutput.ToString());

            return outputObject;
        }


        /// <summary>
        /// Create XML Request with Filter
        /// </summary>
        public string CreateXmlIncludeFilter(string filter)
        {
            // Start
            XmlWriter xmlWriter = OpenXml(out StringBuilder stringXmlOutput);

            // Filter
            xmlWriter.WriteStartElement(InputType.Name);
            xmlWriter.WriteStartElement("Filter");

            xmlWriter.WriteStartElement("key");
            xmlWriter.WriteAttributeString("name", "Name");
            xmlWriter.WriteAttributeString("criteria", "like");
            xmlWriter.WriteValue(filter);
            xmlWriter.WriteEndElement(); // End Key

            xmlWriter.WriteEndElement(); // End Filter
            xmlWriter.WriteEndElement(); // End ObjectName

            // Finish
            CloseXml(xmlWriter);

            // Cleanup
            string outputObject = CleanupXmlString(stringXmlOutput.ToString());

            return outputObject;
        }


        /// <summary>
        /// 
        /// </summary>
        public string CreateXmlIncludeObjectName<T>(string name)
        {
            // Start
            XmlWriter xmlWriter = OpenXml(out StringBuilder stringXmlOutput);

            // Add Object
            xmlWriter.WriteStartElement(typeof(T).Name);
            xmlWriter.WriteElementString("Name", name);
            xmlWriter.WriteEndElement(); // End ObjectType

            // Finish
            CloseXml(xmlWriter);

            // Cleanup
            string outputObject = CleanupXmlString(stringXmlOutput.ToString());

            return outputObject;
        }


        /// <summary>
        /// 
        /// </summary>
        public string CreateXmlIncludeObjectName<T>(string[] names)
        {
            // Start
            XmlWriter xmlWriter = OpenXml(out StringBuilder stringXmlOutput);

            // Add Object
            foreach (string name in names)
            {
                xmlWriter.WriteStartElement(typeof(T).Name);
                xmlWriter.WriteElementString("Name", name);
                xmlWriter.WriteEndElement(); // End ObjectType
            }

            // Finish
            CloseXml(xmlWriter);

            // Cleanup
            string outputObject = CleanupXmlString(stringXmlOutput.ToString());

            return outputObject;
        }


        /// <summary>
        /// 
        /// </summary>
        public string CreateXmlIncludeObject<T>(T inputObject)
        {
            // Start
            XmlWriter xmlWriter = OpenXml(out StringBuilder stringXmlOutput);

            // Add Object
            XmlParser.ParseObjectToXml<T>(inputObject, xmlWriter);

            // Finish
            CloseXml(xmlWriter);

            // Cleanup
            string outputObject = CleanupXmlString(stringXmlOutput.ToString());

            return outputObject;
        }


        /// <summary>
        /// 
        /// </summary>
        public string CreateXmlIncludeObject<T>(T[] inputObjects)
        {
            // Start
            XmlWriter xmlWriter = OpenXml(out StringBuilder stringXmlOutput);

            // Add Object
            foreach (T item in inputObjects)
                XmlParser.ParseObjectToXml<T>(item, xmlWriter);

            // Finish
            CloseXml(xmlWriter);

            // Cleanup
            string outputObject = CleanupXmlString(stringXmlOutput.ToString());

            return outputObject;
        }



        //
        // Helper
        //

        /// <summary>
        /// 
        /// </summary>
        private XmlWriter OpenXml(out StringBuilder stringXmlOutput)
        {
            StringBuilder xmlOut = new StringBuilder();
            stringXmlOutput = xmlOut;

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings() { Encoding = Encoding.UTF8 };
            XmlWriter xmlWriter = XmlWriter.Create(stringXmlOutput, xmlWriterSettings);

            // START
            xmlWriter.WriteStartElement("Request");

            // LOGIN
            xmlWriter.WriteStartElement("Login");
            xmlWriter.WriteElementString("Username", ConnectionData.Username);
            xmlWriter.WriteElementString("Password", ConnectionData.Password);
            xmlWriter.WriteEndElement(); // End Login

            // RequestType
            xmlWriter.WriteStartElement(RequestType.ToString());

            return xmlWriter;
        }


        /// <summary>
        /// 
        /// </summary>
        private void CloseXml(XmlWriter xmlWriter)
        {
            xmlWriter.WriteEndElement(); // End RequestType
            xmlWriter.Close();
            xmlWriter.Flush();
        }


        /// <summary>
        /// 
        /// </summary>
        private string CleanupXmlString(string xmlString)
        {
            string tempString = xmlString.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
            string outputString = tempString.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", "");

            return outputString;
        }
    }
}
