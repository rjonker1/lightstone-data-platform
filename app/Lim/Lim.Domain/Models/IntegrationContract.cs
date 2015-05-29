using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Models
{
    [DataContract]
    public class IntegrationContract
    {
        public const string Select = @"select ic.* from IntegrationContracts ic where ic.ConfigurationId = @ConfigurationId and ic.IsActive = 1";
        public const string SelectContract = @"select ic.* from IntegrationContracts ic where ic.ConfigurationId = @ConfigurationId and ic.IsActive = 1 and ic.Contract = @ContractId";
        public IntegrationContract()
        {
            
        }

        private IntegrationContract(long id, Guid contractId, long configurationId, bool isActive, DateTime dateModified,
            string modifiedBy, Guid clientCustomerId)
        {
            Id = id;
            Contract = contractId;
            ClientCustomerId = clientCustomerId;
            ConfigurationId = configurationId;
            IsActive = isActive;
            DateModified = dateModified;
            ModifiedBy = modifiedBy;
        }

        private IntegrationContract(Guid contractId, Guid clientCustomerId, long configurationId, bool isActive)
        {
            Contract = contractId;
            ClientCustomerId = clientCustomerId;
            ConfigurationId = configurationId;
            IsActive = isActive;
        }

        public static IntegrationContract New(Guid contractId, long configurationId, bool isActive, Guid clientCustomerId)
        {
            return new IntegrationContract(contractId, clientCustomerId, configurationId, isActive);
        }

        public static IntegrationContract Existing(long id, Guid contractId, long configurationId, bool isActive,
            DateTime dateModified,
            string modifiedBy, Guid clientCustomerId)
        {
            return new IntegrationContract(id, contractId, configurationId, isActive, dateModified, modifiedBy,clientCustomerId);
        }

        [DataMember]
        public long Id { get; private set; }
        [DataMember]
        public Guid Contract { get; private set; }

        [DataMember]
        public Guid ClientCustomerId { get; private set; }

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
