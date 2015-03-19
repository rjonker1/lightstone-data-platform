using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;
using PackageBuilder.Domain.Entities.Contracts.Packages.Write;

namespace Lace.Test.Helper.Mothers.Requests
{
    public class LicensePlateNumberIvidOnlyRequest : Domain.Core.Requests.Contracts.ILaceRequest
    {
        public IPackage Package
        {
            get
            {
                return LicensePlateNumberIvidSourcePackage.LicenseNumberPackage();
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

        public IProvideRequestAggregation RequestAggregation
        {
            get
            {
                return new AggregationInformation();
            }
        }

        public IProvideVehicleInformationForRequest Vehicle
        {
            get
            {
                return new RequestVehicleInformation();
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
                return "XMC167GP";
            }
        }

        public IProvideDriversLicenseInformationForRequest DriversLicense
        {
            get { return new RequestDriversLicenseInformation(); }
        }

        public IProvideFicaInformationForRequest Fica
        {
            get { return new RequestFicaInformation(); }
        }

        public IProvidePropertyInformationForRequest Property
        {
            get
            {
                return new RequestPropertyInformation();
            }
        }

        public IProvideBusinessInformationForRequest Business
        {
            get { return new RequestComapanyInformation(); }
        }
    }
}
