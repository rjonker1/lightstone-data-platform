using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{

    public class LicensePlateNumberAllDataProvidersRequest : IPointToLaceRequest
    {
        private readonly IHaveRequestContext _aggregation;
        private readonly DateTime _requestDate;

        public LicensePlateNumberAllDataProvidersRequest()
        {
            _aggregation = new RequestContextInformation();
            _requestDate = DateTime.Now;
        }

        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }

        public IHaveRequestContext Request
        {
            get { return _aggregation; }
        }

        public DateTime RequestDate
        {
            get { return _requestDate; }
        }

        public IHavePackageForRequest Package
        {
            get { return LicensePlateNumberAllRequestPackage.LicenseNumberOnlyPackage("CN62KZGP", "VVi+Adx"); } //
        }


        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }

    public class LicensePlateNumberMisMatchAllDataProvidersRequest : IPointToLaceRequest
    {
        private readonly IHaveRequestContext _aggregation;
        private readonly DateTime _requestDate;

        public LicensePlateNumberMisMatchAllDataProvidersRequest()
        {
            _aggregation = new RequestContextInformation();
            _requestDate = DateTime.Now;
        }

        public IHaveUser User
        {
            get { return new RequestUserInformation(); }
        }

        public IHaveRequestContext Request
        {
            get { return _aggregation; }
        }

        public DateTime RequestDate
        {
            get { return _requestDate; }
        }

        public IHavePackageForRequest Package
        {
            get { return LicensePlateNumberAllRequestPackage.LicenseNumberOnlyPackage("HLX051GP", "VVi+Adx"); } //
        }


        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }
}
