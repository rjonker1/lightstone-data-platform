using Lace.Models.RgtVin;
using Lace.Response;
using Lace.Source.RgtVin.Transform;

namespace Lace.Source.Tests.Data.RgtVin
{
    public class MockCallingRgtVinExternalWebService : ICallTheExternalWebService
    {

        private string _rgtVinResponse;

        public void CallTheExternalWebService(Request.ILaceRequest request, ILaceResponse response)
        {
            _rgtVinResponse = MockRgtVinResponseData.GetRgtVinWebResponseForLicensePlateNumber();
            TransformWebResponse(response);
        }

        public void TransformWebResponse(ILaceResponse response)
        {
            var transformer = new TransformRgtVinWebResponse(_rgtVinResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.RgtVinResponse = transformer.Result;
            response.RgtVinResponseHandled = new RgtVinResponseHandled();
            response.RgtVinResponseHandled.HasBeenHandled();
        }
    }
}
