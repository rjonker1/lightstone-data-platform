using System.Linq;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class PackageDatabase : CannedDatabase<IPackage>
    {
        public PackageDatabase()
        {
            Add(
                new Package("Driver's license scan Package") { DataSets = new[] { DataSetDatabase.Entities.First(x => x.Name.Contains("Driver's license scan")) } },
                new Package("EzScore Package") { DataSets = new[] { DataSetDatabase.Entities.First(x => x.Name.Contains("EzScore")) } },
                new Package("License plate lookup Package") { DataSets = new[] { DataSetDatabase.Entities.First(x => x.Name.Contains("License plate lookup")) } }
                );
        }
    }
}