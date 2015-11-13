using System;
using DataPlatform.Shared.Entities;

namespace DataPlatform.Shared.Repositories
{
    public interface INamedEntityRepository<T> : IRepository<T> where T : INamedEntity, IEntity
    {
        bool Exists(Guid id, string name);
    }
}