﻿using System;
using Lim.Core;

namespace Lim
{
    public class LimEvent : IMessage
    {
        public long Id { get; set; }
        public int Version { get;  set; }
        public string EventType { get; set; }
        public int EventTypeId { get; set; }
        public bool AggregateNew { get; set; }
        public Guid CorrelationId { get; set; }
        public Type Type { get; set; }
        public string TypeName { get; set; }
       // public byte[] Payload { get; set; }
        public Guid User { get; set; }
    }
}