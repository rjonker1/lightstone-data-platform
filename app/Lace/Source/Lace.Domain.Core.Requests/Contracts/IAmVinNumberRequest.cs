using System;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmVinNumberRequest : IPointToLaceRequest
    {
        IProvideUserInformationForRequest User { get; }
        IProvideVehicleInformationForRequest Vehicle { get; }
        IProvideRequestAggregation Aggregation { get; }
        IPackage Package { get; }
    }
}
