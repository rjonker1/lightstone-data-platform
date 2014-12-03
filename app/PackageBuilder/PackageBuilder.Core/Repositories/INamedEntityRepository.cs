using System;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.Core.Repositories
{
    public interface INamedEntityRepository<T> : IRepository<T> where T : INamedEntity, IEntity
    {
        bool Exists(Guid id, string name);
    }
}