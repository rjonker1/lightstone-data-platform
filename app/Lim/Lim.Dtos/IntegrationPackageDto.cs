using System;
namespace Lim.Dtos
{
    public class IntegrationPackageDto
    {
        public virtual long Id { get; set; }
        public virtual ConfigurationDto Configuration { get; set; }
        public virtual System.Guid PackageId { get; set; }
        public virtual System.Guid ContractId { get; set; }
        public virtual DateTime? DateCreated { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime? DateModified { get; set; }
        public virtual string ModifiedBy { get; set; }
    }
}
