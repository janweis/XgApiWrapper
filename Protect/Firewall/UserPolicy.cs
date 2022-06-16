using System;
using System.Xml.Serialization;

namespace XgApiWrapper.Protect.Firewall
{
    [Serializable, XmlRoot("UserPolicy")]
    public class UserPolicy : Policy
    {
        /// <summary>
        /// Enable to check whether the specified user/user group from the selected zone is allowed to access the selected service or not.
        /// </summary>
        [XmlElement]
        public State MatchIdentity { get; set; } = State.Disable;

        /// <summary>
        /// Select to accept traffic from unknown users. Captive portal page is displayed to the user where the user can login to access the Internet.
        /// </summary>
        [XmlElement]
        public State ShowCaptivePortal { get; set; } = State.Disable;

        /// <summary>
        /// Select the user(s) or group(s) from the list of available options.
        /// </summary>
        private string[] _Identity;
        [XmlArray(ElementName = "Identity")]
        [XmlArrayItem(ElementName = "Member")]
        public string[] Identity
        {
            get { return _Identity; }
            set
            {
                if (value?.Length > 256)
                    throw new Exception("Maximum characters allowed are 256!");

                _Identity = value;
            }
        }

        /// <summary>
        /// DataAccounting
        /// </summary>
        [XmlElement]
        public State DataAccounting { get; set; } = State.Disable;

    }
}
