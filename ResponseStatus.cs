using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper
{
    [Serializable, XmlRoot("Status")]
    public class ResponseStatus
    {
        [XmlAttribute(AttributeName = "code")]
        public int ReturnCode { get; set; }

        [XmlText]
        public string ReturnText { get; set; }
    }
}
