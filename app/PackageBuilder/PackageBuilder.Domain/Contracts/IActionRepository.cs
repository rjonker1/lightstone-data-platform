using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace PackageBuilder.Domain.Contracts
{
    public interface IActionRepository : INamedEntityRepository<IAction>
    {
    }
}