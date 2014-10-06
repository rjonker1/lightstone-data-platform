using Monitoring.Sources.Lace;

namespace Lace.DistributedServices.Events.Contracts
{
    public interface ILaceEvent : ILaceExternalSourceEvent, ILaceSourceHandledEvent, ILaceTransformEvent
    {
       void PublishMessage(string message, LaceEventSource source);

       void PublishLaceReceivedRequestMessage(LaceEventSource source);
       void PublishLaceProcessedRequestAndReturnedResponseMessage(LaceEventSource source);
       void PublishLaceRequestWasNotProcessedAndErrorHasBeenLoggedMessage(LaceEventSource source);

    }
}
