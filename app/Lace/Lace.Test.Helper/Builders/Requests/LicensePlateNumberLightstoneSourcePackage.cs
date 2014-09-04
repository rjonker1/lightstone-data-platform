using DataPlatform.Shared.Entities;
using Lace.Test.Helper.Mothers.Packages.Dto;
using PackageBuilder.Domain.Entities;
using PackageBuilder.TestHelper.Mothers;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberLightstoneSourcePackage
    {
        public static IPackage LicenseNumberPackage()
        {
            return new Package("License plate lookup package")
            {
                DataSets =
                    new[]
                    {
                        new DataSet("License plate lookup DataSet")
                        {
                            DataFields = new[]
                            {
                                new DataField("AmortisationFactors")
                                {
                                    DataSource = new AmortisationFactorsSource()
                                },
                                new DataField("AreaFactors") {DataSource = new AreaFactorsSource()},
                                new DataField("AccidentDistribution")
                                {
                                    DataSource = new AccidentDistributionSource()
                                },
                                new DataField("RepairIndexModel") {DataSource = new RepairIndexModelSource()},
                                new DataField("EstimatedValue") {DataSource = new EstimatedValueSource()},
                                new DataField("LastFiveSales") {DataSource = new LastFiveSalesSource()},
                                new DataField("AmortisedValues") {DataSource = new AmortisedValuesSource()}
                            }
                        }
                    },
                Action = ActionMother.LicensePlateSearchAction
            };
        }
    }
}
