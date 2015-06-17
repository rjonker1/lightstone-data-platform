using System.Collections.Generic;
using DataPlatform.Shared.Dtos;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Domain.DataProviders.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Shared.DataProvider.Models;
using Lace.Test.Helper.Fakes.Responses;

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

        public System.Data.DataSet ForLightstoneReturnPropertiesResponse()
        {
            return FakeLightstonePropertyResponse.GetResponseFromReturnProperties();
        }

        public System.Data.DataSet ForLightstoneBusinessCompanyResponse()
        {
            return FakeLightstoneBusinessCompanyResponse.ReturnCompanyReport();
        }

        public System.Data.DataSet ForLightstoneDirectorResponse()
        {
            return FakeLightstoneDirectorResponse.ReturnDirectorReport();
        }
    }
}
