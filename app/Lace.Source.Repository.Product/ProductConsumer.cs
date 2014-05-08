using Lace.Request;
using Lace.Response;
using Lace.Source.Repository.Product.DataAccess;

namespace Lace.Source.Repository.Product
{
    public class ProductConsumer
    {
        private readonly IHandleProductRepositoryCall _handleProductRepositoryCall;
        private readonly ILaceRequest _request;
        private readonly IGetProductDataFromRepository _productRepository;

        public ProductConsumer(ILaceRequest request)
        {
            _request = request;
            _handleProductRepositoryCall = new HandleProductRepositoryCall();
            _productRepository = new GetDataFromRepository(request.UserId);
        }

        public void GetProduct(ILaceResponse response)
        {
            if (!_handleProductRepositoryCall.CanHandle(_request, response)) return;

            _handleProductRepositoryCall
                .Get(g => g.FetchDataFromRepository(response, _productRepository));
        }
    }
}
