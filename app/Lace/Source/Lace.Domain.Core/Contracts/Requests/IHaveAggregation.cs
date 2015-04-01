
using System;

namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IHaveAggregation
    {
        Guid AggregateId { get; }
    }
}
