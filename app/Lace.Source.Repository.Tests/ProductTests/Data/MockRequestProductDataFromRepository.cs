namespace Lace.Source.Repository.Tests.ProductTests.Data
{
    public class MockRequestProductDataFromRepository : IRequestProductDataFromRepository
    {
        public void FetchDataFromRepository(Response.ILaceResponse response, IGetProductDataFromRepository repository)
        {
            repository.GetTheProductData(response);
        }
    }
}
