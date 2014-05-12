using Lace.Request;

namespace Lace.Source.Tests.Data.RgtVin
{
    public static class MockRgtVinLicensePlateNumberRequestData
    {
        public static ILaceRequest GetLicensePlateNumberReqeustForRgtVinRequest()
        {
            return new LicensePlateNumberRgtVinOnlyRequest();
        }
    }
}
