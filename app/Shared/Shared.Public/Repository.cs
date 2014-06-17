using System;
using System.Linq;
using DataPlatform.Shared.Public.Entities;

namespace DataPlatform.Shared.Public
{
    public class Repository<T> : IRepository<T> where T : IEntity
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