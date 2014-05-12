using Lace.Request.Entry;
using Lace.Request.Load;

namespace Lace.Request.Tests.Data
{
    public class MockGetRequestedTypeToLoad : IGetRequiredRequestedTypes
    {
        public ILoadRequestSources RequestedTypeToLoad { get; private set; }

        public void GetRequestedType(ILaceRequest request)
        {
            RequestedTypeToLoad = new MockLaceLicensePlateNumberLoader();
        }
    }
}
