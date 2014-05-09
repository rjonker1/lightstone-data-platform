using System;
using Lace.Response;

namespace Lace.Source.Repository.Tests.ProductTests.Data
{
    public class MockGetDataFromRepository : IGetProductDataFromRepository
    {
        private readonly Guid _userId;
        private readonly IGetProductInformation _getProduct;

        public MockGetDataFromRepository(Guid userId)
        {
            _userId = userId;
            _getProduct = new MockGettingProductInformation();
        }

        public void GetTheProductData(ILaceResponse response)
        {
            response.Product = _getProduct.GetProductDetails(_userId);
        }
    }
}
