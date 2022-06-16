using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper.System.HostsAndServices
{
    [Serializable, XmlRoot("Services")]
    public class Services : IHostsAndServices
    {
        /// <summary>
        /// Specify a name to identify the Service.
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
                else if (value.Length > 50)
                    throw new Exception("Maximum characters allowed are 50!");

                _name = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(ElementName = "Type")]
        public ServiceType Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [XmlArray(ElementName = "ServiceDetails")]
        [XmlArrayItem(ElementName = "ServiceDetail")]
        public ServiceDetail[] ServiceDetails { get; set; }

        /// <summary>
        /// For XML Serilization
        /// </summary>
        public Services() { }

        /// <summary>
        /// Mandatory
        /// </summary>
        public Services(string name, ServiceDetail[] serviceDetails)
        {
            Name = name;
            ServiceDetails = serviceDetails;
        }
    }
}
