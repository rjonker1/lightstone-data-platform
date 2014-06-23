using DataPlatform.Shared.Entities;
using PackageBuilder.Acceptance.Tests.Builders.Entites;

namespace PackageBuilder.Acceptance.Tests.Mothers
{
    public class DataFieldMother
    {
        public static IDataField ColourField
        {
            get
            {
                return DataFieldBuilder.Get("Colour");
            }
        }
    }
}