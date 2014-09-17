using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace PackageBuilder.Domain.Entities
{
    public interface IActionRepository : INamedEntityRepository<IAction>
    {
    }
}