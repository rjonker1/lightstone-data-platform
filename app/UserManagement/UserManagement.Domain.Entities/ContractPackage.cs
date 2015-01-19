using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ContractPackage : Entity
    {

        public System.Guid ContractId { get; set; }
        public System.Guid PackageId { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Package Package { get; set; }

    }
}