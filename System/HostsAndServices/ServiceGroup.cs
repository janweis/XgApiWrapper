using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper.System.HostsAndServices
{
    [Serializable, XmlRoot("ServiceGroup")]
    public class ServiceGroup : IHostsAndServices
    {
        /// <summary>
        /// Specify a name to identify the Service Group.
        /// </summary>
        private string _Name;
        [XmlElement]
        public string Name
        {
            get { return _Name; }
            set
            {
                if (value.Contains(","))
                    throw new Exception("Comma not allowed!");
                else if (value.Length > 60)
                    throw new Exception("Maximum characters allowed are 60!");

                _Name = value;
            }
        }

        /// <summary>
        /// Specify Description of the Service Group.
        /// </summary>
        [XmlElement]
        public string Description { get; set; }

        /// <summary>
        /// Select Services from the list to be added in the Service Group.
        /// </summary>
        private string[] _ServiceList;
        [XmlArray(ElementName = "ServiceList")]
        [XmlArrayItem(ElementName = "Service")]
        public string[] ServiceList
        {
            get { return _ServiceList; }
            set
            {
                if (value.Length > 60)
                    throw new Exception("Maximum characters allowed are 60!");

                _ServiceList = value;
            }
        }

        /// <summary>
        /// Need for XmlSerilization
        /// </summary>
        public ServiceGroup() { }

        /// <summary>
        /// Mandatory defined
        /// </summary>
        public ServiceGroup(string name, string[] services)
        {
            Name = name;
            ServiceList = services;
        }
        
        /// <summary>
        /// Optional
        /// </summary>
        public ServiceGroup(string name, string[] services, string description)
        {
            Name = name;
            ServiceList = services;
            Description = description;
        }
    }
}
