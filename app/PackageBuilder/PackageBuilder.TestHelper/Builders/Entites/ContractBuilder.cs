using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class ContractBuilder
    {
        public static IContract Get(string name)
        {
            return new Contract(name);
        }
    }
}