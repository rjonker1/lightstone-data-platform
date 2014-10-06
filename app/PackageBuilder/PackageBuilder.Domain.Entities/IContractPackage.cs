using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public interface IContractPackage : IPackageAccessControl
    {
        IContract Contract { get; set; }
    }
}