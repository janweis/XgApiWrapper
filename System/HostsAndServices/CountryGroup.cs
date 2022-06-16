using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper.System.HostsAndServices
{
    [Serializable, XmlRoot("CountryGroup")]
    public class CountryGroup : IHostsAndServices
    {
        /// <summary>
        /// Specify a name to identify the Country group.
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

                _name = value;
            }
        }

        /// <summary>
        /// Specify the Country Host Group description.
        /// </summary>
        [XmlElement]
        public string Description { get; set; }

        /// <summary>
        /// Specify 'select'
        /// </summary>
        private List<string> _countryList;

        [XmlArray(ElementName = "CountryList")]
        [XmlArrayItem(ElementName = "Country")]
        public List<string> CountryList
        {
            get { return _countryList; }
            set
            {
                foreach (string item in value)
                {
                    if (item.Contains(","))
                        throw new Exception("Comma not allowed!");
                    else if (item.Length > 60)
                        throw new Exception("Maximum characters allowed are 60!");
                }

                _countryList = value;
            }
        }
    }
}
