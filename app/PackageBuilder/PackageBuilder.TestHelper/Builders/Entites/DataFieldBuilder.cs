using System;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class DataFieldBuilder
    {
        private string _name;
        private Type _type;
        public IDataField Build()
        {
            return new DataField(_name, null);
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
    }
}