
using Lace.Response;
using Lace.Source.Audatex.AudatexServiceReference;
using Lace.Source.Ivid.IvidServiceReference;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;
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
    }
}
