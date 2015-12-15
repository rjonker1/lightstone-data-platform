using System;
using System.Runtime.Serialization;

namespace Lim.Dtos
{
    [DataContract]
    public class IntegrationPackageDto
    {
        public IntegrationPackageDto()
        {

        }

        private IntegrationPackageDto(long id, long configurationId, Guid packageId, Guid contractId, bool isActive, DateTime? dateModified,
            string modifiedBy)
        {
            Id = id;
            ConfigurationId = configurationId;
            PackageId = packageId;
            ContractId = contractId;
            IsActive = isActive;
            DateModified = dateModified;
            ModifiedBy = modifiedBy;
        }

        private IntegrationPackageDto(long configurationId, Guid packageId, Guid contractId, bool isActive)
        {
            ConfigurationId = configurationId;
            ContractId = contractId;
            PackageId = packageId;
            IsActive = isActive;
        }

        public static IntegrationPackageDto Existing(long id, long configurationId, Guid packageId, bool isActive, DateTime? dateModified,
            string modifiedBy, Guid contractId)
        {
            return new IntegrationPackageDto(id, configurationId, packageId, contractId, isActive, dateModified, modifiedBy);
        }

        public IntegrationPackageDto New(long configurationId, Guid packageId, Guid contractId, bool isActive)
        {
            return new IntegrationPackageDto(configurationId, packageId, contractId, isActive);
        }

        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public long ConfigurationId { get; private set; }

        [DataMember]
        public Guid PackageId { get; private set; }

        [DataMember]
        public Guid ContractId { get; private set; }

        [DataMember]
        public DateTime DateCreated { get; private set; }

        [DataMember]
        public bool IsActive { get; private set; }

        [DataMember]
        public DateTime? DateModified { get; private set; }

        [DataMember]
        public string ModifiedBy { get; private set; }
    }
}