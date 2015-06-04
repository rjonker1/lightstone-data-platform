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
        //public static readonly string Select =
        //    @"select c.Id,c.[Key],c.FrequencyType,c.ActionType Action,c.IntegrationType,c.ClientId,api.BaseAddress,api.Suffix,api.Username,api.Password,api.AuthenticationToken,api.AuthenticationKey,api.HasAuthentication,api.AuthenticationType from Configuration c join ConfigurationApi api on c.Id = api.ConfigurationId where c.IsActive = 1 and c.FrequencyType = @FrequencyType and c.ActionType = @Action and c.IntegrationType = @IntegrationType";

        ////public static readonly string SelectWithContract =
        ////    @"select c.Id,c.[Key],c.FrequencyType,c.ActionType Action,c.IntegrationType,c.ClientId,clients.ClientCustomerId, contracts.Contract,clients.AccountNumber, api.BaseAddress,api.Suffix,api.Username,api.Password,api.AuthenticationToken,api.AuthenticationKey,api.HasAuthentication,api.AuthenticationType,package.PackageId from Configuration c join ConfigurationApi api on c.Id = api.ConfigurationId join IntegrationPackages package on c.Id = package.ConfigurationId join IntegrationContracts contracts on c.Id = contracts.ConfigurationId join IntegrationClients clients on c.Id = clients.ConfigurationId where c.IsActive = 1 and c.FrequencyType = @FrequencyType and c.ActionType = @Action and c.IntegrationType = @IntegrationType and package.IsActive = 1 and contracts.IsActive = 1 and clients.IsActive = 1 and contracts.Contract = @ContractId and package.PackageId =  @PackageId";

        //public static readonly string SelectWithCustomDay =
        //    @"select c.Id,c.[Key],c.FrequencyType,c.ActionType Action,c.IntegrationType,c.ClientId,api.BaseAddress,api.Suffix,api.Username,api.Password,api.AuthenticationToken,api.AuthenticationKey,api.HasAuthentication,api.AuthenticationType from Configuration c join ConfigurationApi api on c.Id = api.ConfigurationId where c.IsActive = 1 and c.FrequencyType = @FrequencyType and c.ActionType = @Action and c.IntegrationType = @IntegrationType and c.CustomFrequencyDay = @CustomFrequencyDay and c.CustomFrequencyTime >= Cast(CONVERT(VARCHAR(5),Dateadd(mi,-1, getdate()),108) as time) and c.CustomFrequencyTime <= Cast(CONVERT(VARCHAR(5),Dateadd(mi,1, getdate()),108) as time)";


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