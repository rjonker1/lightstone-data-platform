using System;
using Lace.Response;
using Lace.Source.Repository.Product.Sql;

namespace Lace.Source.Repository.Product.DataAccess
{
    public class GetDataFromRepository : IGetProductDataFromRepository
    {
        private readonly Guid _userId;
        private readonly IGetProductInformation _getProduct;

        public GetDataFromRepository(Guid userId)
        {
            _userId = userId;
            _getProduct = new GetProductFromSql();
        }

        public void GetTheProductData(ILaceResponse response)
        {
            response.Product = _getProduct.GetProductDetails(_userId);
        }
    }
}
