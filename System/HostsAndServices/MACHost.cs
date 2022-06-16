using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper.System.HostsAndServices
{
    [Serializable, XmlRoot("MACHost")]
    public class MACHost : IHostsAndServices
    {
        /// <summary>
        /// Specify a name to identify the MAC Host.
        /// </summary>
        private string _name;

        [XmlElement]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Contains(","))
                    throw new Exception("Comma not allowed!");
                else if (value.Length > 60)
                    throw new Exception("Maximum characters allowed are 60!");

                _name = value;
            }
        }

        /// <summary>
        /// Select the MAC Host Type: MAC Address or MAC List.
        /// </summary>
        [XmlElement]
        public MacType Type { get; set; }

        /// <summary>
        /// Specify MAC Address based on the Host type selected.
        /// </summary>
        [XmlElement(ElementName = "MACAddress")]
        private string _macAddress;

        public string MACAddress
        {
            get { return _macAddress; }
            set
            {
                if (value.Length > 17)
                    throw new Exception("Maximum characters allowed are 17!");

                _macAddress = value;
            }
        }

        /// <summary>
        /// Specify multiple MAC Addresses if selected Host type is 'MAC List'.
        /// </summary>
        [XmlArray(ElementName = "MACList")]
        [XmlArrayItem(ElementName = "MACAddress")]
        public List<string> MacList { get; set; }
    }
}
