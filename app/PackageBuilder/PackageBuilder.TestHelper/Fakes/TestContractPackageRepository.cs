using System.Linq;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.TestHelper.Fakes
{
    public class TestContractPackageRepository : CannedRepository<IContractPackage>, IContractPackageRepository
    {
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