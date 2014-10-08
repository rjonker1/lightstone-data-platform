﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    public abstract class Aggregate : IAggregate, IEquatable<IAggregate>
    {
        private String _id;

        public String Id
        {
            get { return _id; }
            private set
            {
                if (_id != value)
                {
                    _id = value;
                    OnIdUpdated();
                }
            }
        }

        private void OnIdUpdated()
        {
            if (IsChanged)
            {
                foreach (IDomainEvent @event in _uncommittedEvents)
                {
                    ((DomainEvent) @event).AggregateId = Id;
                }
            }
        }

        public int Version { get; private set; }

        [JsonIgnore]
        public Boolean IsChanged
        {
            get { return _uncommittedEvents.Any(); }
        }

        [JsonIgnore] private readonly List<IDomainEvent> _uncommittedEvents = new List<IDomainEvent>();

        IEnumerable<IDomainEvent> IAggregate.GetUncommittedEvents()
        {
            return _uncommittedEvents.ToArray();
        }

        void IAggregate.ClearUncommittedEvents()
        {
            _uncommittedEvents.Clear();
        }

        protected void RaiseEvent(DomainEvent @event)
        {
            int newVersion = Version + 1;
            @event.AggregateVersion = newVersion;

            _uncommittedEvents.Add(@event);
            Version = newVersion;
        }

        public override Int32 GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override Boolean Equals(object obj)
        {
            return Equals(obj as IAggregate);
        }

        public virtual Boolean Equals(IAggregate other)
        {
            return other != null && other.Id == Id;
        }
    }
}
