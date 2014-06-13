using System;
using Monitoring.Sources.Lace;

namespace Lace.Events
{
    public interface ILaceExternalSourceEvent
    {
        void PublishStartServiceConfigurationMessage(Guid aggerateId, LaceEventSource source);

        void PublishEndServiceConfigurationMessage(Guid aggerateId, LaceEventSource source);

        void PublishStartServiceCallMessage(Guid aggerateId, LaceEventSource source);

        void PublishEndServiceCallMessage(Guid aggerateId, LaceEventSource source);

        void PublishFailedServiceCallMessaage(Guid aggerateId, LaceEventSource source);

        void PublishNoResponseFromServiceMessage(Guid aggerateId, LaceEventSource source);

        void PublishServiceRequestMessage(Guid aggerateId, LaceEventSource source, string request);

        void PublishServiceResponseMessage(Guid aggerateId, LaceEventSource source, string response);
    }
}
