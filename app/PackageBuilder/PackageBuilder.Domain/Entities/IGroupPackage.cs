using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IGroupPackage : IPackageAccessControl
    {
        ICustomer Customer { get; set; }
        IGroup Group { get; set; }
    }
}