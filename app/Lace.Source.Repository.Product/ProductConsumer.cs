using Lace.Request;
using Lace.Response;
using Lace.Source.Repository.Product.DataAccess;
using Lace.Source.Repository.Product.Sql;

namespace Lace.Source.Repository.Product
{
    public class ProductConsumer
    {
        private readonly IHandleProductRepositoryCall _handleProductRepositoryCall;
        private readonly ILaceRequest _request;
        private readonly IGetProductDataFromRepository _productRepository;
        private readonly IGetProductInformation _getProductSource;

        public ProductConsumer(ILaceRequest request)
        {
            _request = request;
            _handleProductRepositoryCall = new HandleProductRepositoryCall();

            _getProductSource = new GetProductFromSql();
            _productRepository = new GetDataFromRepository(request.UserId, _getProductSource);
        }

        public void GetProduct(ILaceResponse response)
        {
            if (!_handleProductRepositoryCall.CanHandle(_request, response)) return;

            _handleProductRepositoryCall
                .Get(g => g.FetchDataFromRepository(response, _productRepository));
        }
    }
}
