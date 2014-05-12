using Lace.Response;

namespace Lace.Request.Tests.Data
{
    public class MockLicensePlateNumberSourceChain
    {
        private readonly ILaceResponse _response;

        public MockLicensePlateNumberSourceChain()
        {
            _response = new LaceResponse();
        }

        public MockLicensePlateNumberResponse Build(ILaceRequest request)
        {
            return new MockLicensePlateNumberResponse() {Response = _response};
        }
    }
}
