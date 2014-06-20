using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;

namespace Lace.Tests.Data.PakageData
{
    public class DataSet : IDataSet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<IDataField> DataFields { get; set; }
    }
}
