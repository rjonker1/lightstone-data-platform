namespace Lace.Source.Tests.Data.IvidTitleHolder
{
    public class MockRequestDataFromIvidTitleHolderService : IRequestDataFromService
    {
        public void FetchDataFromService(Response.ILaceResponse response, ICallTheExternalWebService externalWebService)
        {
            externalWebService.CallTheExternalWebService(response);
        }
    }
}
