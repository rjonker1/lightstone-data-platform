using Lace.Models.Ivid;
using Lace.Request;
using Lace.Response;
using Lace.Source.Ivid.IvidServiceReference;
using Lace.Source.Ivid.Transform;

namespace Lace.Source.Tests.Data.Ivid
{
    public class MockCallingIvidExternalWebService : ICallTheExternalWebService
    {
        private HpiStandardQueryResponse _ividResponse;
        public void CallTheExternalWebService(ILaceResponse response)
        {
            _ividResponse =
                MockIvidHpiStandardQueryResponseData.GetHpiStandardQueryResponseForLicenseNoXmc167Gp();
            TransformWebResponse(response);
        }

        public void TransformWebResponse(ILaceResponse response)
        {
            var transformer = new TransformIvidWebResponse(_ividResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.IvidResponse = transformer.Result;
            response.IvidResponseHandled = new IvidResponseHandled();
            response.IvidResponseHandled.HasBeenHandled();
        }
    }
}
