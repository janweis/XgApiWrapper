using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper
{
    [XmlRoot(ElementName = "Login")]
    public class Connection
    {
        public string IPAddress { get; set; }
        public uint Port { get; set; }
        
        [XmlElement]
        public string Username { get; set; }
        
        [XmlElement]
        public string Password { get; set; }

        public Connection() { }

        public Connection(string iPAddress, string username, string password, uint port = 4444)
        {
            IPAddress = iPAddress;
            Username = username;
            Password = password;
            Port = port;
        }
    }
}
