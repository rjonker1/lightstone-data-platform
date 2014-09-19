using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.DataFields.WriteModels
{
    public class DataField : IDataField
    {
        public string Name { get; private set; }
        public Type Type { get; private set; }

        public DataField(string name, Type type)
        {
            Name = name;
            Type = type;
        }
    }
}