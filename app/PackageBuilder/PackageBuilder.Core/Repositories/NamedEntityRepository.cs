using System;
using System.Linq;
using NHibernate;
using PackageBuilder.Core.Entities;

namespace PackageBuilder.Core.Repositories
{
    public class NamedEntityRepository<T> : Repository<T>, INamedEntityRepository<T> where T : INamedEntity, IEntity
    {
        public NamedEntityRepository(ISession session) : base(session) { }

        public bool Exists(Guid id, string name)
        {
            return this.Any(x => x.Id != id && x.Name == name);
        }
    }
}