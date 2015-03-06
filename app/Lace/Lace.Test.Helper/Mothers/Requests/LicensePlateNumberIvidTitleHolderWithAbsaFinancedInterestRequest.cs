using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using ILaceRequest = Lace.Domain.Core.Requests.Contracts.ILaceRequest;

namespace Lace.Test.Helper.Mothers.Requests
{
    public class LicensePlateNumberIvidTitleHolderWithAbsaFinancedInterestRequest : ILaceRequest
    {

        public IProvideDriversLicenseInformationForRequest DriversLicense
        {
            get { return new RequestDriversLicenseInformation(); }
        }

        public IProvideFicaInformationForRequest Fica
        {
            get { return new RequestFicaInformation(); }
        }
        public IPackage Package
        {
            get
            {
                return LicensePlateNumberIvidTitleHolderRequestPackage.LicenseNumberPackage();
            }
        }

        public IProvideUserInformationForRequest User
        {
            get
            {
                return new RequestUserInformation();
            }
        }

        public IProvideContextForRequest Context
        {
            get
            {
                return new ContextInformation();
            }
        }

        public IProvideVehicleInformationForRequest Vehicle
        {
            get
            {
                return new IvidTitleHolderRequestVehicleIWithAbsaFinancedInterestInformation();
            }
        }

        public IProvideRequestAggregation RequestAggregation
        {
            get
            {
                return new AggregationInformation();
            }
        }

        public IProvideCoOrdinateInformationForRequest CoOrdinates
        {
            get { return new CoOrdinateInformation(); }
        }

        public IProvideJisInformation Jis
        {
            get { return new RequestJisInformation(); }
        }

        public DateTime RequestDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        public string SearchTerm
        {
            get
            {
                return "NRB891W";
            }
        }

        public IProvidePropertyInformationForRequest Property
        {
            get
            {
                return new RequesPropertyInformation();
            }
        }
    }
}
