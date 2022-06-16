using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper
{
    public interface IWebReturnStatus
    {
        /// <summary>
        /// Webserver Response
        /// </summary>
        [XmlElement]
        ResponseStatus Status { get; set; }
    }
}
