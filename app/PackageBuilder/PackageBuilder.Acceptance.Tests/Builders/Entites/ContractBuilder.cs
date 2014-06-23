using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;

namespace PackageBuilder.Acceptance.Tests.Builders.Entites
{
    public class ContractBuilder
    {
        public static IContract Get(string name)
        {
            return new Contract(name);
        }
    }
}