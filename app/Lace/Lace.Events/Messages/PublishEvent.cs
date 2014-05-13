using EasyNetQ;
using Lace.Events.Publishers;

namespace Lace.Events.Messages
{
    public class PublishEvent : ILaceEvent
    {
        private static readonly ILaceEvent LaceEvent = new PublishEvent();

        public static ILaceEvent LacePublishEvent
        {
            get
            {
                return LaceEvent;
            }
        }

        public void PublishMessage(IBus bus, DefaultEventMessage message)
        {
            new PublishLaceEventMessages(bus).PublishMessages.Publish(message);
        }
    }
}
