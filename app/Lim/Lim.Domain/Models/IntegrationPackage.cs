using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Models
{
    [DataContract]
    public class IntegrationPackage
    {
        public const string Select = @"select p.* from IntegrationPackages p where p.ConfigurationId = @ConfigurationId and p.IsActive = 1";
        public const string SelectPackage = @"select p.* from IntegrationPackages p where p.ConfigurationId = @ConfigurationId and p.IsActive = 1 and p.PackageId = @PackageId and p.ContractId = @ContractId";

        public IntegrationPackage()
        {

        }

        private IntegrationPackage(long id, long configurationId, Guid packageId, Guid contractId, bool isActive, DateTime dateModified,
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

        private IntegrationPackage(long configurationId, Guid packageId, Guid contractId, bool isActive)
        {
            ConfigurationId = configurationId;
            ContractId = contractId;
            PackageId = packageId;
            IsActive = isActive;
        }

        public IntegrationPackage Existing(long id, long configurationId, Guid packageId, bool isActive, DateTime dateModified,
            string modifiedBy, Guid contractId)
        {
            return new IntegrationPackage(id, configurationId, packageId, contractId, isActive, dateModified, modifiedBy);
        }

        public IntegrationPackage New(long configurationId, Guid packageId, Guid contractId, bool isActive)
        {
            return new IntegrationPackage(configurationId, packageId, contractId, isActive);
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
        public DateTime DateModified { get; private set; }

        [DataMember]
        public string ModifiedBy { get; private set; }
    }
}