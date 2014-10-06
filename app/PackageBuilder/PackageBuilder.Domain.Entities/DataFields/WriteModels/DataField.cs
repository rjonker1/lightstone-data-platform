using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities.DataFields.WriteModels
{
    public class DataField : IDataField
    {
        public string Name { get; private set; }
        public string Value { get; private set; }
        public Type Type { get; private set; }

        public DataField() { }

        public DataField(string name, Type type)
        {
            Name = name;
            Type = type;
            Value = null;
        }

        public IDataProvider DataProvider { get; set; }

        public Guid Id { get; set; }
    }
}