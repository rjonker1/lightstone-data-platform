using System;
using System.Linq;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;
using PackageBuilder.Domain;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.Api.CannedData
{
    public interface IContractPackageRepository : IRepository<IContractPackage>
    {
        IQueryable<IContractPackage> GetContractPackages(IContract contract);
        IQueryable<IContractPackage> GetContractPackages(IContract contract, IAction action);
        IQueryable<IAction> GetActions(IContract contract);
        IPackage GetPackage(IContract contract, IAction action);
    }

    public class ContractPackageCannedRepository : CannedRepository<IContractPackage>, IContractPackageRepository
    {
        public ContractPackageCannedRepository()
        {
            Add(new ContractPackage(Guid.NewGuid(),
                new PackageCannedRepository().Entities.FirstOrDefault(x => x.Name.ToLower().Contains("license")), 
                new ContractCannedRepository().Entities.FirstOrDefault(x => x.Name.Contains("WesBank")),
                new DateTime()
                )
            );
        }

        public IQueryable<IContractPackage> GetContractPackages(IContract contract)
        {
            return Entities.Where(x => Equals(x.Contract, contract) && x.Package != null).AsQueryable();
        }

        public IQueryable<IContractPackage> GetContractPackages(IContract contract, IAction action)
        {
            return GetContractPackages(contract).Where(x => Equals(x.Package.Action, action));
        }

        public IQueryable<IAction> GetActions(IContract contract)
        {
            var actions = GetContractPackages(contract).Select(x => x.Package.Action);
            return actions;
        }

        public IPackage GetPackage(IContract contract, IAction action)
        {
            var contractPackage = GetContractPackages(contract, action).FirstOrDefault();
            return contractPackage != null ? contractPackage.Package : null;
        }
    }
}