using System;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Mothers.Requests
{
    public class LicensePlateRgtVinMmCodeProvidersRequest : IPointToLaceRequest
    {
        private readonly IHaveRequestContext _aggregation;
        private readonly DateTime _requestDate;

        public LicensePlateRgtVinMmCodeProvidersRequest()
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
            get { return LicensePlateNumberAllRequestPackage.LicensePlateIvidRgtVinAndMmCodePackage("XMC167GP", "IVID-RGTVIN-MMCODE"); }
        }

        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }

    public class VinNumberLSAutoRgtAndRgtVinProvidersRequest : IPointToLaceRequest
    {
        private readonly IHaveRequestContext _aggregation;
        private readonly DateTime _requestDate;

        public VinNumberLSAutoRgtAndRgtVinProvidersRequest()
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
            get { return VinNumberRequestPackage.LsAutoRgtAndRgitVinPackage("3C4PDCKG7DT526617"); }
        }
        
        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }

    public class VinNumbeRgtAndRgtVinProvidersRequest : IPointToLaceRequest
    {
        private readonly IHaveRequestContext _aggregation;
        private readonly DateTime _requestDate;

        public VinNumbeRgtAndRgtVinProvidersRequest()
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
            get { return VinNumberRequestPackage.RgtAndRgtVinPackage("3C4PDCKG7DT526617"); }
        }

        public IHaveContract Contract
        {
            get { return new RequestContractInformation(); }
        }
    }
}
