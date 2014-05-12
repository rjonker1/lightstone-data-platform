using System;
using Lace.Response;

namespace Lace.Source.Repository.Product.DataAccess
{
    public class GetDataFromRepository : IGetProductDataFromRepository
    {
        private readonly Guid _userId;
        private readonly IGetProductInformation _getProductSource;

        public GetDataFromRepository(Guid userId, IGetProductInformation getProuctSource)
        {
            _userId = userId;
            _getProductSource = getProuctSource;
        }

        public void GetTheProductData(ILaceResponse response)
        {
            response.Product = _getProductSource.GetProductDetails(_userId);
        }
    }
}
