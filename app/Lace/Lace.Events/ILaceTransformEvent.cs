using System;
using Monitoring.Sources.Lace;

namespace Lace.Events
{
    public interface ILaceTransformEvent
    {
        void PublishTransformationStartMessage(Guid aggerateId, ExternalSource source);

        void PublishTransformationEndMessage(Guid aggerateId, ExternalSource source);

        void PublishTransformationFailedMessage(Guid aggerateId, ExternalSource source);
    }
}
