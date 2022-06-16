using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper.System.HostsAndServices
{
    [Serializable, XmlRoot("ServiceDetail")]
    public class ServiceDetail : IHostsAndServices
    {
        /// <summary>
        /// Select Protocol and Protocol number for the service.
        /// </summary>
        [XmlElement]
        public IPProtocol Protocol { get; set; }

        /// <summary>
        /// Specify source port number if protocol selected is TCP/UDP.
        /// </summary>
        private string[] _sourcePort;
        [XmlElement]
        public string[] SourcePort
        {
            get { return _sourcePort; }
            set
            {
                if (null != value)
                {
                    foreach (string item in value)
                        if (item.Length > 11)
                            throw new Exception("Maximum characters allowed are 11!");

                    _sourcePort = value;
                }
            }
        }

        /// <summary>
        /// Specify destination port number if protocol selected is TCP/UDP.
        /// </summary>
        private string[] _destinationPort;
        [XmlElement]
        public string[] DestinationPort
        {
            get { return _destinationPort; }
            set
            {
                if (null != value)
                {
                    foreach (string item in value)
                        if (item.Length > 11)
                            throw new Exception("Maximum characters allowed are 11!");

                    _destinationPort = value;
                }
            }
        }

        /// <summary>
        /// Protocol Name
        /// </summary>
        private string _protocolName;
        [XmlElement]
        public string ProtocolName
        {
            get { return _protocolName; }
            set { _protocolName = value; }
        }

        /// <summary>
        /// Select ICMP type.
        /// </summary>
        [XmlElement]
        public ICMPType ICMPType { get; set; }

        /// <summary>
        /// Select ICMP Code.
        /// </summary>
        private string[] _ICMPCode;
        [XmlElement]
        public string[] ICMPCode
        {
            get { return _ICMPCode; }
            set { _ICMPCode = value; }
        }

        /// <summary>
        /// Select ICMP type Only '0', '-1', '1', '2', '3', '4', '100', '101', '128', '129', '130', '131', '132', '133', '134', '135', '136', '137', '138', '139', '140', '141', '142', '143', '144', '145', '146', '147', '148', '149', '150', '151', '152', '153', '154', '155', '156', '157', '158', '200', '201'
        /// </summary>
        [XmlElement]
        public ICMPv6Type ICMPv6Type { get; set; }

        /// <summary>
        /// Select ICMP Code Only '-1', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15' 
        /// </summary>
        private string[] _ICMPv6Code;
        [XmlElement]
        public string[] ICMPv6Code
        {
            get { return _ICMPv6Code; }
            set { _ICMPv6Code = value; }
        }

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        /// <summary>
        /// For XML Serilization
        /// </summary>
        public ServiceDetail() { }

        /// <summary>
        /// For TCPUDP type
        /// </summary>
        public ServiceDetail(IPProtocol iPProtocol, string[] sourcePort, string[] destinationPort)
        {
            Protocol = iPProtocol;
            SourcePort = sourcePort;
            DestinationPort = destinationPort;
        }

        /// <summary>
        /// For IP type
        /// </summary>
        public ServiceDetail(string protocolName)
        {
            ProtocolName = protocolName;
        }

        /// <summary>
        /// For ICMP Type v4
        /// </summary>
        public ServiceDetail(ICMPType icmpType, string[] icmpCode)
        {
            ICMPType = icmpType;
            ICMPCode = icmpCode;
        }

        /// <summary>
        /// For ICMP Type v6
        /// </summary>
        public ServiceDetail(ICMPv6Type icmpV6Type, string[] icmpV6Code)
        {
            ICMPv6Type = icmpV6Type;
            ICMPv6Code = icmpV6Code;
        }
    }
}
