using System;
using System.Collections.Generic;
using Lim.Domain.Events;
using Lim.Domain.Extensions;

namespace Lim.Domain
{
    public abstract class Aggregate
    {
        private readonly List<LimEvent> _events = new List<LimEvent>();
        public abstract Guid Id { get; }

        public IEnumerable<LimEvent> GetUncommittedEvents()
        {
            return _events;
        }

        public void UpdateCommitedFlag()
        {
            _events.Clear();
        }

        public void LoadsFromHistory(IEnumerable<LimEvent> history)
        {
            foreach (var e in history) ApplyChange(e, false);
        }

        protected void ApplyChange(LimEvent @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(LimEvent @event, bool isNew)
        {
            this.AsDynamic().Apply(@event);
            if (isNew) _events.Add(@event);
        }

        public long Version { get; protected set; }
        //public string EventType { get; protected set; }
        //public int EventTypeId { get; protected set; }
        //public bool AggregateNew { get; protected set; }
        //public Guid CreatedBy { get; protected set; }
        //public Guid CorrelationId { get; protected set; }
        //public string Type { get; protected set; }
        //public byte[] Payload { get; protected set; }
    }
}
