using System;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class PackageBuilder
    {
        private string _name;
        private IAction _action;
        public Package Build()
        {
            return new Package(Guid.NewGuid(), "Name", "Description", 10d, 20d, "State", "Owner", DateTime.Now, DateTime.Now, null);
        }

        public PackageBuilder With(string name)
        {
            _name = name;
            return this;
        }
        public PackageBuilder With(IAction action)
        {
            _action = action;
            return this;
        }
    }
}