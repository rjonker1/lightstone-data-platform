using EasyNetQ;
using Lace.Events.Messages;

namespace Lace.Events
{
    public interface ILaceEvent
    {
        void PublishMessage(IBus bus, DefaultEventMessage message);
    }
}
