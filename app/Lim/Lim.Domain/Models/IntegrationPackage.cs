using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Models
{
    [DataContract]
    public class IntegrationPackage
    {
        public IntegrationPackage()
        {

        }

        private IntegrationPackage(long id, long configurationId, Guid packageId, bool isActive, DateTime dateModified,
            string modifiedBy)
        {
            Id = id;
            ConfigurationId = configurationId;
            PackageId = packageId;
            IsActive = isActive;
            DateModified = dateModified;
            ModifiedBy = modifiedBy;
        }

        private IntegrationPackage(long configurationId, Guid packageId, bool isActive)
        {
            ConfigurationId = configurationId;
            PackageId = packageId;
            IsActive = isActive;
        }

        public IntegrationPackage Existing(long id, long configurationId, Guid packageId, bool isActive, DateTime dateModified,
            string modifiedBy)
        {
            return new IntegrationPackage(id, configurationId, packageId, isActive, dateModified, modifiedBy);
        }

        public IntegrationPackage New(long configurationId, Guid packageId, bool isActive)
        {
            return new IntegrationPackage(configurationId, packageId, isActive);
        }

        [DataMember]
        public long Id { get; private set; }

        [DataMember]
        public long ConfigurationId { get; private set; }

        [DataMember]
        public Guid PackageId { get; private set; }

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