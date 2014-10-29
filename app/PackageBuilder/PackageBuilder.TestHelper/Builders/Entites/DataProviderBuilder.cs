using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.DataProviders.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class DataProviderBuilder
    {
        private Guid _id;
        private string _name;
        private IEnumerable<IDataField> _dataFields;
        public DataProvider Build()
        {
            return new DataProvider(_id, _name, new List<IDataField>());
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

        public DataProviderBuilder With(IEnumerable<IDataField> dataFields)
        {
            _dataFields = dataFields;
            return this;
        }
    }
}