using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Contracts.Enitities
{
    public interface IGroupPackage : IPackageAccessControl
    {
        ICustomer Customer { get; set; }
        IGroup Group { get; set; }
    }
}