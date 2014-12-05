using System;
using System.Linq;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.TestObjects.Builders
{
    public class DataFieldBuilder
    {
        private string _name;
        private Type _type;
        public IDataField Build()
        {
            return new DataField(_name, null, Enumerable.Empty<Industry>());
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