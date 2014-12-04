using System.Collections.Generic;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Domain.DataProviders.RgtVin.Core.Models;
using Lace.Test.Helper.Fakes.Responses;
using ILaceRequest = Lace.Domain.Core.Requests.Contracts.ILaceRequest;

namespace Lace.Test.Helper.Builders.Responses
{
    public class SourceResponseBuilder
    {
        public IEnumerable<Vin> ForRgtVin()
        {
            return FakeRgtVinResponse.GetRgtVinResponseForLicensePlateNumber();
        }

        public HpiStandardQueryResponse ForIvid()
        {
            return FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoXmc167Gp();
        }

        public HpiStandardQueryResponse ForIvidWithRepairVin()
        {
            return FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoSyb459Gp();
        }

        public HpiStandardQueryResponse ForIvidWithFinancedInterestVin()
        {
            return FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoYxk559Gp();
        }

        public GetDataResult ForAudatexWithHuyandaiHistory()
        {
            return FakeAudatexWebResponseData.GetAudatexWebServiceResultWithHyundaiHistoryResponseInformation();
        }

        public IProvideResponseFromLaceDataProviders ForAudatexWithLaceResponse()
        {
            return FakeAudatexWebResponseData.GetLaceResponseToUserInAudatexRequest();
        }

        public TitleholderQueryResponse ForIvidTitleHolder()
        {
            return FakeIvidTitleHolderQueryResponseData.GetTitleHolderResponseForLicenseNumber();
        }

        public IRetrieveValuationFromMetrics ForLightstoneMetricValuationResponse(IProvideCarInformationForRequest request)
        {

            return FakeLighstoneRetrievalData.GetValuationFromMetrics(request);
        }

        public IRetrieveCarInformation ForLightstoneCarInformationResponse(ILaceRequest request)
        {
            return FakeLighstoneRetrievalData.GetCarInformation(request);
        }
    }
}
