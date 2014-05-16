using EasyNetQ.AutoSubscribe;

namespace EventTracking.Consumers
{
    public class ExternalSourceConsumer : IConsume<ITrackExternalSourceEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }
        public void Consume(ITrackExternalSourceEventMessage message)
        {
            HasBeenConsumed = true;
        }
    }
}
