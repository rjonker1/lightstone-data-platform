using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Contracts
{
    public interface IPackageAccessControl : IEntity, IExpirable
    {
        IPackage Package { get; set; }
    }
}