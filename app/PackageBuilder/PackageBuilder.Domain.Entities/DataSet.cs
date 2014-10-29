﻿using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class DataSet : NamedEntity, IDataSet
    {
        public DataSet(string name)
            : base(name)
        {
        }

        public IEnumerable<IDataField> DataFields { get; set; }
    }
}