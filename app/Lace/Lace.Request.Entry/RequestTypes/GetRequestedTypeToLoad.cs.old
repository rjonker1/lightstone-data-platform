using Lace.Request.Load;
using Lace.Request.Load.Loaders;

namespace Lace.Request.Entry.RequestTypes
{
    public class GetRequestedTypeToLoad : IGetRequiredRequestedTypes
    {
        public ILoadRequestSources RequestedTypeToLoad { get; private set; }

        public void GetRequestedType(ILaceRequest request)
        {
            RequestedTypeToLoad = new LicensePlateNumberSourceLoader();
        }
    }
}
