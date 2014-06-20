using System;
using System.Linq;
using DataPlatform.Shared.Entities;
using DataPlatform.Shared.Repositories;

namespace Shared.Public.TestHelpers.Repositories
{
    public class CannedRepository<T> : IRepository<T> where T : IEntity
    {
        public T[] Entities;

        protected void Add(params T[] entities)
        {
            Entities = entities;
        }

        public T Get(Guid id)
        {
            return Entities.FirstOrDefault(x => x.Id == id);
        }
    }
}