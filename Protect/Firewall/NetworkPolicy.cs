using System;
using System.Xml.Serialization;

namespace XgApiWrapper.Protect.Firewall
{
    [Serializable, XmlRoot("NetworkPolicy")]
    public class NetworkPolicy : Policy { }
}
