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
                var field = DataFieldBuilder.Get("Colour");
                field.DataSource = DataSourceMother.RgtVinSource;
                return field;
            }
        }
        public static IDataField LicenseField
        {
            get
            {
                var field = DataFieldBuilder.Get("LicenceNo");
                field.DataSource = DataSourceMother.IvidDataSource;
                return field;
            }
        }
        public static IDataField BankNameField
        {
            get
            {
                var field = DataFieldBuilder.Get("BankName");
                field.DataSource = DataSourceMother.IvidTitleHolderDataSource;
                return field;
            }
        }
        public static IDataField AccidentClaimsField
        {
            get
            {
                var field = DataFieldBuilder.Get("AccidentClaims");
                field.DataSource = DataSourceMother.AudatexSource;
                return field;
            }
        }
    }
}