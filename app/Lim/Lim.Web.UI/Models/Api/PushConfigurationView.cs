using System;
using System.Runtime.Serialization;

namespace Lim.Web.UI.Models.Api
{
    [DataContract]
    public class PushConfigurationView
    {
        public const string Select =
            @"select c.*, ca.BaseAddress,ca.Suffix,ca.Username,ca.Password,ca.HasAuthentication,ca.AuthenticationToken,ca.AuthenticationKey,ca.AuthenticationType,p.PackageId, ft.Type Frequency, ac.Type Action, it.Type Integration from Configuration c join ConfigurationApi ca on c.Id = ca.ConfigurationId join Packages p on c.id = p.ConfigurationId join FrequencyType ft on c.FrequencyType = ft.Id join ActionType ac on c.ActionType = ac.Id  join IntegrationType it on c.IntegrationType = it.Id where c.Id = @Id and p.IsActive = 1";

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public Guid Key { get; set; }

        [DataMember]
        public int FrequencyType { get; set; }

        [DataMember]
        public int ActionType { get; set; }

        [DataMember]
        public int IntegrationType { get; set; }

        [DataMember]
        public Guid ClientId { get; set; }

        [DataMember]
        public Guid ContractId { get; set; }

        [DataMember]
        public string AccountNumber { get; set; }

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
        public int AuthenticationType { get; set; }

        [DataMember]
        public Guid PackageId { get; set; }
    }
}