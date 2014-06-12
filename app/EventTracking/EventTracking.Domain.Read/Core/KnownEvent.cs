﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventStore.ClientAPI;

namespace EventTracking.Domain.Read.Core
{
    public class KnownEvent
    {
        public ConsoleColor Color { get; private set; }

        public KnownEvent(ConsoleColor color)
        {
            Color = color;
        }

        public virtual object Parse()
        {
            return null;
        }
    }

    public class KnownEvent<TEvent> : KnownEvent
    {
        private readonly RecordedEvent _recordedEvent;

        public KnownEvent(ConsoleColor color, RecordedEvent recordedEvent)
            : base(color)
        {
            if (recordedEvent == null) throw new ArgumentNullException("recordedEvent");

            _recordedEvent = recordedEvent;
        }

        public override object Parse()
        {
            return _recordedEvent.ParseJson<TEvent>().AsJsonString();
        }
    }
}
