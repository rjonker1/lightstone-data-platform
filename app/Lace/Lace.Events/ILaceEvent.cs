using System;
using Monitoring.Sources.Lace;

namespace Lace.Events
{
    public interface ILaceEvent : ILaceExternalSourceEvent, ILaceSourceHandledEvent, ILaceTransformEvent
    {
       void PublishMessage(Guid aggerateId, string message, LaceEventSource source);

       void PublishLaceReceivedRequestMessage(Guid aggerateId, LaceEventSource source);
       void PublishLaceProcessedRequestAndReturnedResponseMessage(Guid aggerateId, LaceEventSource source);
       void PublishLaceRequestWasNotProcessedAndErrorHasBeenLoggedMessage(Guid aggerateId, LaceEventSource source);

    }
}
