using System;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmPropertyRequest : IPointToLaceRequest
    {
        IProvideUserInformationForRequest User { get; }
        IProvidePropertyInformationForRequest Property { get; }
        IProvideRequestAggregation Aggregation { get; }
        IPackage Package { get; }
    }
}
