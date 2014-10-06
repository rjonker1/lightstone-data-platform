using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace PackageBuilder.Domain.Entities
{
    public interface IContractRepository : IRepository<IContract>
    {
        IContract First();
    }
}