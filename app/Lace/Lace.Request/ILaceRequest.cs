using System;
using DataPlatform.Shared.Entities;

namespace Lace.Request
{
    public interface ILaceRequest
    {
        ILaceRequestUserInformation User { get; }

        ILaceRequestContext Context { get; }

        ILaceRequestVehicleInformation Vehicle { get; }

        IProvideRequestAggregation RequestAggregation { get; }

        DateTime RequestDate { get; }

        IPackage Package { get; }
      
    }
}
