using System;
using Lace.Events;
using Lace.Request;
using Lace.Response;
using Lace.Source.Repository.Product.DataAccess;
using Lace.Source.Repository.Product.SqlServer;

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
            _productRepository = new GetDataFromRepository(request.User.UserId, GetProductInformation());
        }

        private static IGetProductInformation GetProductInformation()
        {
            return new GetProductFromSql();
        }

        public void GetProduct(ILaceResponse response, ILaceEvent laceEvent)
        {
            Guid check;
            var validId = Guid.TryParse(_request.User.UserId.ToString(), out check);

            if (!validId)
            {
                response.Product = null;
                return;
            }

            _handleProductRepositoryCall
                .Get(g => g.FetchDataFromRepository(response, _productRepository));
        }
    }
}
