using System;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Enums;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Infrastructure.Repositories
{
    public interface IStateRepository : IRepository<State>
    {
        bool Exists(Guid id, StateName name);
    }
}