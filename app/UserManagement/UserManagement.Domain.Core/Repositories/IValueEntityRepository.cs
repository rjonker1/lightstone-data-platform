using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Core.Repositories
{
    public interface IValueEntityRepository<T> : IRepository<T> where T : IValueEntity, IEntity
    {
        bool Exists(Guid id, string name);
    }
}