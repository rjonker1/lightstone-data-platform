using System;
using Monitoring.Sources;

namespace Lace.Events
{
    public interface ILaceTransformEvent
    {
        void PublishTransformationStartMessage(Guid aggerateId, FromSource source);

        void PublishTransformationEndMessage(Guid aggerateId, FromSource source);

        void PublishTransformationFailedMessage(Guid aggerateId, FromSource source);
    }
}
