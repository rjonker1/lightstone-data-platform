using System.Linq;
using PackageBuilder.Core.Repositories;
using IPackage = PackageBuilder.Domain.Entities.Packages.WriteModels.IPackage;

namespace PackageBuilder.Domain.Entities
{
    public interface IContractPackageRepository : IRepository<IContractPackage>
    {
        IQueryable<IContractPackage> GetContractPackages(IContract contract);
        IQueryable<IContractPackage> GetContractPackages(IContract contract, IAction action);
        IQueryable<IAction> GetActions(IContract contract);
        IPackage GetPackage(IContract contract, IAction action);
    }
}