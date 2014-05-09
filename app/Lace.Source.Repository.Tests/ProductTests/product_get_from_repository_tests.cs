using System;
using Lace.Request;
using Lace.Response;
using Lace.Source.Repository.Tests.ProductTests.Data;
using Xunit.Extensions;

namespace Lace.Source.Repository.Tests.ProductTests
{
    public class product_get_from_repository_tests :Specification
    {

        //private readonly IHandleProductRepositoryCall _handleProductRepositoryCall;
        private readonly ILaceRequest _request;
        private ILaceResponse _response;
        private readonly IGetProductDataFromRepository _productRepository;
        private readonly IRequestProductDataFromRepository _requestDataFromRepository;
       


        public product_get_from_repository_tests()
        {
            _response = new LaceResponse();
            //_handleProductRepositoryCall = new MockHandleProductRepositoryCall();
            _request = new MockLaceRequest();
            _productRepository = new MockGetDataFromRepository(_request.UserId);
            _requestDataFromRepository = new MockRequestProductDataFromRepository();
        }


        public override void Observe()
        {
            _requestDataFromRepository.FetchDataFromRepository(_response, _productRepository);
        }

        [Observation]
        public void product_get_from_repository_response_must_not_be_null_test()
        {
            _response.Product.ShouldNotBeNull();
        }

        [Observation]
        public void product_get_from_respository_response_should_be_availble_test()
        {
            _response.Product.ProductIsAvailable.ShouldBeTrue();
        }
    }
}
