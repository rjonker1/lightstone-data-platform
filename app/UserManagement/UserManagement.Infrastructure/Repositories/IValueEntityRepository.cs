using System;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Repositories
{
    public interface IValueEntityRepository<T> : IRepository<T> where T : IValueEntity, IEntity
    {
        bool Exists(Guid id, string name);
    }
}