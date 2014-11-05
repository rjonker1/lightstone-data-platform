using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class PackageBuilder
    {
        private string _name;
        private State _state;
        private IAction _action;
        public Package Build()
        {
            return new Package(Guid.NewGuid(), "Name", "Description", 10d, 20d, _state, 0.1M, "Owner", DateTime.Now, DateTime.Now, null);
        }

        public PackageBuilder With(string name)
        {
            _name = name;
            return this;
        }

        public PackageBuilder With(State state)
        {
            _state = state;
            return this;
        }

        public PackageBuilder With(IAction action)
        {
            _action = action;
            return this;
        }
    }
}