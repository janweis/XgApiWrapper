
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XgApiWrapper.System.HostsAndServices
{
    [Serializable, XmlRoot("FQDNHostGroup")]
    public class FQDNHostGroup : IHostsAndServices
    {
        /// <summary>
        /// Specify 'select'
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
        /// Specify FQDN Host Group description.
        /// </summary>
        [XmlElement]
        public string Description { get; set; }

        /// <summary>
        /// Specify a name to identify the FQDN Host group.
        /// </summary>
        private List<string> _fqdnHostList;

        [XmlArray(ElementName = "FQDNHostList")]
        [XmlArrayItem(ElementName = "FQDNHost")]
        public List<string> FQDNHostList
        {
            get { return _fqdnHostList; }
            set
            {
                foreach(string item in value)
                {
                    if (value.Contains(","))
                        throw new Exception("Comma not allowed!");
                }

                _fqdnHostList = value;
            }
        }
    }
}
