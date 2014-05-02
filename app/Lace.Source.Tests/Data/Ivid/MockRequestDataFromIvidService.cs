namespace Lace.Source.Tests.Data.Ivid
{
    public class MockRequestDataFromIvidService : IRequestDataFromService
    {
        public void FetchDataFromService(Response.ILaceResponse response, ICallTheExternalWebService externalWebService)
        {
            externalWebService.CallTheExternalWebService(response);
        }
    }
}
