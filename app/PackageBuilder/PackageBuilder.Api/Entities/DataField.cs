using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
{
    public class DataField : NamedEntity, IDataField
    {
        public DataField(string name)
            : base(name)
        {
        }

        public IDataSource DataSource { get; set; }
    }
}