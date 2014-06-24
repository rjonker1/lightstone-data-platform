using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Contracts
{
    public interface IContractPackage : IPackageAccessControl
    {
        IContract Contract { get; set; }
    }
}