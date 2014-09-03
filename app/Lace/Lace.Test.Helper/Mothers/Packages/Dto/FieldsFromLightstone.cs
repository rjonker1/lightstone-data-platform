using System;
using DataPlatform.Shared.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class AmortisationFactorsSource : IDataProvider
    {
        public AmortisationFactorsSource()
        {
            Id = new Guid("ADBF94E3-695E-4168-9D3F-4E71339B7C4A");
            Name = "Lightstone";
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }

    public class AreaFactorsSource : IDataProvider
    {
        public AreaFactorsSource()
        {
            Id = new Guid("ADBF94E3-695E-4168-9D3F-4E71339B7C4A");
            Name = "Lightstone";
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }

    public class AccidentDistributionSource : IDataProvider
    {
        public AccidentDistributionSource()
        {
            Id = new Guid("ADBF94E3-695E-4168-9D3F-4E71339B7C4A");
            Name = "Lightstone";
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }

    public class RepairIndexModelSource : IDataProvider
    {
        public RepairIndexModelSource()
        {
            Id = new Guid("ADBF94E3-695E-4168-9D3F-4E71339B7C4A");
            Name = "Lightstone";
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }

    public class EstimatedValueSource : IDataProvider
    {
        public EstimatedValueSource()
        {
            Id = new Guid("ADBF94E3-695E-4168-9D3F-4E71339B7C4A");
            Name = "Lightstone";
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }

    public class LastFiveSalesSource : IDataProvider
    {
        public LastFiveSalesSource()
        {
            Id = new Guid("ADBF94E3-695E-4168-9D3F-4E71339B7C4A");
            Name = "Lightstone";
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }

    public class AmortisedValuesSource : IDataProvider
    {
        public AmortisedValuesSource()
        {
            Id = new Guid("ADBF94E3-695E-4168-9D3F-4E71339B7C4A");
            Name = "Lightstone";
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }
}
