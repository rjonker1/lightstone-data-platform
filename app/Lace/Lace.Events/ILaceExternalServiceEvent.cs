using System;
using Monitoring.Sources;

namespace Lace.Events
{
    public interface ILaceExternalSourceEvent
    {
        void PublishStartServiceConfigurationMessage(Guid aggerateId, FromSource source);

        void PublishEndServiceConfigurationMessage(Guid aggerateId, FromSource source);

        void PublishStartServiceCallMessage(Guid aggerateId, FromSource source);

        void PublishEndServiceCallMessage(Guid aggerateId, FromSource source);

        void PublishFailedServiceCallMessaage(Guid aggerateId, FromSource source);

        void PublishNoResponseFromServiceMessage(Guid aggerateId, FromSource source);

        void PublishServiceRequestMessage(Guid aggerateId, FromSource source, string request);

        void PublishServiceResponseMessage(Guid aggerateId, FromSource source, string response);
    }
}
