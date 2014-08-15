using DataPlatform.Shared.Entities;
using Lace.Test.Helper.Mothers.Packages.Dto;
using PackageBuilder.TestHelper.Mothers;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberLightstoneSourcePackage
    {
        public static IPackage LicenseNumberPackage()
        {
            return new Package
            {
                Name = "License plate lookup package",
                DataSets =
                    new[]
                    {
                        new DataSet
                        {
                            Name = "License plate lookup DataSet",
                            DataFields = new[]
                            {
                                new DataField
                                {
                                    Name = "AmortisationFactors",
                                    DataSource = new AmortisationFactorsSource()
                                },
                                new DataField {Name = "AreaFactors", DataSource = new AreaFactorsSource()},
                                new DataField
                                {
                                    Name = "AccidentDistribution",
                                    DataSource = new AccidentDistributionSource()
                                },
                                new DataField {Name = "RepairIndexModel", DataSource = new RepairIndexModelSource()},
                                new DataField {Name = "EstimatedValue", DataSource = new EstimatedValueSource()},
                                new DataField {Name = "LastFiveSales", DataSource = new LastFiveSalesSource()},
                                new DataField {Name = "AmortisedValues", DataSource = new AmortisedValuesSource()}
                            }
                        }
                    },
                Action = ActionMother.LicensePlateSearchAction
            };
        }
    }
}
