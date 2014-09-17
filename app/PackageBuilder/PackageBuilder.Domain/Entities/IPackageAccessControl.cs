using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IPackageAccessControl : IEntity, IExpirable
    {
        IPackage Package { get; set; }
    }
}