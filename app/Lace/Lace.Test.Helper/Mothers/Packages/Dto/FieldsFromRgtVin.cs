using System;
using DataPlatform.Shared.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class VehicleMakeFieldSource : IDataProvider
    {
        public VehicleMakeFieldSource()
        {
            Id = new Guid("C1C2CFB2-4091-4B27-9086-6AADA536AE8D");
            Name = "Rgt VIN";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }

    public class ColourFieldSource : IDataProvider
    {
        public ColourFieldSource()
        {
            Id = new Guid("C1C2CFB2-4091-4B27-9086-6AADA536AE8D");
            Name = "Rgt VIN";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }

    public class PriceFieldSource : IDataProvider
    {
        public PriceFieldSource()
        {
            Id = new Guid("C1C2CFB2-4091-4B27-9086-6AADA536AE8D");
            Name = "Rgt VIN";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }
}
