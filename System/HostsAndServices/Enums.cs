using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XgApiWrapper.System.HostsAndServices
{
    public enum HostType
    {
        [XmlEnum("System Host")]
        SystemHost,
        [XmlEnum]
        IP,
        [XmlEnum]
        IPRange,
        [XmlEnum]
        IPList,
        [XmlEnum]
        Network
    }

    public enum MacType
    {
        [XmlEnum]
        MACAddress,
        [XmlEnum]
        MACLIST
    }

    public enum IPProtocol
    {
        [XmlEnum]
        TCP,
        [XmlEnum]
        UDP
    }

    public enum ServiceType
    {
        [XmlEnum]
        TCPorUDP,
        [XmlEnum]
        IP,
        [XmlEnum]
        ICMP,
        [XmlEnum]
        ICMPv6
    }

    public enum ICMPType
    {
        [XmlEnum(Name = "Echo Reply")]
        EchoReply,
        [XmlEnum(Name = "Destination Unreachable")]
        DestinationUnreachable,
        [XmlEnum(Name = "Source Quench")]
        SourceQuench,
        [XmlEnum(Name = "Redirect")]
        Redirect,
        [XmlEnum(Name = "Alternate Host Address")]
        AlternateHostAddress,
        [XmlEnum(Name = "Echo")]
        Echo,
        [XmlEnum(Name = "Router Advertisement")]
        RouterAdvertisement,
        [XmlEnum(Name = "Router Selection")]
        RouterSelection,
        [XmlEnum(Name = "Time Exceeded")]
        TimeExceeded,
        [XmlEnum(Name = "Parameter Problem")]
        ParameterProblem,
        [XmlEnum(Name = "Timestamp")]
        Timestamp,
        [XmlEnum(Name = "Timestamp Reply")]
        TimestampReply,
        [XmlEnum(Name = "Information Request")]
        InformationRequest,
        [XmlEnum(Name = "Information Reply")]
        InformationReply,
        [XmlEnum(Name = "Address Mask Request")]
        AddressMaskRequest,
        [XmlEnum(Name = "Address Mask Reply")]
        AddressMaskReply,
        [XmlEnum(Name = "Traceroute")]
        Traceroute,
        [XmlEnum(Name = "Datagram Conversion Error")]
        DatagramConversionError,
        [XmlEnum(Name = "Mobile Host Redirect")]
        MobileHostRedirect,
        [XmlEnum(Name = "IPv6 Where-Are-You")]
        IPv6WhereAreYou,
        [XmlEnum(Name = "IPv6 I-Am-Here")]
        IPv6IAmHere,
        [XmlEnum(Name = "Mobile Registration Request")]
        MobileRegistrationRequest,
        [XmlEnum(Name = "Mobile Registration Reply")]
        MobileRegistrationReply,
        [XmlEnum(Name = "Domain Name Request")]
        DomainNameRequest,
        [XmlEnum(Name = "Domain Name Reply")]
        DomainNameReply,
        [XmlEnum(Name = "SKIP")]
        SKIP,
        [XmlEnum(Name = "Photuris")]
        Photuris,
        [XmlEnum(Name = "Any Type")]
        AnyType
    }
    
    public enum ICMPv6Type
    {
        [XmlEnum(Name = "Destination Unreachable")] DestinationUnreachable,
        [XmlEnum(Name = "Packet Too Big")] PacketTooBig,
        [XmlEnum(Name = "Time Exceeded")] TimeExceeded,
        [XmlEnum(Name = "Parameter Problem")] ParameterProblem,
        [XmlEnum(Name = "Private experimentation")] PrivateExperimentation,
        [XmlEnum(Name = "Echo Request")] EchoRequest,
        [XmlEnum(Name = "Echo Reply")] EchoReply,
        [XmlEnum(Name = "Multicast Listener Query")] MulticastListenerQuery,
        [XmlEnum(Name = "Multicast Listener Report")] MulticastListenerReport,
        [XmlEnum(Name = "Multicast Listener Done")] MulticastListenerDone,
        [XmlEnum(Name = "Router Solicitation")] RouterSolicitation,
        [XmlEnum(Name = "Router Advertisement")] RouterAdvertisement,
        [XmlEnum(Name = "Neighbor Solicitation")] NeighborSolicitation,
        [XmlEnum(Name = "Neighbor Advertisement")] NeighborAdvertisement,
        [XmlEnum(Name = "Redirect Message")] RedirectMessage,
        [XmlEnum(Name = "Router Renumbering")] RouterRenumbering,
        [XmlEnum(Name = "ICMP Node Information Query")] ICMPNodeInformationQuery,
        [XmlEnum(Name = "ICMP Node Information Response")] ICMPNodeInformationResponse,
        [XmlEnum(Name = "Inverse Neighbor Discovery Solicitation Message")] InverseNeighborDiscoverySolicitationMessage,
        [XmlEnum(Name = "Inverse Neighbor Discovery Advertisement Message")] InverseNeighborDiscoveryAdvertisementMessage,
        [XmlEnum(Name = "Version 2 Multicast Listener Report")] Version2MulticastListenerReport,
        [XmlEnum(Name = "Home Agent Address Discovery Request Message")] HomeAgentAddressDiscoveryRequestMessage,
        [XmlEnum(Name = "Home Agent Address Discovery Reply Message")] HomeAgentAddressDiscoveryReplyMessage,
        [XmlEnum(Name = "Mobile PrefixS olicitation")] MobilePrefixSolicitation,
        [XmlEnum(Name = "Mobile Prefix Advertisement")] MobilePrefixAdvertisement,
        [XmlEnum(Name = "Certification Path Solicitation Message")] CertificationPathSolicitationMessage,
        [XmlEnum(Name = "Certification Path Advertisement Message")] CertificationPathAdvertisementMessage,
        [XmlEnum(Name = "ICMP messages utilized by experimental mobility protocols such as Seamoby")] ICMPmessagesutilizedbyexperimentalmobilityprotocolssuchasSeamoby,
        [XmlEnum(Name = "Multicast Router Advertisement")] MulticastRouterAdvertisement,
        [XmlEnum(Name = "Multicast Router Solicitation")] MulticastRouterSolicitation,
        [XmlEnum(Name = "Multicast Router Termination")] MulticastRouterTermination,
        [XmlEnum(Name = "FMIPv6 Messages")] FMIPv6Messages,
        [XmlEnum(Name = "RPL Control Message")] RPLControlMessage,
        [XmlEnum(Name = "ILNPv6 Locator Update Message")] ILNPv6LocatorUpdateMessage,
        [XmlEnum(Name = "Duplicate Address Request")] DuplicateAddressRequest,
        [XmlEnum(Name = "Duplicate Address Confirmation")] DuplicateAddressConfirmation,
        [XmlEnum(Name = "Any Type")] AnyType
    }
}
