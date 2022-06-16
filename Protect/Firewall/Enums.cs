using System.Xml.Serialization;

namespace XgApiWrapper.Protect.Firewall
{

    public enum HealthStatus
    {
        [XmlEnum] Green,
        [XmlEnum] Yellow,
        [XmlEnum] NoRestriction
    }

    public enum Operation
    {
        [XmlEnum] AND,
        [XmlEnum] OR
    }

    public enum RuleState
    {
        [XmlEnum] Apply,
        [XmlEnum] Revoke
    }

    public enum RuleAction
    {
        [XmlEnum] Accept,
        [XmlEnum] Drop,
        [XmlEnum] Reject
    }

    public enum ThreatsFilterCategorie
    {
        [XmlEnum] application_attacks,
        [XmlEnum] sql_injection_attacks,
        [XmlEnum] xss_attacks,
        [XmlEnum] protocol_enforcement,
        [XmlEnum] scanner_detection,
        [XmlEnum] data_leakages
    }

    public enum RulePosition
    {
        [XmlEnum] Top,
        [XmlEnum] Bottom,
        [XmlEnum] After,
        [XmlEnum] Befor
    }

    public enum RulePolicyType
    {
        [XmlEnum] Network,
        [XmlEnum] User,
        [XmlEnum] HTTPBased
    }

    public enum GroupPolicyType
    {
        [XmlEnum(Name = "User/network rule")] UserNetworkRule,
        [XmlEnum(Name = "Network rule")] NetworkRule,
        [XmlEnum(Name = "User rule")] UserRule,
        [XmlEnum(Name = "WAF rule")] WafRule,
        [XmlEnum] Any,
    }

    public enum RuleCondition
    {
        [XmlEnum] Include,
        [XmlEnum] Exclude
    }

    public enum HealthState
    {
        [XmlEnum] GREEN,
        [XmlEnum] YELLOW,
        [XmlEnum(Name = "No Restriction")] NoRestriction
    }

}
