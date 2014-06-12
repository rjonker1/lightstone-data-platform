using System;
using Monitoring.Sources.Lace;

namespace Lace.Events
{
    public interface ILaceEvent : ILaceExternalSourceEvent, ILaceSourceHandledEvent, ILaceTransformEvent
    {
       void PublishMessage(Guid aggerateId, string message, ExternalSource source);
    }
}
