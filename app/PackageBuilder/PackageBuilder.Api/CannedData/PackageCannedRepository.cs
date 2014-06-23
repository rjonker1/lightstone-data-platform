using System.Linq;
using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.Api.CannedData
{
    public class PackageCannedRepository : CannedRepository<IPackage>
    {
        public PackageCannedRepository()
        {
            Add(
                new Package("EzScore package") { DataSets = new[] { new DataSetCannedRepository().Entities.First(x => x.Name.Contains("EzScore")) } },
                new Package("License plate lookup package")
                {
                    Action = new ActionCannedRepository().Entities.FirstOrDefault(x => x.Name.ToLower().Contains("license")),
                    DataSets = new[] { new DataSetCannedRepository().Entities.First(x => x.Name.ToLower().Contains("license")) }
                },
                new Package("Vehicle Verification + Repair History + Values package")
                {
                    DataSets = new[]
                    {
                        new DataSetCannedRepository().Entities.First(x => x.Name.Contains("Vehicle verification")),
                        new DataSetCannedRepository().Entities.First(x => x.Name.Contains("Repair history")),
                        new DataSetCannedRepository().Entities.First(x => x.Name.Contains("Values"))
                    }
                }
                );
        }
    }
}