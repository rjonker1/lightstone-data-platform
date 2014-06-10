using System.Linq;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public interface IContractPackageRepository : IRepository<IContractPackage>
    {
        IQueryable<IContractPackage> GetContractPackages(IContract contract);
        IQueryable<IContractPackage> GetContractPackages(IContract contract, IAction action);
        IQueryable<IAction> GetActions(IContract contract);
        IPackage GetPackage(IContract contract, IAction action);
    }

    public class ContractPackageRepository : Repository<IContractPackage>, IContractPackageRepository
    {
        public ContractPackageRepository()
        {
            Add(new ContractPackage
            {
                Contract = new ContractRepository().Entities.FirstOrDefault(x => x.Name.Contains("WesBank")),
                Action = new ActionRepository().Entities.FirstOrDefault(x => x.Name.ToLower().Contains("license")),
                Package = new PackageDatabase().Entities.FirstOrDefault(x => x.Name.Contains("Vehicle Verification"))
            });
        }

        public IQueryable<IContractPackage> GetContractPackages(IContract contract)
        {
            return Entities.Where(x => Equals(x.Contract, contract) && x.Package != null).AsQueryable();
        }

        public IQueryable<IContractPackage> GetContractPackages(IContract contract, IAction action)
        {
            return GetContractPackages(contract).Where(x => Equals(x.Action, action));
        }

        public IQueryable<IAction> GetActions(IContract contract)
        {
            var actions = GetContractPackages(contract).Select(x => x.Action);
            return actions;
        }

        public IPackage GetPackage(IContract contract, IAction action)
        {
            var contractPackage = GetContractPackages(contract, action).FirstOrDefault();
            return contractPackage != null ? contractPackage.Package : null;
        }
    }
}