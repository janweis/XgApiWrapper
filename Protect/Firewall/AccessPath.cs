using System;
using System.Xml.Serialization;

namespace XgApiWrapper.Protect.Firewall
{
    [Serializable, XmlRoot("AccessPath")]
    public class AccessPath
    {
        /// <summary>
        /// Enter the path for which you want to create the site path route. Example: /products/.
        /// </summary>
        private string _Path;
        [XmlElement(ElementName = "path")]
        public string Path
        {
            get { return _Path; }
            set
            {
                if (value.Contains(","))
                    throw new Exception("Comma not allowed!");
                else if (value.Length > 63)
                    throw new Exception("Maximum characters allowed are 63!");

                _Path = value;
            }
        }

        /// <summary>
        /// Select the web servers which are to be used for the specified path.
        /// </summary>
        [XmlElement(ElementName = "backend")]
        public string[] Backend { get; set; }

        /// <summary>
        /// Select the Authentication Policy. Select Create new to create a new Authentication Policy.
        /// </summary>
        [XmlElement(ElementName = "auth_profile")]
        public string AuthProfile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private string[] _AllowedNetworks;
        [XmlArray(ElementName = "Allowed_Networks")]
        [XmlArrayItem(ElementName = "Network")]
        public string[] AllowedNetworks
        {
            get { return _AllowedNetworks; }
            set
            {
                if (null != value)
                {
                    if (value.Length > 60)
                        throw new Exception("Maximum characters allowed are 60!");

                    _AllowedNetworks = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string[] _DeniedNetworks;
        [XmlArray(ElementName = "Denied_Networks")]
        [XmlArrayItem(ElementName = "Network")]
        public string[] SourceNetworks
        {
            get { return _DeniedNetworks; }
            set
            {
                if (null != value)
                {
                    if (value.Length > 60)
                        throw new Exception("Maximum characters allowed are 60!");

                    _DeniedNetworks = value;
                }
            }
        }

        /// <summary>
        /// Select this option to ensure that each session will be bound to one web server.
        /// </summary>
        [XmlElement]
        public bool Stickysession_Status { get; set; }

        /// <summary>
        /// Select this option if you want to send all requests to the first selected web server, and use the other web servers only as a backup.
        /// </summary>
        [XmlElement]
        public bool Hot_Standby { get; set; }

        /// <summary>
        /// Select this option to enable Websocket passthrough.
        /// </summary>
        [XmlElement]
        public bool Websocket_Passthrough { get; set; }
    }
}
