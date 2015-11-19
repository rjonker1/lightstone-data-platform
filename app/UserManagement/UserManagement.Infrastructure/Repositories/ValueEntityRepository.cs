using System;
using System.Linq;
using NHibernate;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Repositories
{
    public class ValueEntityRepository<T> : Repository<T>, IValueEntityRepository<T> where T : IValueEntity, IEntity
    {
        public ValueEntityRepository(ISession session) : base(session) { }

        public bool Exists(Guid id, string value)
        {
            return this.FirstOrDefault(x => x.Id != id && (x.Value + "").Trim().ToLower() == (value + "").Trim().ToLower()) != null;
        }
    }
}