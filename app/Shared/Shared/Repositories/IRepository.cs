using System;
using DataPlatform.Shared.Entities;

namespace DataPlatform.Shared.Repositories
{
    public interface IRepository<T>
    {
        T Get(Guid id);
    }

    public interface INamedEntityRepository<T> : IRepository<T> where T : INamedEntity
    {
        T FindByName(string name);
        bool DoesNameExist(string name);
    }
}