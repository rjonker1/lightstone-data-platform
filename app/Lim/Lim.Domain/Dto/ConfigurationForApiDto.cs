using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Dto
{
    [DataContract]
    public class ApiPushConfigurationDto
    {
        private ApiPushConfigurationDto(long id, Guid key, short frequencyType, short action, short integration, string baseAddress, string suffix,
            string username,
            string password, string authenticationToken, string authenticationKey, bool hasAuthentication, short authenticationType, long clientId)
        {
            Id = id;
            Key = key;
            FrequencyType = frequencyType;
            Action = action;
            IntegrationType = integration;
            BaseAddress = baseAddress;
            Suffix = suffix;
            Username = username;
            Password = password;
            AuthenticationToken = authenticationToken;
            AuthenticationKey = authenticationKey;
            HasAuthentication = hasAuthentication;
            AuthenticationType = authenticationType;
            ClientId = clientId;
        }

        public static ApiPushConfigurationDto Existing(long id, Guid key, short frequencyType, short action, short integration, string baseAddress,
            string suffix,
            string username,
            string password, string authenticationToken, string authenticationKey, bool hasAuthentication, short authenticationType, long clientId)
        {
            return new ApiPushConfigurationDto(id, key, frequencyType, action, integration, baseAddress, suffix, username, password,
                authenticationToken, authenticationKey, hasAuthentication, authenticationType, clientId);
        }


        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public Guid Key { get; private set; }

        [DataMember]
        public short FrequencyType { get; private set; }

        [DataMember]
        public short Action { get; private set; }

        [DataMember]
        public short IntegrationType { get; private set; }

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

        [DataMember]
        public long ClientId { get; private set; }

    }

    [DataContract]
    public class ApiPullConfigurationDto
    {
       
        private ApiPullConfigurationDto(long id, Guid key, short frequencyType, short action, short integration, string baseAddress, string suffix,
            string username,
            string password, string authenticationToken, string authenticationKey, bool hasAuthentication, short authenticationType, long clientId)
        {
            Id = id;
            Key = key;
            FrequencyType = frequencyType;
            Action = action;
            IntegrationType = integration;
            BaseAddress = baseAddress;
            Suffix = suffix;
            Username = username;
            Password = password;
            AuthenticationToken = authenticationToken;
            AuthenticationKey = authenticationKey;
            HasAuthentication = hasAuthentication;
            AuthenticationType = authenticationType;
            ClientId = clientId;
        }

        public static ApiPullConfigurationDto Existing(long id, Guid key, short frequencyType, short action, short integration, string baseAddress,
            string suffix,
            string username,
            string password, string authenticationToken, string authenticationKey, bool hasAuthentication, short authenticationType, long clientId)
        {
            return new ApiPullConfigurationDto(id, key, frequencyType, action, integration, baseAddress, suffix, username, password,
                authenticationToken, authenticationKey, hasAuthentication, authenticationType, clientId);
        }
        
        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public Guid Key { get; private set; }

        [DataMember]
        public short FrequencyType { get; private set; }

        [DataMember]
        public short Action { get; private set; }

        [DataMember]
        public short IntegrationType { get; private set; }

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
        public int AuthenticationType { get; private set; }

        [DataMember]
        public long ClientId { get; private set; }
    }
}