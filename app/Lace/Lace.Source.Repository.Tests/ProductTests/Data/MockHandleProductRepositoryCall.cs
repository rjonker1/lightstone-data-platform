using System;
using Lace.Request;
using Lace.Response;

namespace Lace.Source.Repository.Tests.ProductTests.Data
{
    public class MockHandleProductRepositoryCall : IHandleProductRepositoryCall
    {
        private bool _canHandle;
        public bool CanHandle(ILaceRequest request, ILaceResponse response)
        {
            Guid check;
            _canHandle = Guid.TryParse(request.UserId.ToString(), out check);

            if (!_canHandle)
            {
                NotHandledResponse(response);
            }

            return _canHandle;
        }

        public void Get(Action<IRequestProductDataFromRepository> action)
        {
            action(new MockRequestProductDataFromRepository());
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.Product = null;
        }
    }
}
