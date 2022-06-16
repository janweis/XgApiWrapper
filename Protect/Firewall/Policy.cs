using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper.Protect.Firewall
{
    public abstract class Policy
    {
        /// <summary>
        /// Specify action for the rule traffic.
        /// </summary>
        [XmlElement]
        public RuleAction Action { get; set; } = RuleAction.Drop;

        /// <summary>
        /// Enable traffic logging for the policy.
        /// </summary>
        [XmlElement]
        public State LogTraffic { get; set; } = State.Disable;

        /// <summary>
        /// Select if you don't want to apply the firewall rule when appliance IP address is the destination.
        /// </summary>
        [XmlElement]
        public State SkipLocalDestined { get; set; }

        /// <summary>
        /// Select the source zones to which the rule apply.
        /// </summary>
        [XmlArray(ElementName = "SourceZones")]
        [XmlArrayItem(ElementName = "Zone")]
        public string[] SourceZones { get; set; }

        /// <summary>
        /// Select the destination zones to which the rule apply.
        /// </summary>
        [XmlArray(ElementName = "DestinationZones")]
        [XmlArrayItem(ElementName = "Zone")]
        public string[] DestinationZones { get; set; }

        private string[] _SourceNetworks = new[] { "ANY" };
        /// <summary>
        /// Select the source networks to which the rule apply.
        /// </summary>
        [XmlArray(ElementName = "SourceNetworks")]
        [XmlArrayItem(ElementName = "Network")]
        public string[] SourceNetworks
        {
            get { return _SourceNetworks; }
            set
            {
                if (value?.Length > 60)
                    throw new Exception("Maximum characters allowed are 60!");

                _SourceNetworks = value;
            }
        }

        private string[] _DestinationNetworks = new[] { "ANY" };
        /// <summary>
        /// Select the destination networks to which the rule apply.
        /// </summary>
        [XmlArray(ElementName = "DestinationNetworks")]
        [XmlArrayItem(ElementName = "Network")]
        public string[] DestinationNetworks
        {
            get { return _DestinationNetworks; }
            set
            {
                if (value?.Length > 60)
                    throw new Exception("Maximum characters allowed are 60!");

                _DestinationNetworks = value;
            }
        }

        private string[] _Services = new[] { "ANY" };
        /// <summary>
        /// Select the services or service groups to which the rule won't apply.
        /// </summary>
        [XmlArray(ElementName = "Services")]
        [XmlArrayItem(ElementName = "Service")]
        public string[] Services
        {
            get { return _Services; }
            set
            {
                if (value?.Length > 60)
                    throw new Exception("Maximum characters allowed are 60!");

                _Services = value;
            }
        }

        /// <summary>
        /// Select Schedule for the Rule.
        /// </summary>
        [XmlElement]
        public string Schedule { get; set; }

        /// <summary>
        /// Select the zones to which the rule won't apply.
        /// </summary>
        [XmlElement]
        public RuleExclusion Exclusions { get; set; }


        //
        // WEBFILTERING
        //
        #region WEBFILTERING

        /// <summary>
        /// Select Web Filter Policy for the rule.
        /// </summary>
        [XmlElement]
        public string WebFilter { get; set; }

        /// <summary>
        /// Select to limit bandwidth for the URLs categorized under the Web category.
        /// </summary>
        [XmlElement]
        public string WebCategoryBaseQoSPolicy { get; set; }

        /// <summary>
        /// Ensure Google websites user HTTP/s instead of QUICK QUIC
        /// </summary>
        [XmlElement]
        public State BlockQuickQuic { get; set; } = State.Disable;

        /// <summary>
        /// Select to enable virus and spam scanning for HTTP protocol and decrypted HTTPS protocol.
        /// </summary>
        [XmlElement]
        public State ScanVirus { get; set; } = State.Disable;

        /// <summary>
        /// Select to enable sandstorm analysis.
        /// </summary>
        [XmlElement]
        public State Sandstorm { get; set; } = State.Disable;

        /// <summary>
        /// Enable/Disable scanning of FTP traffic.
        /// </summary>
        [XmlElement]
        public State ScanFTP { get; set; } = State.Disable;

        /// <summary>
        /// Select to enable transparent web proxy
        /// </summary>
        [XmlElement]
        public State ProxyMode { get; set; } = State.Disable;

        /// <summary>
        /// Select to decrypt traffic with HTTPS protocol.
        /// </summary>
        [XmlElement]
        public State DecryptHttps { get; set; } = State.Disable;
        #endregion


        //
        // SYNCHRONZED SECURITY
        //
        #region SYNCHRONZED SECURITY

        /// <summary>
        /// Select a minimum health status that a device must have to conform to this policy.
        /// </summary>
        [XmlElement]
        public State SourceSecurityHeartbeat { get; set; } = State.Disable;

        /// <summary>
        /// Select a minimum health status that a device must have to conform to this policy.
        /// </summary>
        [XmlElement]
        public HealthState MinimumSourceHBPermitted { get; set; } = HealthState.NoRestriction;

        /// <summary>
        /// Enable/Disable to require the sending of heartbeats.
        /// </summary>
        [XmlElement]
        public State DestSecurityHeartbeat { get; set; } = State.Disable;

        /// <summary>
        /// Select a minimum health status that a device must have to conform to this policy.
        /// </summary>
        [XmlElement]
        public HealthState MinimumDestinationHBPermitted { get; set; } = HealthState.NoRestriction;
        #endregion


        //
        // SECURITY FEATURES
        //
        #region SECURITY FEATURES
        /// <summary>
        /// Select Application Filter Policy for the rule.
        /// </summary>
        [XmlElement]
        public string ApplicationControl { get; set; }

        /// <summary>
        /// Select to limit the bandwidth for the applications categorized under the Application Category.
        /// </summary>
        [XmlElement]
        public string ApplicationBaseQoSPolicy { get; set; }

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

        /// <summary>
        /// Select DSCP Marking to classify flow of packets based on Traffic Shaping policy.
        /// </summary>
        [XmlElement]
        public string DscpMarking { get; set; }
        #endregion


        //
        // EMAIL SCANNING
        //
        #region EMAIL SCANNING

        /// <summary>
        /// Enable/Disable scanning of POP3 traffic.
        /// </summary>
        [XmlElement]
        public State ScanPOP3 { get; set; } = State.Disable;
        [XmlElement]
        public State ScanPOP3S { get; set; } = State.Disable;

        /// <summary>
        /// Enable/Disable scanning of IMAP/S traffic.
        /// </summary>
        [XmlElement]
        public State ScanIMAP { get; set; } = State.Disable;
        [XmlElement]
        public State ScanIMAPS { get; set; } = State.Disable;

        /// <summary>
        /// Enable/Disable scanning of SMTP/S traffic.
        /// </summary>
        [XmlElement]
        public State ScanSMTP { get; set; } = State.Disable;
        [XmlElement]
        public State ScanSMTPS { get; set; } = State.Disable;
        #endregion

    }
}
