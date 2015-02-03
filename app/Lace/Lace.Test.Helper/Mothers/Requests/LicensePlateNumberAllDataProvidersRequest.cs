using System;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Lace.Test.Helper.Mothers.Requests
{

    public class LicensePlateNumberAllDataProvidersRequest : Domain.Core.Requests.Contracts.ILaceRequest
    {
        private readonly IProvideRequestAggregation _aggregation;
        private readonly DateTime _requestDate;

        public LicensePlateNumberAllDataProvidersRequest()
        {
            _aggregation = new AggregationInformation();
            _requestDate = DateTime.Now;
        }


        public IPackage Package
        {
            get
            {
                return LicensePlateNumberAllRequestPackage.LicenseNumberPackage();
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
            get { return _aggregation; }
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
            get { return _requestDate; }
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
            get { throw new NotImplementedException(); }
        }

        public IProvideFicaInformationForRequest Fica
        {
            get { throw new NotImplementedException(); }
        }
    }
}
