using DataPlatform.Shared.Entities;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
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
        public static IDataField LicenseField
        {
            get
            {
                return DataFieldBuilder.Get("LicenceNo");
            }
        }
    }
}