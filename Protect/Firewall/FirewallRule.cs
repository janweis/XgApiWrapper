using System;
using System.Linq;
using System.Net;
using System.Xml.Serialization;

namespace XgApiWrapper.Protect.Firewall
{
    /// <summary>
    /// SOPHOS API HELP - Dokumentation
    /// https://docs.sophos.com/nsg/sophos-firewall/18.0/API/index.html
    /// </summary>
    [Serializable, XmlRoot("FirewallRule")]
    public class FirewallRule 
    {
        /// <summary>
        /// Specify a name to identify the Firewall Group.
        /// </summary>
        private string _Name;
        [XmlElement]
        public string Name
        {
            get { return _Name; }
            set
            {
                if ((bool)(value?.Contains(",")))
                    throw new Exception("Comma not allowed!");
                else if (value?.Length > 150)
                    throw new Exception("Maximum characters allowed are 150!");

                _Name = value;
            }
        }

        /// <summary>
        /// Specify a descripion for the Firewall Group.
        /// </summary>
        private string _Description;
        [XmlElement]
        public string Description
        {
            get { return _Description; }
            set
            {
                if (value?.Length > 255)
                    throw new Exception("Maximum characters allowed are 255!");

                _Description = value;
            }
        }

        /// <summary>
        /// Firewallrule Status
        /// </summary>
        [XmlElement]
        public State Status { get; set; } = State.Enable;

        /// <summary>
        /// Select the Internet Protocol version.
        /// </summary>
        [XmlElement]
        public IPFamily IPFamily { get; set; } = IPFamily.IPv4;

        /// <summary>
        /// Firewall Rule Position
        /// </summary>
        [XmlElement]
        public RulePosition Position { get; set; }

        /// <summary>
        /// After and Before Tag Apply only for Set Request
        /// </summary>
        [XmlArray(ElementName = "After")]
        [XmlArrayItem(ElementName = "Name")]
        public string[] AfterRule { get; set; }

        /// <summary>
        /// After and Before Tag Apply only for Set Request
        /// </summary>
        [XmlArray(ElementName = "Befor")]
        [XmlArrayItem(ElementName = "Name")]
        public string[] BeforRule { get; set; }

        /// <summary>
        /// Select the type of policy.
        /// </summary>
        [XmlElement]
        public RulePolicyType PolicyType { get; set; }

        /// <summary>
        /// UserPolicy
        /// </summary>
        [XmlElement]
        public UserPolicy UserPolicy { get; set; }

        /// <summary>
        /// NetworkPolicy
        /// </summary>
        [XmlElement]
        public NetworkPolicy NetworkPolicy { get; set; }

        /// <summary>
        /// HttpBasedPolicy
        /// </summary>
        [XmlElement]
        public HttpBasedPolicy HttpBasedPolicy { get; set; }


        /// <summary>
        /// Constructor
        /// </summary>

        public FirewallRule() { }

        public FirewallRule(string name, UserPolicy userPolicy, NetworkPolicy networkPolicy, HttpBasedPolicy httpBasedPolicy)
            : this(name, "", State.Enable, userPolicy, networkPolicy, httpBasedPolicy) { }

        public FirewallRule(string name, string description, State state, UserPolicy userPolicy, NetworkPolicy networkPolicy, HttpBasedPolicy httpBasedPolicy)
        : this(name, description, state, IPFamily.IPv4, userPolicy, networkPolicy, httpBasedPolicy) { }

        public FirewallRule(string name, string description, State state, IPFamily protocolVersion, UserPolicy userPolicy, NetworkPolicy networkPolicy, HttpBasedPolicy httpBasedPolicy)
        {
            Name = name;
            Description = description;
            Status = state;
            IPFamily = protocolVersion;
            UserPolicy = userPolicy;
            NetworkPolicy = networkPolicy;
            HttpBasedPolicy = httpBasedPolicy;
        }
    }
}
