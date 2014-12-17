using PackageBuilder.Core.Entities;
using IPackage = PackageBuilder.Domain.Entities.Packages.WriteModels.IPackage;

namespace PackageBuilder.Domain.Entities
{
    public interface IPackageAccessControl : IEntity, IExpirable
    {
        IPackage Package { get; set; }
    }
}