﻿using System;
using DataPlatform.Shared.Public.Entities;

namespace Lace.Request
{
    public interface ILaceRequest
    {
        ILaceRequestUserInformation User { get; }

        ILaceRequestContext Context { get; }

        ILaceRequestVehicleInformation Vehicle { get; }

        IProvideRequestAggregation RequestAggregation { get; }

        DateTime RequestDate { get; }

       // string SearchTerm { get; }

        IPackage Package { get; }

        IAction Action { get; }
    }
}
