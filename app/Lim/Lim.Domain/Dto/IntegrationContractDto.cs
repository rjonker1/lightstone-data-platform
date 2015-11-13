using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Dto
{
    [DataContract]
    public class IntegrationContractDto
    {
        public IntegrationContractDto()
        {

        }

        private IntegrationContractDto(long id, Guid contractId, long configurationId, bool isActive, DateTime? dateModified,
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

        private IntegrationContractDto(Guid contractId, Guid clientCustomerId, long configurationId, bool isActive)
        {
            Contract = contractId;
            ClientCustomerId = clientCustomerId;
            ConfigurationId = configurationId;
            IsActive = isActive;
        }

        public static IntegrationContractDto New(Guid contractId, long configurationId, bool isActive, Guid clientCustomerId)
        {
            return new IntegrationContractDto(contractId, clientCustomerId, configurationId, isActive);
        }

        public static IntegrationContractDto Existing(long id, Guid contractId, long configurationId, bool isActive,
            DateTime? dateModified,
            string modifiedBy, Guid clientCustomerId)
        {
            return new IntegrationContractDto(id, contractId, configurationId, isActive, dateModified, modifiedBy, clientCustomerId);
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
        public DateTime? DateModified { get; private set; }

        [DataMember]
        public string ModifiedBy { get; private set; }

    }
}