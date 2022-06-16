using System;
using System.Xml.Serialization;

namespace XgApiWrapper.Protect.Firewall
{
    [Serializable, XmlRoot("Exclusions")]
    public class RuleExclusion
    {
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

        /// <summary>
        /// Select the source networks to which the rule apply.
        /// </summary>
        private string[] _SourceNetworks;
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
        /// Select the destination networks to which the rule apply.
        /// </summary>
        private string[] _DestinationNetworks;
        [XmlArray(ElementName = "DestinationNetworks")]
        [XmlArrayItem(ElementName = "Network")]
        public string[] DestinationNetworks
        {
            get { return _DestinationNetworks; }
            set
            {
                if (null != value)
                {
                    if (value.Length > 60)
                        throw new Exception("Maximum characters allowed are 60!");

                    _DestinationNetworks = value;
                }
            }
        }

        /// <summary>
        /// Select the services or service groups to which the rule won't apply.
        /// </summary>
        private string[] _Services;
        [XmlArray(ElementName = "Services")]
        [XmlArrayItem(ElementName = "Service")]
        public string[] Services
        {
            get { return _Services; }
            set
            {
                if (null != value)
                {
                    if (value.Length > 60)
                        throw new Exception("Maximum characters allowed are 60!");

                    _Services = value;
                }
            }
        }
    }
}
