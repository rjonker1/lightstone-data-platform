﻿using System;
using System.Reflection;
using CommonDomain;
using CommonDomain.Persistence;

namespace EventTracking.Write.Service
{
    public class AggregateFactory : IConstructAggregates
    {
        public IAggregate Build(Type type, Guid id, IMemento snapshot)
        {
            var constructor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null,
                new Type[] {typeof (Guid)}, null);

            return constructor.Invoke(new object[] {id}) as IAggregate;
        }
    }
}
