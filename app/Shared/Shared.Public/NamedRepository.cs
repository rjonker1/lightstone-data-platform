using System.Linq;
using DataPlatform.Shared.Public.Entities;

namespace DataPlatform.Shared.Public
{
    public class NamedRepository<T> : Repository<T>, INamedEntityRepository<T> where T : INamedEntity
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