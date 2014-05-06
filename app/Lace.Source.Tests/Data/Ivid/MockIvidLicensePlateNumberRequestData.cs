using Lace.Request;

namespace Lace.Source.Tests.Data.Ivid
{
    public static class MockIvidLicensePlateNumberRequestData
    {
        public static ILaceRequest GetLicensePlateNumberRequestForIvid()
        {
            return new LicensePlateNumberIvidOnlyRequest();
        }
    }
}
