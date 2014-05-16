using EasyNetQ.AutoSubscribe;

namespace Lace.Events.Consumer.Sources
{
    public class SourcesConsumer : IConsume<ILaceEventMessage>
    {
        public bool HasBeenConsumed { get; private set; }
        public void Consume(ILaceEventMessage message)
        {
            HasBeenConsumed = true;
        }
    }
}
