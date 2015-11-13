using System;
using PackageBuilder.Domain.Entities.Enums.States;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.TestObjects.Builders
{
    public class StateBuilder
    {
        private StateName _name;
        private string _alias;
        public State Build()
        {
            return new State(Guid.NewGuid(), _name, _alias);
        }

        public StateBuilder With(Guid id)
        {
            return this;
        }

        public StateBuilder With(StateName name)
        {
            _name = name;
            return this;
        }

        public StateBuilder With(string alias)
        {
            _alias = alias;
            return this;
        }
    }
}