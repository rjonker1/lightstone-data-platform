using PackageBuilder.Domain.Entities.Industries.WriteModels;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class IndustryMother
    {
        public static Industry Automotive
        {
            get
            {
                return new IndustryBuilder().With("Automotive").Build();
            }
        }

        public static Industry Finance
        {
            get
            {
                return new IndustryBuilder().With("Finance").Build();
            }
        }
    }
}