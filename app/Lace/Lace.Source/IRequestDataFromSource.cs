using Lace.Events;
using Lace.Response;

namespace Lace.Source
{
    public interface IRequestDataFromSource
    {
        void FetchDataFromService(ILaceResponse response, ICallTheExternalSource externalWebService, ILaceEvent laceEvent);
    }
}
