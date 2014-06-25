using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class DataSource : NamedEntity, IDataSource
    {
        public DataSource(string name)
            : base(name)
        {
        }
    }
}