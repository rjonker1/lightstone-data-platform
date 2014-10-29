using DataPlatform.Shared.Entities;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class ContractMother
    {
        public static IContract WesbankContract
        {
            get
            {
                return new ContractBuilder().With("Wesbank contract").Build();
            }
        } 
    }
}