using System;
using System.Collections.Generic;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    public interface IAggregate
    {
        String Id { get; }
        int Version { get; }

        Boolean IsChanged { get; }
        IEnumerable<IDomainEvent> GetUncommittedEvents();
        void ClearUncommittedEvents();
    }
}