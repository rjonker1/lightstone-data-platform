using Lace.Request.Load;

namespace Lace.Request.Entry
{
    public interface IGetRequiredRequestedTypes
    {
        ILoadRequestSources RequestedTypeToLoad { get; }

        void GetRequestedType(ILaceRequest request);
    }
}
