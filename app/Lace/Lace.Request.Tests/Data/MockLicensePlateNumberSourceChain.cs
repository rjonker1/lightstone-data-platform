using Lace.Response;

namespace Lace.Request.Tests.Data
{
    public class MockLicensePlateNumberSourceChain
    {
        private static ILaceResponse _response;

        public static MockLicensePlateNumberResponse Build(ILaceRequest request)
        {

            return new MockLicensePlateNumberResponse() {Response = new LaceResponse() {}};
        }
    }
}
