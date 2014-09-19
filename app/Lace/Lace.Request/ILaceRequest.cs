using System;
using DataPlatform.Shared.Entities;

namespace Lace.Request
{
    public interface ILaceRequest
    {
        IProvideUserInformationForRequest User { get; }

        IProvideContextForRequest Context { get; }

        IProvideVehicleInformationForRequest Vehicle { get; }

        IProvideRequestAggregation RequestAggregation { get; }

        IProvideCoOrdinateInformationForRequest CoOrdinates { get; }

        DateTime RequestDate { get; }

        IPackage Package { get; }

    }
}
