using System;
using DataPlatform.Shared.Public.Entities;

namespace DataPlatform.Shared.Public
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