
using Lace.Models.Lightstone;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.AudatexServiceReference;
using Lace.Source.Ivid.IvidServiceReference;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Source.Lightstone.Cars;
using Lace.Source.Lightstone.Metrics;
using Lace.Test.Helper.Fakes.Responses;

namespace Lace.Test.Helper.Builders.Responses
{
    public class SourceResponseBuilder
    {
        public System.Data.DataSet ForRgtVin()
        {
            return FakeRgtVinResponse.GetRgtVinWebResponseForLicensePlateNumber();
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

        public ILaceResponse ForAudatexWithLaceResponse()
        {
            return FakeAudatexWebResponseData.GetLaceResponseToUserInAudatexRequest();
        }

        public TitleholderQueryResponse ForIvidTitleHolder()
        {
            return FakeIvidTitleHolderQueryResponseData.GetTitleHolderResponseForLicenseNumber();
        }

        public IRetrieveValuationFromMetrics ForLightstoneMetricValuationResponse(ILaceRequestCarInformation request)
        {

            return FakeLighstoneRetrievalData.GetValuationFromMetrics(request);
        }

        public IRetrieveCarInformation ForLightstoneCarInformationResponse(ILaceRequest request)
        {
            return FakeLighstoneRetrievalData.GetCarInformation(request);
        }
    }
}
