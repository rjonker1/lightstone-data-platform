using System;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.RequestTypes;
using Lace.Test.Helper.Mothers.Packages;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LicensePlateNumberRgtRequestPackage
    {
        public static IHavePackageForRequest LicenseNumberPackage(int carId)
        {
            return
                new LicensePlateNumberPackage(
                    new IAmDataProvider[]
                    {new DataProvider(DataProviderName.Rgt, 17, 33, RgtRequestType.WithCarId(carId.ToString()))},
                    Guid.NewGuid());
        }
    }
}
