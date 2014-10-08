using System;
using DataPlatform.Shared.Entities;
using Lace.Test.Helper.Mothers.Packages;
using PackageBuilder.Domain.Entities;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberIvidSourcePackage
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

                                new DataField("Registration") { DataProvider = new DataProvider(new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A"), "Ivid") },
                                new DataField("Vin") { DataProvider = new DataProvider(new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A"), "Ivid") },
                                new DataField("Engine") { DataProvider = new DataProvider(new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A"), "Ivid") },
                                new DataField("MakeDescription") { DataProvider = new DataProvider(new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A"), "Ivid") }

                                //new DataFieldBuilder().With("Registration")
                                //    .With(DataSourceMother.IvidDataSource)
                                //    .Build(),
                                //new DataFieldBuilder().With("Vin").With(DataSourceMother.IvidDataSource).Build(),
                                //new DataFieldBuilder().With("Engine").With(DataSourceMother.IvidDataSource).Build(),
                                //new DataFieldBuilder().With("MakeDescription")
                                //    .With(DataSourceMother.IvidDataSource)
                                //    .Build(),


                            }
                        }
                    },
                Action = ActionMother.LicensePlateSearchAction
            };
        }
    }
}
