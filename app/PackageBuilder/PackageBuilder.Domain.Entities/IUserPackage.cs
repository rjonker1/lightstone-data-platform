using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IUserPackage : IPackageAccessControl
    {
        ICustomer Customer { get; set; }
        IUser User { get; set; }
    }
}