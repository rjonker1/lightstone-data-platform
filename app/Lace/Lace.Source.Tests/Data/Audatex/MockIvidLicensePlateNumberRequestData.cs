using Lace.Request;

namespace Lace.Source.Tests.Data.Audatex
{
    public static class MockAudatexLicensePlateNumberRequestData
    {
        public static ILaceRequest GetLicensePlateNumberRequestForAudatex()
        {
            return new LicensePlateNumberAudatexOnlyRequest();
        }
    }
}
