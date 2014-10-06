using Monitoring.Sources.Lace;
namespace Lace.DistributedServices.Events.Contracts
{
    public interface ILaceTransformEvent
    {
        void PublishTransformationStartMessage(LaceEventSource source);

        void PublishTransformationEndMessage(LaceEventSource source);

        void PublishTransformationFailedMessage(LaceEventSource source);
    }
}
