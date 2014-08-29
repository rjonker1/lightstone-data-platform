using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Contracts.Enitities
{
    public interface IRolePackage : IPackageAccessControl
    {
        ICustomer Customer { get; set; }
        IRole Role { get; set; }
    }
}