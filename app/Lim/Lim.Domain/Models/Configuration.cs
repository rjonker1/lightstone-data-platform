using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Models
{
    [DataContract]
    public class ApiPushConfiguration
    {
        public static readonly string Select =
            @"select c.Id,c.[Key],c.FrequencyType,c.ActionType Action,c.IntegrationType,c.ClientId,c.ContractId,c.AccountNumber, api.BaseAddress,api.Suffix,api.Username,api.Password,api.AuthenticationToken,api.AuthenticationKey,api.HasAuthentication,api.AuthenticationType,package.PackageId from Configuration c join ConfigurationApi api on c.Id = api.ConfigurationId join Packages package on c.Id = package.ConfigurationId where c.IsActive = true and FrequencyType = @FrequencyType and Action = @Action and IntegrationType = @IntegrationType";

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
        public Guid ClientId { get; set; }

        [DataMember]
        public Guid ContractId { get; set; }

        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public Guid PackageId { get; set; }

    }

    [DataContract]
    public class ApiPullConfiguration
    {
        public static readonly string Select =
            @"select c.Id,c.[Key],c.FrequencyType,c.ActionType Action,c.IntegrationType,c.ClientId,c.ContractId,c.AccountNumber, api.BaseAddress,api.Suffix,api.Username,api.Password,api.AuthenticationToken,api.AuthenticationKey,api.HasAuthentication,api.AuthenticationType,package.PackageId from Configuration c join ConfigurationApi api on c.Id = api.ConfigurationId join Packages package on c.Id = package.ConfigurationId where c.IsActive = true and FrequencyType = @FrequencyType and Action = @Action and IntegrationType = @IntegrationType";

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
        public Guid ClientId { get; set; }

        [DataMember]
        public Guid ContractId { get; set; }

        [DataMember]
        public string AccountNumber { get; set; }

        [DataMember]
        public int FrequencyConfigurationId { get; set; }

    }
}
