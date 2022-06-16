using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XgApiWrapper.System.HostsAndServices
{
    [Serializable, XmlRoot("FQDNHost")]
    public class FQDNHost : IHostsAndServices
    {
        /// <summary>
        /// Specify a name to identify the IP Host.
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
        /// Specify FQDN Address
        /// </summary>
        private string _fqdn;

        [XmlElement(ElementName = "FQDN")]
        public string Fqdn
        {
            get { return _fqdn; }
            set
            {
                if (value.Contains(","))
                    throw new Exception("Comma not allowed!");
                else if (value.Length > 253)
                    throw new Exception("Maximum characters allowed are 253!");

                _fqdn = value;
            }
        }

        /// <summary>
        /// Select Host Group from the available options.
        /// </summary>
        private List<string> _fqdnHostGroupList;

        [XmlArray(ElementName = "FQDNHostGroupList")]
        [XmlArrayItem(ElementName = "FQDNHostGroup")]
        public List<string> FqdnHostGroupList
        {
            get { return _fqdnHostGroupList; }
            set
            {
                foreach (string item in value)
                {
                    if (item.Contains(","))
                        throw new Exception("Comma not allowed!");
                    else if (item.Length > 60)
                        throw new Exception("Maximum characters allowed are 60!");
                }

                _fqdnHostGroupList = value;
            }
        }

        public FQDNHost() { }

        public FQDNHost(string hostname, string fqdn)
        {
            Name = hostname;
            Fqdn = fqdn;
        }
    }
}