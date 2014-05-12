using Lace.Models.IvidTitleHolder;
using Lace.Request;
using Lace.Response;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;
using Lace.Source.IvidTitleHolder.Transform;


namespace Lace.Source.Tests.Data.IvidTitleHolder
{
    public class MockCallingIvidTitleHolderExternalWebService : ICallTheExternalWebService
    {
        private TitleholderQueryResponse _ividTitleHolderResponse;
        public void CallTheExternalWebService(ILaceResponse response)
        {
            _ividTitleHolderResponse =
                MockIvidTitleHolderQueryResponseData.GetTitleHolderResponseForLicnseNumber();
            TransformWebResponse(response);
        }

        public void TransformWebResponse(ILaceResponse response)
        {
            var transformer = new TransformIvidTitleHolderWebResponse(_ividTitleHolderResponse);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            response.IvidTitleHolderResponse = transformer.Result;
            response.IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled();
            response.IvidTitleHolderResponseHandled.HasBeenHandled();
        }
    }
}
