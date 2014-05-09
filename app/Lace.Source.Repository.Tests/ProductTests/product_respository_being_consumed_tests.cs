using Lace.Request;
using Lace.Response;
using Lace.Source.Repository.Tests.ProductTests.Data;
using Xunit.Extensions;

namespace Lace.Source.Repository.Tests.ProductTests
{
    public class product_respository_being_consumed_tests : Specification
    {

        private readonly IHandleProductRepositoryCall _handleProductRepositoryCall;
        private readonly ILaceRequest _request;
        private readonly IGetProductDataFromRepository _productRepository;
        private readonly ILaceResponse _response;

        public product_respository_being_consumed_tests()
        {
            _response = new LaceResponse();
            _handleProductRepositoryCall = new MockHandleProductRepositoryCall();
            _request = new MockLaceRequest();
            _productRepository = new MockGetDataFromRepository(_request.UserId, new MockGettingProductInformation());
        }
        
        public override void Observe()
        {
            _handleProductRepositoryCall.Get(g => g.FetchDataFromRepository(_response, _productRepository));
        }

        [Observation]
        public void product_consumer_get_from_repository_must_be_able_to_handle_test()
        {
            _handleProductRepositoryCall.CanHandle(_request, _response).ShouldBeTrue();
        }

        [Observation]
        public void product_consumer_get_from_repository_product_must_not_be_null_test()
        {
            _response.Product.ShouldNotBeNull();
        }

        [Observation]
        public void product_consumer_get_from_respository_product_must_be_availble_test()
        {
            _response.Product.ProductIsAvailable.ShouldBeTrue();
        }
    }
}
