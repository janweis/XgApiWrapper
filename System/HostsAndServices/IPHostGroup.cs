using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper.System.HostsAndServices
{
    [Serializable, XmlRoot("IPHostGroup")]
    public class IPHostGroup : IHostsAndServices
    {

        /// <summary>
        /// Specify a name to identify the IP Host group.
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

                _name = value;
            }
        }

        /// <summary>
        /// Describe the IP Host Group.
        /// </summary>
        [XmlElement]
        public string Description { get; set; }

        /// <summary>
        /// Select IP Family of the IP Host Group: IPv4 or IPv6.
        /// </summary>
        [XmlElement]
        public IPFamily IPFamily { get; set; } = IPFamily.IPv4;

        /// <summary>
        /// Select Host names to be added in the IP Host Group.
        /// </summary>
        private List<string> _hostList;

        [XmlArray(ElementName = "HostList")]
        [XmlArrayItem(ElementName = "Host")]
        public List<string> HostList
        {
            get { return _hostList; }
            set
            {
                foreach(string item in value)
                {
                    if (item.Contains(","))
                        throw new Exception("Comma not allowed!");
                    else if (item.Length > 60)
                        throw new Exception("Maximum characters allowed are 60!");
                }

                _hostList = value;
            }
        }
    }
}
