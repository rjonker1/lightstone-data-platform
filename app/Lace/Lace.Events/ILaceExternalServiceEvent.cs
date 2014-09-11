using Monitoring.Sources.Lace;

namespace Lace.Events
{
    public interface ILaceExternalSourceEvent
    {
        void PublishStartSourceConfigurationMessage(LaceEventSource source);

        void PublishEndSourceConfigurationMessage(LaceEventSource source);

        void PublishStartSourceCallMessage(LaceEventSource source);

        void PublishEndSourceCallMessage(LaceEventSource source);

        void PublishFailedSourceCallMessage(LaceEventSource source);

        void PublishNoResponseFromSourceMessage(LaceEventSource source);

        void PublishSourceRequestMessage(LaceEventSource source, string request);

        void PublishSourceResponseMessage(LaceEventSource source, string response);
    }
}
