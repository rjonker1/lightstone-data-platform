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
                return DataSetBuilder.Get("EzScore", DataFieldMother.ColourField);
            }
        }

        public static IDataSet RepairHistory
        {
            get
            {
                return DataSetBuilder.Get("Repair history", DataFieldMother.ColourField);
            }
        }

        public static IDataSet VehicleVerification
        {
            get
            {
                return DataSetBuilder.Get("Vehicle verification", DataFieldMother.ColourField);
            }
        }

        public static IDataSet LicenseScan
        {
            get
            {
                return DataSetBuilder.Get("Driver’s license scan", DataFieldMother.ColourField);
            }
        }

        public static IDataSet ValuesHistory
        {
            get
            {
                return DataSetBuilder.Get("Values", DataFieldMother.ColourField);
            }
        }
    }
}