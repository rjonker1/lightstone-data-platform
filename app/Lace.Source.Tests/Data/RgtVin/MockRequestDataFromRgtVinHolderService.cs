namespace Lace.Source.Tests.Data.RgtVin
{
    public class MockRequestDataFromRgtVinHolderService : IRequestDataFromService
    {
        public void FetchDataFromService(Request.ILaceRequest request, Response.ILaceResponse response, ICallTheExternalWebService externalWebService)
        {
            externalWebService.CallTheExternalWebService(request, response);
        }
    }
}
