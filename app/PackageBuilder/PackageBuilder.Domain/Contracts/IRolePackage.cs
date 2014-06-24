using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Contracts
{
    public interface IRolePackage : IPackageAccessControl
    {
        ICustomer Customer { get; set; }
        IRole Role { get; set; }
    }
}