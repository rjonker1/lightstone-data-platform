using DataPlatform.Shared.Public.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class DataField : IDataField
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IDataSource DataSource { get; set; }
    }
}
