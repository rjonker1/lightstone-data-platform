using System;
using System.Linq;
using NHibernate;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.Infrastructure.Repositories
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        public StateRepository(ISession session)
            : base(session)
        {
        }

        public bool Exists(Guid id, StateName name)
        {
            return this.Any(x => x.Id != id && x.Name == name);
        }

        public State GetByName(StateName name)
        {
            var states = this.Where(x => x.Name == name);
            return states.Count() > 1 ? null : states.FirstOrDefault();
        }
    }
}