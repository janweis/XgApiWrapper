using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace XgApiWrapper.System.HostsAndServices
{
    [Serializable, XmlRoot("IPHost")]
    public class IPHost : IWebReturnStatus, IRequestObject
    {
        /// <summary>
        /// Webserver Response
        /// </summary>
        [XmlElement]
        public ResponseStatus Status { get; set; }


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
        /// Select IP Family to which Host belongs: IPv4 or IPv6.
        /// </summary>
        [XmlElement]
        public IPFamily IPFamily { get; set; } = IPFamily.IPv4;

        /// <summary>
        /// Select the type of Host: IP, Network, IP Range or IP List.
        /// </summary>
        [XmlElement]
        public HostType HostType { get; set; }

        /// <summary>
        /// Specify IP Address based on the host type selected.
        /// </summary>
        private string _ipAddress;
        [XmlElement]
        public string IPAddress
        {
            get { return _ipAddress; }
            set
            {
                if (value.Length > 15)
                    throw new Exception("Maximum characters allowed are 15!");

                _ipAddress = value;
            }
        }

        /// <summary>
        /// Specify Subnet address if the host type selected is 'Network'.
        /// </summary>
        private string _Subnet;
        [XmlElement]
        public string Subnet
        {
            get { return _Subnet; }
            set
            {
                if (value.Length > 15)
                    throw new Exception("Maximum characters allowed are 15!");

                _Subnet = value;
            }
        }

        /// <summary>
        /// Specify the starting IP address of the IP Range if host type selected is 'IP Range'.
        /// </summary>
        /// 
        private string _StartIPAddress;
        [XmlElement]
        public string StartIPAddress
        {
            get { return _StartIPAddress; }
            set
            {
                if (value.Length > 15)
                    throw new Exception("Maximum characters allowed are 15!");

                _StartIPAddress = value;
            }
        }

        /// <summary>
        /// Specify the end IP address of the IP Range if host type selected is 'IP Range'.
        /// </summary>
        private string _EndIPAddress;
        [XmlElement]
        public string EndIPAddress
        {
            get { return _EndIPAddress; }
            set
            {
                if (value.Length > 15)
                    throw new Exception("Maximum characters allowed are 15!");

                _EndIPAddress = value;
            }
        }


        /// <summary>
        /// Specify the list of IP addresses.
        /// </summary>
        private string _ListOfIPAddresses;
        [XmlElement]
        public string ListOfIPAddresses
        {
            get { return _ListOfIPAddresses; }
            set
            {
                var tempList = value.Split(';');
                foreach (string ipAddress in tempList)
                {
                    //if (IPAddress.TryParse(ipAddress, out IPAddress validIPAddress))
                    //{
                    //    // Valid IP, Check for Loopback
                    //    if (IPAddress.IsLoopback(validIPAddress))
                    //        throw new Exception("IP Class other than 'LOCALHOST', 'UNSPECIFIED' is allowed.");
                    //}
                    //else
                    //{
                    //    // Not Valid!
                    //    throw new Exception("Not a valid IPAddress!");
                    //}
                }

                _ListOfIPAddresses = value;
            }
        }


        /// <summary>
        /// Select the Host Group to which the Host belongs.
        /// </summary>
        private List<string> _HostGroupList;
        [XmlArray(ElementName = "HostGroupList")]
        [XmlArrayItem(ElementName = "HostGroup")]
        public List<string> HostGroupList
        {
            get { return _HostGroupList; }
            set
            {
                if (null != value)
                {
                    foreach (string hostGroup in value)
                    {
                        if (hostGroup.ToString().Contains(","))
                            throw new Exception("Comma not allowed!");
                        else if (hostGroup.ToString().Length > 60)
                            throw new Exception("Maximum characters allowed are 60!");
                    }
                }

                _HostGroupList = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IPHost() { }

        /// <summary>
        /// For IP Type
        /// </summary>
        public IPHost(string name, HostType hostType, string ipAddress)
        {
            Name = name;
            HostType = hostType;
            IPAddress = ipAddress;
        }

        /// <summary>
        /// For Network Type
        /// </summary>
        public IPHost(string name, HostType hostType, string ipAddress, string subnet)
        {
            Name = name;
            HostType = hostType;
            IPAddress = ipAddress;
            Subnet = subnet;
        }
    }
}
