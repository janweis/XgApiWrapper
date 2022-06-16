using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper
{


    public enum State
    {
        [XmlEnum] Enable,
        [XmlEnum] Disable
    }

    public enum IPFamily
    {
        [XmlEnum] IPv4,
        [XmlEnum] IPv6
    }
}
