using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IRolePackage : IPackageAccessControl
    {
        ICustomer Customer { get; set; }
        IRole Role { get; set; }
    }
}