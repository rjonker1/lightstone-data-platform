using System;
using System.Runtime.Serialization;

namespace Lim.Dtos
{
    [DataContract]
    public class IntegrationContractDto
    {
        public IntegrationContractDto()
        {

        }

        private IntegrationContractDto(long id, Guid contractId, long configuration, bool isActive, DateTime? dateModified,
            string modifiedBy, Guid clientCustomerId)
        {
            Id = id;
            Contract = contractId;
            ClientCustomerId = clientCustomerId;
            Configuration = configuration;
            IsActive = isActive;
            DateModified = dateModified;
            ModifiedBy = modifiedBy;
        }

        private IntegrationContractDto(Guid contractId, Guid clientCustomerId, long configuration, bool isActive)
        {
            Contract = contractId;
            ClientCustomerId = clientCustomerId;
            Configuration = configuration;
            IsActive = isActive;
        }

        public static IntegrationContractDto New(Guid contractId, long configuration, bool isActive, Guid clientCustomerId)
        {
            return new IntegrationContractDto(contractId, clientCustomerId, configuration, isActive);
        }

        public static IntegrationContractDto Existing(long id, Guid contractId, long configuration, bool isActive,
            DateTime? dateModified,
            string modifiedBy, Guid clientCustomerId)
        {
            return new IntegrationContractDto(id, contractId, configuration, isActive, dateModified, modifiedBy, clientCustomerId);
        }

        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public Guid Contract { get; private set; }

        [DataMember]
        public Guid ClientCustomerId { get; private set; }

        [DataMember]
        public long Configuration { get; private set; }

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