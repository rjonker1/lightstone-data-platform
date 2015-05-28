using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Dto
{
    [DataContract]
    public class ApiPushConfigurationDto
    {
        public static readonly string Select =
            @"select c.Id,c.[Key],c.FrequencyType,c.ActionType Action,c.IntegrationType,c.ClientId,api.BaseAddress,api.Suffix,api.Username,api.Password,api.AuthenticationToken,api.AuthenticationKey,api.HasAuthentication,api.AuthenticationType from Configuration c join ConfigurationApi api on c.Id = api.ConfigurationId where c.IsActive = 1 and c.FrequencyType = @FrequencyType and c.ActionType = @Action and c.IntegrationType = @IntegrationType";

        //public static readonly string SelectWithContract =
        //    @"select c.Id,c.[Key],c.FrequencyType,c.ActionType Action,c.IntegrationType,c.ClientId,clients.ClientCustomerId, contracts.Contract,clients.AccountNumber, api.BaseAddress,api.Suffix,api.Username,api.Password,api.AuthenticationToken,api.AuthenticationKey,api.HasAuthentication,api.AuthenticationType,package.PackageId from Configuration c join ConfigurationApi api on c.Id = api.ConfigurationId join IntegrationPackages package on c.Id = package.ConfigurationId join IntegrationContracts contracts on c.Id = contracts.ConfigurationId join IntegrationClients clients on c.Id = clients.ConfigurationId where c.IsActive = 1 and c.FrequencyType = @FrequencyType and c.ActionType = @Action and c.IntegrationType = @IntegrationType and package.IsActive = 1 and contracts.IsActive = 1 and clients.IsActive = 1 and contracts.Contract = @ContractId and package.PackageId =  @PackageId";

        public static readonly string SelectWithCustomDay =
            @"select c.Id,c.[Key],c.FrequencyType,c.ActionType Action,c.IntegrationType,c.ClientId,api.BaseAddress,api.Suffix,api.Username,api.Password,api.AuthenticationToken,api.AuthenticationKey,api.HasAuthentication,api.AuthenticationType from Configuration c join ConfigurationApi api on c.Id = api.ConfigurationId where c.IsActive = 1 and c.FrequencyType = @FrequencyType and c.ActionType = @Action and c.IntegrationType = @IntegrationType and c.CustomFrequencyDay = @CustomFrequencyDay and c.CustomFrequencyTime >= Cast(CONVERT(VARCHAR(5),Dateadd(mi,-1, getdate()),108) as time) and c.CustomFrequencyTime <= Cast(CONVERT(VARCHAR(5),Dateadd(mi,1, getdate()),108) as time)";
        
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public Guid Key { get; set; }

        [DataMember]
        public int FrequencyType { get; set; }

        [DataMember]
        public int Action { get; set; }

        [DataMember]
        public int IntegrationType { get; set; }

        [DataMember]
        public string BaseAddress { get; set; }

        [DataMember]
        public string Suffix { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string AuthenticationToken { get; set; }

        [DataMember]
        public string AuthenticationKey { get; set; }

        [DataMember]
        public bool HasAuthentication { get; set; }

        [DataMember]
        public int AuthenticationType { get; set; }

        [DataMember]
        public long ClientId { get; set; }

        //[DataMember]
        //public Guid ClientCustomerId { get; set; }

        //[DataMember]
        //public Guid Contract { get; set; }

        //[DataMember]
        //public string AccountNumber { get; set; }

        //[DataMember]
        //public Guid PackageId { get; set; }

    }

    [DataContract]
    public class ApiPullConfigurationDto
    {
        public static readonly string Select =
            @"select c.Id,c.[Key],c.FrequencyType,c.ActionType Action,c.IntegrationType,c.ClientId,api.BaseAddress,api.Suffix,api.Username,api.Password,api.AuthenticationToken,api.AuthenticationKey,api.HasAuthentication,api.AuthenticationType from Configuration c join ConfigurationApi api on c.Id = api.ConfigurationId where c.IsActive = 1 and c.FrequencyType = @FrequencyType and c.ActionType = @Action and c.IntegrationType = @IntegrationType";

        //public static readonly string SelectWithContract =
        //    @"select c.Id,c.[Key],c.FrequencyType,c.ActionType Action,c.IntegrationType,c.ClientId,clients.ClientCustomerId, contracts.Contract,clients.AccountNumber, api.BaseAddress,api.Suffix,api.Username,api.Password,api.AuthenticationToken,api.AuthenticationKey,api.HasAuthentication,api.AuthenticationType,package.PackageId from Configuration c join ConfigurationApi api on c.Id = api.ConfigurationId join IntegrationPackages package on c.Id = package.ConfigurationId join IntegrationContracts contracts on c.Id = contracts.ConfigurationId join IntegrationClients clients on c.Id = clients.ConfigurationId where c.IsActive = 1 and c.FrequencyType = @FrequencyType and c.ActionType = @Action and c.IntegrationType = @IntegrationType and package.IsActive = 1 and contracts.IsActive = 1 and clients.IsActive = 1 and contracts.Contract = @ContractId and package.PackageId =  @PackageId";

        public static readonly string SelectWithCustomDay =
            @"select c.Id,c.[Key],c.FrequencyType,c.ActionType Action,c.IntegrationType,c.ClientId,api.BaseAddress,api.Suffix,api.Username,api.Password,api.AuthenticationToken,api.AuthenticationKey,api.HasAuthentication,api.AuthenticationType from Configuration c join ConfigurationApi api on c.Id = api.ConfigurationId where c.IsActive = 1 and c.FrequencyType = @FrequencyType and c.ActionType = @Action and c.IntegrationType = @IntegrationType and c.CustomFrequencyDay = @CustomFrequencyDay and c.CustomFrequencyTime >= Cast(CONVERT(VARCHAR(5),Dateadd(mi,-1, getdate()),108) as time) and c.CustomFrequencyTime <= Cast(CONVERT(VARCHAR(5),Dateadd(mi,1, getdate()),108) as time)";
        
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public Guid Key { get; set; }

        [DataMember]
        public int FrequencyType { get; set; }

        [DataMember]
        public int Action { get; set; }

        [DataMember]
        public int IntegrationType { get; set; }

        [DataMember]
        public string BaseAddress { get; set; }

        [DataMember]
        public string Suffix { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string AuthenticationToken { get; set; }

        [DataMember]
        public string AuthenticationKey { get; set; }

        [DataMember]
        public bool HasAuthentication { get; set; }

        [DataMember]
        public int AuthenticationType { get; set; }

        [DataMember]
        public long ClientId { get; set; }

        //[DataMember]
        //public Guid Contract { get; set; }

        //[DataMember]
        //public Guid ClientCustomerId { get; set; }

        //[DataMember]
        //public string AccountNumber { get; set; }

        //[DataMember]
        //public int FrequencyConfigurationId { get; set; }

    }
}
