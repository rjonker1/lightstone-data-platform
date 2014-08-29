using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Contracts.Enitities
{
    public interface IUserPackage : IPackageAccessControl
    {
        ICustomer Customer { get; set; }
        IUser User { get; set; }
    }
}