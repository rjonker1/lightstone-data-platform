using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberIvidTitleHolderRequestPackage
    {
        public static IHavePackageForRequest LicenseNumberPackage(string vinNumber)
        {
            return
                new LicensePlateNumberPackage(
                    new IAmDataProvider[]
                    {
                        new DataProvider(DataProviderName.IvidTitleHolder, 18, 36,
                            IvidTitleHolderRequest.WithVin(vinNumber, "murrayw@lightstone.co.za", "Murray Woolfson"))
                    },
                    Guid.NewGuid());
        }
    }
}
