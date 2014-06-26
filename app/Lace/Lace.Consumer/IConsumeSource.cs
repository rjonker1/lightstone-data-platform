using Lace.Events;
using Lace.Response;

namespace Lace.Consumer
{
    public interface IConsumeSource
    {
        void ConsumeExternalSource(ILaceResponse response, ILaceEvent laceEvent);
    }
}
