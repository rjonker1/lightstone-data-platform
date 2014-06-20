using System;
using DataPlatform.Shared.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class DataField : IDataField
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public IDataSource DataSource { get; set; }
    }
}
