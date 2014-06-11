using System.Linq;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class PackageRepository : Repository<IPackage>
    {
        public PackageRepository()
        {
            Add(
                new Package("EzScore package") { DataSets = new[] { new DataSetRepository().Entities.First(x => x.Name.Contains("EzScore")) } },
                new Package("License plate lookup package") { DataSets = new[] { new DataSetRepository().Entities.First(x => x.Name.ToLower().Contains("license")) } },
                new Package("Vehicle Verification + Repair History + Values package")
                {
                    DataSets = new[]
                    {
                        new DataSetRepository().Entities.First(x => x.Name.Contains("Vehicle verification")),
                        new DataSetRepository().Entities.First(x => x.Name.Contains("Repair history")),
                        new DataSetRepository().Entities.First(x => x.Name.Contains("Values"))
                    }
                }
                );
        }
    }
}