using System;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class StateBuilder
    {
        private string _name;
        public State Build()
        {
            return new State(Guid.NewGuid(), _name);
        }

        public StateBuilder With(Guid id)
        {
            return this;
        }

        public StateBuilder With(string name)
        {
            _name = name;
            return this;
        }
    }
}