using System;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class DataSourceBuilder
    {
        private Guid _id;
        private string _name;
        public IDataSource Build()
        {
            return new DataSource(_name){Id = _id};
        }

        public DataSourceBuilder With(Guid id)
        {
            _id = id;
            return this;
        }

        public DataSourceBuilder With(string name)
        {
            _name = name;
            return this;
        }
    }
}