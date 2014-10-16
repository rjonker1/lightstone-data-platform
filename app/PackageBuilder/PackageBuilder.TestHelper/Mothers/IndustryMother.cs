using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class IndustryMother
    {
        public static Industry BankIndustry
        {
            get
            {
                return new IndustryBuilder().With("BankIndustry").Build();
            }
        }
    }
}