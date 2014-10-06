using Monitoring.Sources.Lace;
namespace Lace.DistributedServices.Events.Contracts
{
    public interface ILaceSourceHandledEvent
    {
        void PublishSourceIsBeingHandledMessage(LaceEventSource source);

        void PublishSourceIsNotBeingHandledMessage(LaceEventSource source);
    }
}
