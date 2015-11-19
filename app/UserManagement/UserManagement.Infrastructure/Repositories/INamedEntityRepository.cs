using System;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Repositories
{
    //TODO: Refactor repositories into Shared
    public interface INamedEntityRepository<T> : IRepository<T> where T : INamedEntity, IEntity
    {
         bool Exists(Guid id, string name);
    }
}