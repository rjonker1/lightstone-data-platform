using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Contracts.Enitities
{
    public interface IPackageAccessControl : IEntity, IExpirable
    {
        IPackage Package { get; set; }
    }
}