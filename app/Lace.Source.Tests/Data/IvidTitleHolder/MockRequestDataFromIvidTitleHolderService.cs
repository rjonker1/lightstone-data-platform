namespace Lace.Source.Tests.Data.IvidTitleHolder
{
    public class MockRequestDataFromIvidTitleHolderService : IRequestDataFromService
    {
        public void FetchDataFromService(Request.ILaceRequest request, Response.ILaceResponse response, ICallTheExternalWebService externalWebService)
        {
            externalWebService.CallTheExternalWebService(request, response);
        }
    }
}
