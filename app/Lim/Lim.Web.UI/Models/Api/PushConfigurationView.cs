using System;
using System.Runtime.Serialization;

namespace Lim.Web.UI.Models.Api
{
    [DataContract]
    public class PushConfigurationView
    {
        public const string Select =
            @"select Client.Name ClientName, c.*, ca.BaseAddress,ca.Suffix,ca.Username,ca.Password,ca.HasAuthentication,ca.AuthenticationToken,ca.AuthenticationKey,ca.AuthenticationType,p.PackageId IntegrationPackageId, ft.Type Frequency, ac.Type Action, it.Type Integration,ic.ClientCustomerId IntegrationClientId, contracts.Contract IntegrationContractId, ic.AccountNumber from Configuration c join ConfigurationApi ca on c.Id = ca.ConfigurationId join IntegrationPackages p on c.id = p.ConfigurationId join FrequencyType ft on c.FrequencyType = ft.Id join ActionType ac on c.ActionType = ac.Id join IntegrationType it on c.IntegrationType = it.Id join Client on Client.id = c.ClientId join IntegrationClients ic on c.id = ic.ConfigurationId join IntegrationContracts contracts on c.Id = contracts.ConfigurationId where c.Id = @Id and c.ClientId = @ClientId and contracts.IsActive = 1 and p.IsActive = 1 and ic.IsActive = 1";

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public Guid Key { get; set; }

        [DataMember]
        public long ClientId { get; set; }

        [DataMember]
        public string ClientName { get; set; }

        [DataMember]
        public short FrequencyType { get; set; }

        [DataMember]
        public short ActionType { get; set; }

        [DataMember]
        public short IntegrationType { get; set; }

        [DataMember]
        public Guid IntegrationClientId { get; set; }

        [DataMember]
        public Guid IntegrationContractId { get; set; }

        [DataMember]
        public int AccountNumber { get; set; }

        [DataMember]
        public DateTime DateCreated { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public string BaseAddress { get; set; }

        [DataMember]
        public string Suffix { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public bool HasAuthentication { get; set; }

        [DataMember]
        public string AuthenticationToken { get; set; }

        [DataMember]
        public string AuthenticationKey { get; set; }

        [DataMember]
        public short AuthenticationType { get; set; }

        [DataMember]
        public Guid IntegrationPackageId { get; set; }
        [DataMember]
        public TimeSpan CustomFrequencyTime { get; set; }
        [DataMember]
        public string CustomFrequencyDay { get; set; }
    }
}