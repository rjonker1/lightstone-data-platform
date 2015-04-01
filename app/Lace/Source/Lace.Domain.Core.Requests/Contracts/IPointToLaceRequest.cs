using System;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IPointToLaceRequest
    {
        DateTime RequestDate { get; }
        IAmPackageForRequest Package { get; }
        IHaveAggregation Aggregation { get; }
    }
}
