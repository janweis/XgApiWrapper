using System;
using System.Linq;
using System.Net;
using System.Xml.Serialization;

namespace XgApiWrapper.Protect.Firewall
{
    [Serializable, XmlRoot("HttpBasedPolicy")]
    public class HttpBasedPolicy
    {
        /// <summary>
        /// Select the interface of the hosted server to which the rule applies. 
        /// It is the public IP address through which Internet users access the internal server/host.
        /// </summary>
        [XmlElement]
        public string HostedAddress { get; set; }

        /// <summary>
        /// Click to enable or disable scanning of HTTPS traffic.
        /// </summary>
        [XmlElement]
        public State HTTPS { get; set; } = State.Disable;

        /// <summary>
        /// Click to redirect HTTP requests.
        /// </summary>
        [XmlElement]
        public State RedirectHttp { get; set; } = State.Disable;

        /// <summary>
        /// Enter a port number on which the hosted web server can be reached externally, over the Internet.
        /// </summary>
        [XmlElement]
        public ushort ListenPort { get; set; }

        /// <summary>
        /// Enter the domains the web server is responsible for as FQDN.
        /// According to the selected HTTPS certificate, some domains may be preselected. You can edit or delete these domains or add new ones..
        /// </summary>
        [XmlArray(ElementName = "Domains")]
        [XmlArrayItem(ElementName = "Domain")]
        public string[] Domains { get; set; }

        /// <summary>
        /// Select the source networks to which the rule apply.
        /// </summary>
        private string[] _SourceNetworks = new[] { "ANY" };
        [XmlArray(ElementName = "SourceNetworks")]
        [XmlArrayItem(ElementName = "Network")]
        public string[] SourceNetworks
        {
            get { return _SourceNetworks; }
            set
            {
                if (null != value)
                {
                    if (value.Length > 60)
                        throw new Exception("Maximum characters allowed are 60!");

                    _SourceNetworks = value;
                }
            }
        }

        /// <summary>
        /// Select the source networks to which the rule won´t apply.
        /// </summary>
        private string[] _ExceptionNetworks;
        [XmlArray(ElementName = "ExceptionNetworks")]
        [XmlArrayItem(ElementName = "Network")]
        public string[] ExceptionNetworks
        {
            get { return _SourceNetworks; }
            set
            {
                if (null != value)
                {
                    if (value.Length > 60)
                        throw new Exception("Maximum characters allowed are 60!");

                    _ExceptionNetworks = value;
                }
            }
        }

        /// <summary>
        /// No documentation
        /// </summary>
        [XmlArray(ElementName = "AccessPaths")]
        [XmlArrayItem(ElementName = "AccessPath")]
        public AccessPath[] AccessPaths { get; set; }

        /// <summary>
        /// No documentation
        /// </summary>
        [XmlArray(ElementName = "Exceptions")]
        [XmlArrayItem(ElementName ="Exception")]
        public RuleException[] Exceptions { get; set; }

        /// <summary>
        /// No documentation
        /// </summary>
        [XmlElement]
        public string ProtocolSecurity { get; set; }

        /// <summary>
        /// Select this to not send content in compressed form to client on request.
        /// </summary>
        [XmlElement]
        public State CompressionSupport { get; set; } = State.Disable;

        /// <summary>
        /// Select this option to have the device rewrite links of the returned webpages in order for the links to stay valid.
        /// </summary>
        [XmlElement]
        public State RewriteHTML { get; set; } = State.Disable;

        /// <summary>
        /// Select this option to have the device rewrite cookies of the returned webpages.
        /// </summary>
        [XmlElement]
        public State RewriteCookies { get; set; } = State.Enable;

        /// <summary>
        /// When you select this option, the host header as requested by the client will be 
        /// preserved and forwarded along with the web request to the web server. Whether 
        /// passing the host header is necessary in your environment depends on the configuration 
        /// of your web server.
        /// </summary>
        [XmlElement]
        public State PassHostHeader { get; set; } = State.Disable;

        /// <summary>
        /// Select IPS policy for the rule.
        /// </summary>
        [XmlElement]
        public string IntrusionPrevention { get; set; }

        /// <summary>
        /// Select Traffic Shaping policy for the rule.
        /// </summary>
        [XmlElement]
        public string TrafficShapingPolicy { get; set; }
    }
}
