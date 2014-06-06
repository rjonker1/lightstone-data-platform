using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using Action = PackageBuilder.Api.Entities.Action;

namespace PackageBuilder.Api.CannedData
{
    public interface IActionRepository : INamedEntityRepository<IAction>
    {
    }

    public class ActionRepository : NamedRepository<IAction>, IActionRepository
    {
        public ActionRepository()
        {
            Add(
                new Action("Get EzScore"),
                new Action("Verify")
                );
        }
    }
}