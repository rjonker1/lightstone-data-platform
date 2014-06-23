using System.Linq;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;
using PackageBuilder.Domain;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.Api.CannedData
{
    public interface IContractRepository : IRepository<IContract>
    {
        IContract First();
    }

    public class ContractCannedRepository : CannedRepository<IContract>, IContractRepository
    {
        public ContractCannedRepository()
        {
            Add(new Contract("WesBank Contract"));
        }

        public IContract First()
        {
            return Entities != null && Entities.Any() ? Entities.First() : null;
        }
    }
}