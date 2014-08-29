using System.Linq;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace PackageBuilder.Domain.Contracts.Enitities
{
    public interface IContractPackageRepository : IRepository<IContractPackage>
    {
        IQueryable<IContractPackage> GetContractPackages(IContract contract);
        IQueryable<IContractPackage> GetContractPackages(IContract contract, IAction action);
        IQueryable<IAction> GetActions(IContract contract);
        IPackage GetPackage(IContract contract, IAction action);
    }
}