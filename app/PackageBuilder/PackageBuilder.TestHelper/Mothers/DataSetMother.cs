using DataPlatform.Shared.Entities;
using PackageBuilder.TestHelper.Builders.Entites;

namespace PackageBuilder.TestHelper.Mothers
{
    public class DataSetMother
    {
        public static IDataSet EzScore 
        {
            get
            {
                return new DataSetBuilder().With("EzScore").With(DataFieldMother.ColourField).Build();
            }
        }

        public static IDataSet RepairHistory
        {
            get
            {
                return new DataSetBuilder().With("Repair history").With(DataFieldMother.ColourField).Build();
            }
        }

        public static IDataSet VehicleVerification
        {
            get
            {
                return new DataSetBuilder()
                    .With("Vehicle verification")
                    .With(DataFieldMother.ColourField,
                          DataFieldMother.LicenseField, 
                          DataFieldMother.BankNameField, 
                          DataFieldMother.AccidentClaimsField)
                    .Build();
            }
        }

        public static IDataSet LicenseScan
        {
            get
            {
                return new DataSetBuilder().With("Driver’s license scan").With(DataFieldMother.ColourField).Build();
            }
        }

        public static IDataSet ValuesHistory
        {
            get
            {
                return new DataSetBuilder().With("Values").With(DataFieldMother.ColourField).Build();
            }
        }
    }
}