using System.Runtime.Serialization;

namespace Lim.Dtos
{
    [DataContract]
    public class ConfigurationApiDto
    {
        private ConfigurationApiDto(long id,string baseAddress, string suffix,string username,string password, string authenticationToken, string authenticationKey, bool hasAuthentication, short authenticationType, ConfigurationDto configuration)
        {
            Id = id;
            BaseAddress = baseAddress;
            Suffix = suffix;
            Username = username;
            Password = password;
            AuthenticationToken = authenticationToken;
            AuthenticationKey = authenticationKey;
            HasAuthentication = hasAuthentication;
            AuthenticationType = authenticationType;
            Configuration = configuration;
        }

        public static ConfigurationApiDto Existing(long id, string baseAddress, string suffix, string username, string password, string authenticationToken, string authenticationKey, bool hasAuthentication, short authenticationType, ConfigurationDto configuration)
        {
            return new ConfigurationApiDto(id, baseAddress, suffix, username, password, authenticationToken, authenticationKey, hasAuthentication, authenticationType, configuration);
        }


        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public ConfigurationDto Configuration { get; private set; }

        [DataMember]
        public string BaseAddress { get; private set; }

        [DataMember]
        public string Suffix { get; private set; }

        [DataMember]
        public string Username { get; private set; }

        [DataMember]
        public string Password { get; private set; }

        [DataMember]
        public string AuthenticationToken { get; private set; }

        [DataMember]
        public string AuthenticationKey { get; private set; }

        [DataMember]
        public bool HasAuthentication { get; private set; }

        [DataMember]
        public short AuthenticationType { get; private set; }

    }
}