using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace PackageBuilder.Domain.Contracts.Enitities
{
    public interface IContractRepository : IRepository<IContract>
    {
        IContract First();
    }
}