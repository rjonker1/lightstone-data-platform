using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Models
{
    [DataContract]
    public class IntegrationContract
    {
        public const string Select = @"select ic.* from IntegrationContracts ic where ic.Id = @Id";
        public IntegrationContract()
        {
            
        }

        private IntegrationContract(long id, Guid contractId, long configurationId, bool isActive, DateTime dateModified,
            string modifiedBy)
        {
            Id = id;
            Contract = contractId;
            ConfigurationId = configurationId;
            IsActive = isActive;
            DateModified = dateModified;
            ModifiedBy = modifiedBy;
        }

        private IntegrationContract(Guid contractId, long configurationId, bool isActive)
        {
            Contract = contractId;
            ConfigurationId = configurationId;
            IsActive = isActive;
        }

        public static IntegrationContract New(Guid contractId, long configurationId, bool isActive)
        {
            return new IntegrationContract(contractId, configurationId, isActive);
        }

        public static IntegrationContract Existing(long id, Guid contractId, long configurationId, bool isActive,
            DateTime dateModified,
            string modifiedBy)
        {
            return new IntegrationContract(id, contractId, configurationId, isActive, dateModified, modifiedBy);
        }

        [DataMember]
        public long Id { get; private set; }
        [DataMember]
        public Guid Contract { get; private set; }
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
