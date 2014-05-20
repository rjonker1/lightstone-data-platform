using DataPlatform.Shared.Public;
using DataPlatform.Shared.Public.Entities;
using PackageBuilder.Api.Entities;

namespace PackageBuilder.Api.CannedData
{
    public class CustomerDatabase : CannedDatabase<ICustomer>
    {
        public CustomerDatabase()
        {
            Add(new Customer("WesBank"));
        }
    }
}