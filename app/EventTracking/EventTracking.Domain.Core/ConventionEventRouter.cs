﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EventTracking.Domain.Core
{
    public class ConventionEventRouter : IRouteEvents
    {
        private readonly bool _throwOnApplyNotFound;
        private readonly IDictionary<Type, Action<object>> _handlers = new Dictionary<Type, Action<object>>();
        private IAggregate _registered;

        public ConventionEventRouter() : this(true)
        {
        }

        public ConventionEventRouter(bool throwOnApplyNotFound)
        {
            _throwOnApplyNotFound = throwOnApplyNotFound;
        }

        public ConventionEventRouter(bool throwOnApplyNotFound, IAggregate aggregate) : this(throwOnApplyNotFound)
        {
            Register(aggregate);
        }

        public virtual void Register<T>(Action<T> handler)
        {
            if (handler == null)
                throw new ArgumentNullException("handler");

            Register(typeof (T), @event => handler((T) @event));
        }

        public virtual void Register(IAggregate aggregate)
        {
            if (aggregate == null)
                throw new ArgumentNullException("aggregate");

            this._registered = aggregate;

            // Get instance methods named Apply with one parameter returning void
            var applyMethods = aggregate.GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(
                    m =>
                        m.Name == "Apply" && m.GetParameters().Length == 1 &&
                        m.ReturnParameter.ParameterType == typeof (void))
                .Select(m => new
                {
                    Method = m,
                    MessageType = m.GetParameters().Single().ParameterType
                });

            foreach (var apply in applyMethods)
            {
                var applyMethod = apply.Method;
                _handlers.Add(apply.MessageType, m => applyMethod.Invoke(aggregate, new[] {m as object}));
            }
        }

        public virtual void Dispatch(object eventMessage)
        {
            if (eventMessage == null)
                throw new ArgumentNullException("eventMessage");

            Action<object> handler;
            if (_handlers.TryGetValue(eventMessage.GetType(), out handler))
                handler(eventMessage);
            else if (_throwOnApplyNotFound)
                _registered.ThrowHandlerNotFound(eventMessage);
        }

        private void Register(Type messageType, Action<object> handler)
        {
            _handlers[messageType] = handler;
        }
    }

}