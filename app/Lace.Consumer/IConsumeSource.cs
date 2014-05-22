using Lace.Events;
using Lace.Response;

namespace Lace.Consumer
{
    public interface IConsumeService
    {
        void CallService(ILaceResponse response, ILaceEvent laceEvent);
    }
}
