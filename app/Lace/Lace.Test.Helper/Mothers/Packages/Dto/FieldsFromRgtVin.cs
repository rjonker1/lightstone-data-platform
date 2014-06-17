using DataPlatform.Shared.Public.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class VehicleMakeFieldSource : IDataSource
    {
        public VehicleMakeFieldSource()
        {
            Id = 3;
            Name = "Rgt VIN";
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ColourFieldSource : IDataSource
    {
        public ColourFieldSource()
        {
            Id = 3;
            Name = "Rgt VIN";
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class PriceFieldSource : IDataSource
    {
        public PriceFieldSource()
        {
            Id = 3;
            Name = "Rgt VIN";
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
