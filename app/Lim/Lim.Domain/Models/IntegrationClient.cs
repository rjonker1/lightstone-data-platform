using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Models
{
    [DataContract]
    public class IntegrationClient
    {
        public const string Select = @"select ic.* from IntegrationClients ic where ic.ConfigurationId = @ConfigurationId and ic.IsActive = 1";
        public IntegrationClient()
        {
            
        }

        private IntegrationClient(Guid clientCustomerId, int accountNumber, int configurationId, bool isActive)
        {
            ClientCustomerId = clientCustomerId;
            AccountNumber = accountNumber;
            ConfigurationId = configurationId;
            IsActive = isActive;
        }

        private IntegrationClient(long id, Guid clientCustomerId, int accountNumber, long configurationId, bool isActive,
            DateTime dateModified, string modifiedBy)
        {
            Id = id;
            ClientCustomerId = clientCustomerId;
            AccountNumber = accountNumber;
            ConfigurationId = configurationId;
            IsActive = isActive;
            DateModified = dateModified;
            ModifiedBy = modifiedBy;
        }

        public static IntegrationClient New(Guid clientCustomerId, int accountNumber, int configurationId, bool isActive)
        {
            return new IntegrationClient(clientCustomerId, accountNumber, configurationId, isActive);
        }

        public static IntegrationClient Existing(long id, Guid clientCustomerId, int accountNumber, long configurationId, bool isActive,
            DateTime dateModified, string modifiedBy)
        {
            return new IntegrationClient(id, clientCustomerId, accountNumber, configurationId, isActive, dateModified, modifiedBy);
        }

        [DataMember]
        public long Id { get; private set; }
        [DataMember]
        public Guid ClientCustomerId { get; private set; }
        [DataMember]
        public int AccountNumber { get; private set; }
        [DataMember]
        public long ConfigurationId { get; private set; }
        [DataMember]
        public bool IsActive { get; private set; }
        [DataMember]
        public DateTime DateCreated { get; private set; }
        [DataMember]
        public DateTime DateModified { get; private set; }
        [DataMember]
        public string ModifiedBy { get; private set; }
    }
}