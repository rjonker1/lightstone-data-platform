using System.Linq;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class ContractPackageDatabase : CannedDatabase<IContractPackage>
    {
        public ContractPackageDatabase()
        {
            Add(new ContractPackage { Action = ActionDatabase.Entities.First(x => x.Name.Contains("WesBank")) });
        }
    }
}