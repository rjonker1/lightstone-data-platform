using System.Linq;
using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class ContractDatabase : CannedDatabase<IContract>
    {
        public ContractDatabase()
        {
            Add(new Contract("WesBank Contract") { Customer = CustomerDatabase.Entities.First(x => x.Name.Contains("WesBank")) });
        }
    }
}