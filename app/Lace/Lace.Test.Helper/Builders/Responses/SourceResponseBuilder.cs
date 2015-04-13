using System.Collections.Generic;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Domain.DataProviders.RgtVin.Core.Models;
using Lace.Test.Helper.Fakes.Responses;
using Microsoft.SqlServer.Server;

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
            return FakeIvidResponse.GetHpiStandardQueryResponseForLicenseNoNrb891W();
        }

        public GetDataResult ForAudatexWithHuyandaiHistory()
        {
            return FakeAudatexWebResponseData.GetAudatexWebServiceResultWithHyundaiHistoryResponseInformation();
        }

        public ICollection<IPointToLaceProvider> ForAudatexWithLaceResponse()
        {
            return FakeAudatexWebResponseData.GetLaceResponseToUserInAudatexRequest();
        }

        public TitleholderQueryResponse ForIvidTitleHolder()
        {
            return FakeIvidTitleHolderQueryResponseData.GetTitleHolderResponseForLicenseNumber();
        }

        public IRetrieveValuationFromMetrics ForLightstoneMetricValuationResponse(IHaveCarInformation request)
        {

            return FakeLighstoneRetrievalData.GetValuationFromMetrics(request);
        }

        public IRetrieveCarInformation ForLightstoneCarInformationResponse(string vinNumber)
        {
            return FakeLighstoneRetrievalData.GetCarInformation(vinNumber);
        }

        public string ForSignioDriversLicenseDecryptedResponse()
        {
            return FakeSignioDecryptedDriversLicenseResponse.GetDecryptedDriversLicenseXmlResponse();
        }

        public string ForLightstoneReturnPropertiesResponse()
        {
            return FakeLightstonePropertyResponse.GetResponseFromReturnProperties();
        }
    }
}
