
using System;

namespace Lace.Domain.Core.Contracts.Requests
{
    public interface IProvideRequestAggregation
    {
        Guid AggregateId { get; }
    }
}
