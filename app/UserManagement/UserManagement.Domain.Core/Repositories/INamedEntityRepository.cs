using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Core.Repositories
{
    public interface INamedEntityRepository<T> : IRepository<T> where T : INamedEntity, IEntity
    {
         bool Exists(Guid id, string name);
    }
}