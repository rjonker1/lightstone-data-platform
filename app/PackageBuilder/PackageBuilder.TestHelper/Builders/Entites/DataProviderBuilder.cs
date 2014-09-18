using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.DataProviders;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class DataProviderBuilder
    {
        private Guid _id;
        private string _name;
        public IDataProvider Build()
        {
            return new DataProvider(_id, _name);
        }

        public DataProviderBuilder With(Guid id)
        {
            _id = id;
            return this;
        }

        public DataProviderBuilder With(string name)
        {
            _name = name;
            return this;
        }
    }
}