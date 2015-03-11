using System;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface ILaceRequest
    {
        IProvideUserInformationForRequest User { get; }

        IProvideContextForRequest Context { get; }

        IProvideVehicleInformationForRequest Vehicle { get; }

        IProvideRequestAggregation RequestAggregation { get; }

        IProvideCoOrdinateInformationForRequest CoOrdinates { get; }

        IProvideJisInformation Jis { get; }

        IProvideDriversLicenseInformationForRequest DriversLicense { get; }

        IProvideFicaInformationForRequest Fica { get; }

        DateTime RequestDate { get; }
        IPackage Package { get; }

        IProvidePropertyInformationForRequest Property { get; }
    }
}
