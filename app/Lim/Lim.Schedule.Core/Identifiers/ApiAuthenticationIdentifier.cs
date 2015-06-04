using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class ApiAuthenticationIdentifier
    {
        public ApiAuthenticationIdentifier(bool hasAuthentication, ApiAuthenticationTypeIdentifier authenticationType, string username,
            string password, string authenticationKey, string authenticationToken)
        {
            Username = username;
            Password = password;
            HasAuthentication = hasAuthentication;
            AuthenticationType = authenticationType;
            AuthenticationKey = authenticationKey;
            AuthenticationToken = authenticationToken;
        }

        [DataMember]
        public bool HasAuthentication { get; private set; }

        [DataMember]
        public ApiAuthenticationTypeIdentifier AuthenticationType { get; private set; }

        [DataMember]
        public string Username { get; private set; }

        [DataMember]
        public string Password { get; private set; }

        [DataMember]
        public string AuthenticationKey { get; private set; }

        [DataMember]
        public string AuthenticationToken { get; private set; }
    }
}
