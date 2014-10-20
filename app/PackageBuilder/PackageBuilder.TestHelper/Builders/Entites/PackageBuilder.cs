using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.TestHelper.Mothers;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class PackageBuilder
    {
        private string _name;
        private IAction _action;
        public IPackage Build()
        {
            return new Package(Guid.NewGuid(), "test", new []{ DataProviderMother.Ivid });
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