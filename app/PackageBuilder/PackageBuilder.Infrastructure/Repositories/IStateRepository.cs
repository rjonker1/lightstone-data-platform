using System;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Infrastructure.Repositories
{
    public interface IStateRepository : IRepository<State>
    {
        bool Exists(Guid id, StateName name);
        State GetByName(StateName name);
    }
}