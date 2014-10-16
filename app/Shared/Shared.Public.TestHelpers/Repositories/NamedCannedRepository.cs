using System.Linq;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace Shared.Public.TestHelpers.Repositories
{
    public class NamedCannedRepository<T> : CannedRepository<T>, INamedEntityRepository<T> where T : INamedEntity, IEntity
    {
        public T FindByName(string name)
        {
            return Entities.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        }

        public bool DoesNameExist(string name)
        {
            return Entities.Any(x => x.Name.ToLower() == name.ToLower());
        }
    }
}