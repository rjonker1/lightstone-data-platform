using System;
using System.Collections.Generic;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.TestObjects.Builders
{
    public class DataFieldBuilder
    {
        private string _name;
        private Type _type;
        private IEnumerable<IDataField> _dataFields;

        public IDataField Build()
        {
            return new DataField(_name, null, _dataFields);
        }

        public DataFieldBuilder With(string name)
        {
            _name = name;
            return this;
        }

        public DataFieldBuilder With(Type type)
        {
            _type = type;
            return this;
        }

        public DataFieldBuilder With(params IDataField[] dataFields)
        {
            _dataFields = dataFields;
            return this;
        }
    }
}