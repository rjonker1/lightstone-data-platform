using Lace.Request;

namespace Lace.Source.Tests.Data.IvidTitleHolder
{
    public static class MockIvidTitleHolderLicensePlateNumberRequestData
    {
        public static ILaceRequest GetLicensePlateNumberRequestForIvidTitleHolder()
        {
            return new LicensePlateNumberIvidTitleHolderOnlyRequest();
        }
    }
}
