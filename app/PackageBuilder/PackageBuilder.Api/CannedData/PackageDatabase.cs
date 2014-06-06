using System.Linq;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class PackageDatabase : Repository<IPackage>
    {
        public PackageDatabase()
        {
            Add(
                new Package("Driver's license scan package") { DataSets = new[] { new DataSetDatabase().Entities.First(x => x.Name.Contains("Driver's license scan")) } },
                new Package("EzScore package") { DataSets = new[] { new DataSetDatabase().Entities.First(x => x.Name.Contains("EzScore")) } },
                new Package("License plate lookup package") { DataSets = new[] { new DataSetDatabase().Entities.First(x => x.Name.Contains("License plate lookup")) } },
                new Package("Vehicle Verification + Repair History + Values package")
                {
                    DataSets = new[]
                    {
                        new DataSetDatabase().Entities.First(x => x.Name.Contains("Vehicle verification")),
                        new DataSetDatabase().Entities.First(x => x.Name.Contains("Repair history")),
                        new DataSetDatabase().Entities.First(x => x.Name.Contains("Values"))
                    }
                }
                );
        }
    }
}