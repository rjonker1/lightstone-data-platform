using System;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.Domain.Contracts.Repositories
{
    public interface IRepository<T> where T : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregate, int expectedVersion);
        T GetById(Guid id);
    }
}