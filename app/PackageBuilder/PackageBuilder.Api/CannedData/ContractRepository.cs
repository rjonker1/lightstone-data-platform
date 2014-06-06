using System.Linq;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public interface IContractRepository : IRepository<IContract>
    {
        IContract First();
    }

    public class ContractRepository : Repository<IContract>, IContractRepository
    {
        public ContractRepository()
        {
            Add(new Contract("WesBank Contract"));
        }

        public IContract First()
        {
            return Entities.First();
        }
    }
}