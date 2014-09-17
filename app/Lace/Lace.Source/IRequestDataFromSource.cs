using Lace.Events;
using Lace.Models.Responses;

namespace Lace.Source
{
    public interface IRequestDataFromSource
    {
        void FetchDataFromSource(ILaceResponse response, ICallTheSource externalSource, ILaceEvent laceEvent);
    }
}
