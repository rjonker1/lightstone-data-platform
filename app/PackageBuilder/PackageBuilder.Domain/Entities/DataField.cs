﻿using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class DataField : NamedEntity, IDataField
    {
        public DataField(string name)
            : base(name)
        {
        }

        public string Type { get; set; }
        public IDataSource DataSource { get; set; }
    }
}