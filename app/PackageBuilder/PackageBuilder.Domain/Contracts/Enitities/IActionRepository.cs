using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace PackageBuilder.Domain.Contracts.Enitities
{
    public interface IActionRepository : INamedEntityRepository<IAction>
    {
    }
}