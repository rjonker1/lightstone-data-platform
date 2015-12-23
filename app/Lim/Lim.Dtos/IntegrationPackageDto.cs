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

        private IntegrationPackageDto(long id, long configuration, Guid packageId, Guid contractId, bool isActive, DateTime? dateModified,
            string modifiedBy)
        {
            Id = id;
            Configuration = configuration;
            PackageId = packageId;
            ContractId = contractId;
            IsActive = isActive;
            DateModified = dateModified;
            ModifiedBy = modifiedBy;
        }

        private IntegrationPackageDto(long configuration, Guid packageId, Guid contractId, bool isActive)
        {
            Configuration = configuration;
            ContractId = contractId;
            PackageId = packageId;
            IsActive = isActive;
        }

        public static IntegrationPackageDto Existing(long id, long configuration, Guid packageId, bool isActive, DateTime? dateModified,
            string modifiedBy, Guid contractId)
        {
            return new IntegrationPackageDto(id, configuration, packageId, contractId, isActive, dateModified, modifiedBy);
        }

        public IntegrationPackageDto New(long configuration, Guid packageId, Guid contractId, bool isActive)
        {
            return new IntegrationPackageDto(configuration, packageId, contractId, isActive);
        }

        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public long Configuration { get; private set; }

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