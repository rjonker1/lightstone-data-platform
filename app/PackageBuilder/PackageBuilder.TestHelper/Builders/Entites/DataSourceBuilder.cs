using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class DataSourceBuilder
    {
        public static IDataSource Get(string name)
        {
            return new DataSource(name);
        }
    }
}