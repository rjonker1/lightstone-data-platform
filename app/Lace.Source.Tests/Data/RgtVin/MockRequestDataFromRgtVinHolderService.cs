namespace Lace.Source.Tests.Data.RgtVin
{
    public class MockRequestDataFromRgtVinHolderService : IRequestDataFromService
    {
        public void FetchDataFromService(Response.ILaceResponse response, ICallTheExternalWebService externalWebService)
        {
            externalWebService.CallTheExternalWebService(response);
        }
    }
}
