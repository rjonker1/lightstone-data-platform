using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
{
    public class DataSource : NamedEntity, IDataSource
    {
        public DataSource(string name)
            : base(name)
        {
        }
    }
}