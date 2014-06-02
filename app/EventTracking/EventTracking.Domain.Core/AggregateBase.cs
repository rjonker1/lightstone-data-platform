using System;
using System.Collections;
using System.Collections.Generic;

namespace EventTracking.Domain.Core
{
    public abstract class AggregateBase : IAggregate, IEquatable<IAggregate>
    {
        public Guid Id { get; protected set; }
        public int Version { get; protected set; }
        private IRouteEvents _registeredRoutes;
        private readonly ICollection<object> _uncommittedEvents = new LinkedList<object>();

        protected IRouteEvents RegisteredRoutes
        {
            get
            {
                return _registeredRoutes ?? (_registeredRoutes = new ConventionEventRouter(true, this));
            }
            set
            {
                if (value == null)
                    throw new InvalidOperationException("AggregateBase must have an event router to function");

                _registeredRoutes = value;
            }
        }

        protected AggregateBase() : this(null)
        {

        }

        protected AggregateBase(IRouteEvents handler)
        {
            if (handler == null) return;

            RegisteredRoutes = handler;
            RegisteredRoutes.Register(this);
        }

        protected void Register<T>(Action<T> route)
        {
            RegisteredRoutes.Register(route);
        }

        protected void RaiseEvent(object @event)
        {
            ((IAggregate) this).ApplyEvent(@event);
            _uncommittedEvents.Add(@event);
        }

        public void ApplyEvent(object @event)
        {
            RegisteredRoutes.Dispatch(@event);
            Version++;
        }

        public ICollection GetUncommittedEvents()
        {
            return (ICollection) _uncommittedEvents;
        }

        public void ClearUncommittedEvents()
        {
            _uncommittedEvents.Clear();
        }

        IMemento IAggregate.GetSnapshot()
        {
            var snapshot = GetSnapshot();
            snapshot.Id = Id;
            snapshot.Version = Version;
            return snapshot;
        }

        protected virtual IMemento GetSnapshot()
        {
            return null;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as IAggregate);
        }

        public virtual bool Equals(IAggregate other)
        {
            return null != other && other.Id == Id;
        }
    }
}
