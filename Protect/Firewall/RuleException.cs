using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper.Protect.Firewall
{
    [Serializable, XmlRoot("Exception")]
    public class RuleException
    {
        /// <summary>
        /// Enter the path for which you want to create the site path route. Example: /products/.
        /// </summary>
        [XmlArray(ElementName = "path")]
        public string[] Paths { get; set; }

        /// <summary>
        /// Select the operation among AND or OR for Path and Source.
        /// </summary>
        [XmlElement(ElementName = "op")]
        public Operation Operation { get; set; } = Operation.AND;

        /// <summary>
        /// Specify the source networks where the client request comes from and which are to be exempted from the selected check(s).
        /// </summary>
        [XmlArray(ElementName = "source")]
        public string[] Sources { get; set; }

        /// <summary>
        /// Select various parameters that you want to skip in section 'Skip these categories', options available are 
        /// 'Protocol Violations', 'Protocol Anomalies', 'Request Limits', 'HTTP Policy', 'Bad Robots', 
        /// 'Generic Attacks', 'SQL Injection Attacks', 'XSS Attacks', 'Tight Security', 'Trojans' and 'Outbound'.
        /// </summary>
        [XmlArray(ElementName = "skip_threats_filter_categories")]
        public ThreatsFilterCategorie[] SkipThreatsFilterCategories { get; set; }

        /// <summary>
        /// Click this to skip 'Anti-Virus'. Anti-Virus is used to protect a web server against viruses.
        /// </summary>
        [XmlElement(ElementName = "skipav")]
        public bool SkipAV { get; set; } = false;

        /// <summary>
        /// Select this to skip 'Block Clients with bad reputation'. Based on GeoIPClosed and RBLClosed 
        /// information you can block clients which have a bad reputation according to their classification.
        /// </summary>
        [XmlElement(ElementName = "skipbadclients")]
        public bool SkipBadClients { get; set; } = false;

        /// <summary>
        /// Select this to 'Skip Cookie Signing'. Cookie signing protects a web server against manipulated cookies.
        /// </summary>
        [XmlElement(ElementName = "skipcookie")]
        public bool SkipCookie { get; set; } = false;

        /// <summary>
        /// Click to skip 'Form Hardening'. Form hardening protects against web form rewriting.
        /// </summary>
        [XmlElement(ElementName = "skipform")]
        public bool SkipForm { get; set; } = false;

        /// <summary>
        /// Select this to skip 'Static URL Hardening'. Static URL Hardening protects against URL rewriting.
        /// </summary>
        [XmlElement(ElementName = "skipurl")]
        public bool SkipUrl { get; set; } = false;


    }
}
