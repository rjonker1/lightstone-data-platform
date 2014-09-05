using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class DataField : NamedEntity, IDataField
    {
        public DataField(string name)
            : base(name)
        {
        }

        public Type Type { get; private set; }
        public IDataProvider DataProvider { get; set; }
    }
}