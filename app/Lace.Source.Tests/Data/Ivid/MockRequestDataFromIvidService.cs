namespace Lace.Source.Tests.Data.Ivid
{
    public class MockRequestDataFromIvidService : IRequestDataFromService
    {
        public void FetchDataFromService(Request.ILaceRequest request, Response.ILaceResponse response, ICallTheExternalWebService externalWebService)
        {
            externalWebService.CallTheExternalWebService(request, response);
        }
    }
}
