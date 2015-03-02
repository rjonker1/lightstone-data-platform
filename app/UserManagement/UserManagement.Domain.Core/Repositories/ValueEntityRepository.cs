using System;
using System.Linq;
using NHibernate;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Core.Repositories
{
    public class ValueEntityRepository<T> : Repository<T>, IValueEntityRepository<T> where T : IValueEntity, IEntity
    {
        public ValueEntityRepository(ISession session) : base(session) { }

        public bool Exists(Guid id, string value)
        {
            return this.Any(x => x.Id != id && (x.Value + "").Trim().ToLower().StartsWith((value + "").Trim().ToLower()));
        }
    }
}