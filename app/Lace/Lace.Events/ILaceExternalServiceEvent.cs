using System;
using Monitoring.Sources.Lace;

namespace Lace.Events
{
    public interface ILaceExternalSourceEvent
    {
        void PublishStartServiceConfigurationMessage(LaceEventSource source);

        void PublishEndServiceConfigurationMessage(LaceEventSource source);

        void PublishStartServiceCallMessage(LaceEventSource source);

        void PublishEndServiceCallMessage(LaceEventSource source);

        void PublishFailedServiceCallMessaage(LaceEventSource source);

        void PublishNoResponseFromServiceMessage(LaceEventSource source);

        void PublishServiceRequestMessage(LaceEventSource source, string request);

        void PublishServiceResponseMessage(LaceEventSource source, string response);
    }
}
