
using System;

namespace Lace.Request
{
    public interface IProvideRequestAggregation
    {
        Guid AggregateId { get; }
    }
}
