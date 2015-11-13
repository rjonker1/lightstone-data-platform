using System;
using System.Linq;
using NHibernate;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Infrastructure.Repositories
{
    public class NamedEntityRepository<T> : Repository<T>, INamedEntityRepository<T> where T : INamedEntity, IEntity
    {
        public NamedEntityRepository(ISession session) : base(session) { }

        public bool Exists(Guid id, string name)
        {
            return this.FirstOrDefault(x => x.Id != id && (x.Name + "").Trim().ToLower() == (name + "").Trim().ToLower()) != null;
        }
    }
}