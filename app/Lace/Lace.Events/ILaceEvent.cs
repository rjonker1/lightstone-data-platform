﻿using System;
using EventTracking;
using EventTracking.Sources;

namespace Lace.Events
{
    public interface ILaceEvent : ILaceExternalSourceEvent, ILaceSourceHandledEvent, ILaceTransformEvent
    {
        void PublishMessage(ITrackExternalSourceEventMessage message);

        void PublishMessage(Guid aggerateId, string message, FromSource source);
    }
}
