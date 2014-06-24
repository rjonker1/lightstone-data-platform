using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace PackageBuilder.Domain.Contracts
{
    public interface IContractRepository : IRepository<IContract>
    {
        IContract First();
    }
}