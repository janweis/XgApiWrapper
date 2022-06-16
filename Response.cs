using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XgApiWrapper
{
    [Serializable, XmlRoot(ElementName = "Response")]
    public class Response
    {
        [XmlAttribute(AttributeName = "APIVersion")]
        public string ApiVersion { get; set; }

        [XmlAttribute(AttributeName = "IPS_CAT_VER")]
        public int IpsCatVersion { get; set; }

        [XmlArray(ElementName = "Login")]
        [XmlArrayItem(ElementName = "status")]
        public string[] Login { get; set; }

        private readonly List<XElement> elements = new List<XElement>();
        [XmlAnyElement]
        public List<XElement> Elements { get { return elements; } }

    }
}
