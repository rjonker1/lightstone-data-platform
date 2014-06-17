using Lace.Request;
using Lace.Request.Entry;
using Lace.Request.Load;

namespace Lace.Test.Helper.Fakes.Loader
{
    public class FakeRequestedTypesForLicensePlateNumber : IGetRequiredRequestedTypes
    {
        public ILoadRequestSources RequestedTypeToLoad { get; private set; }

        public void GetRequestedType(ILaceRequest request)
        {
            RequestedTypeToLoad = new FakeLaceLicensePlateNumberLoader();
        }
    }
}
