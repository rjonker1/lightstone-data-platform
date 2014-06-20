using Lace.Events;
using Lace.Models.Audatex;
using Lace.Request;
using Lace.Response;
using Lace.Source.Audatex.AudatexServiceReference;
using Lace.Source.Audatex.Transform;

namespace Lace.Source.Tests.Data.Audatex
{
    public class MockCallingAudatexExternalWebService : ICallTheSource
    {
        private GetDataResult _audatexResponse;
        private readonly ILaceRequest _request;

        public MockCallingAudatexExternalWebService(ILaceRequest request)
        {
            _request = request;
        }

        public void CallTheExternalWebService(ILaceResponse response, ILaceEvent laceEvent)
        {
            //_audatexResponse = MockAudatexWebResponseData.GetAudatextWebServiceResponse();
            _audatexResponse = MockAudatexWebResponseData.GetAudatexWebServiceResultWithHyundaiHistoryResponseInformation();
            TransformWebResponse(response);
        }

        public void TransformWebResponse(ILaceResponse response)
        {
            var transformer = new TransformAudatexResponse(_audatexResponse, response, _request);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.AudatexResponse = transformer.Result;
            response.AudatexResponseHandled = new AudatexResponseHandled();
            response.AudatexResponseHandled.HasBeenHandled();
        }
    }
}
