using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper.Protect.Firewall
{
    [Serializable, XmlRoot("FirewallRuleGroup")]
    public class FirewallRuleGroup
    {
        private string _Name;
        private string _Description;
        private string[] _SecurityPolicyList;



        /// <summary>
        /// Specify a name to identify the Firewall Group.
        /// </summary>
        [XmlElement]
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value.Contains(","))
                    throw new Exception("Comma not allowed!");
                else if (value.Length > 150)
                    throw new Exception("Maximum characters allowed are 150!");

                _Name = value;
            }
        }

        /// <summary>
        /// Specify a descripion for the Firewall Group.
        /// </summary>
        [XmlElement]
        public string Description
        {
            get { return _Description; }
            set
            {
                if (value.Length > 255)
                    throw new Exception("Maximum characters allowed are 255!");

                _Description = value;
            }
        }

        /// <summary>
        /// Specify a Firewall Rule to Add/Remove into the Firewall Group.
        /// </summary>
        [XmlArray(ElementName = "SecurityPolicyList")]
        [XmlArrayItem(ElementName = "SecurityPolicy")]
        public string[] SecurityPolicyList
        {
            get { return _SecurityPolicyList; }
            set
            {
                if (null != value)
                {
                    if (value.Length > 200)
                        throw new Exception("Only values up to 200 are allowed.");

                    foreach(string item in value)
                    {
                        if (item.Contains(","))
                            throw new Exception("Comma not allowed!");
                        else if (value.Length > 60)
                            throw new Exception("Maximum characters allowed are 60!");
                    }

                    _SecurityPolicyList = value;
                }
            }
        }


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
        /// Select the type of policy.
        /// </summary>
        [XmlElement]
        public GroupPolicyType PolicyType { get; set; }
    }
}
