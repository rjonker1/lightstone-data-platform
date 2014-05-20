using DataPlatform.Shared.Public.Entities;

namespace Lace.Tests.Data.PakageData
{
    public class DataField : IDataField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IDataSource DataSource { get; set; }
    }
}
