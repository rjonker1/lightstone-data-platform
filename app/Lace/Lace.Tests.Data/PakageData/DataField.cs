using System;
using DataPlatform.Shared.Entities;

namespace Lace.Tests.Data.PakageData
{
    public class DataField : IDataField
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IDataSource DataSource { get; set; }
    }
}
