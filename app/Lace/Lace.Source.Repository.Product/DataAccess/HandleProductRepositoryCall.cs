using System;
using Lace.Request;
using Lace.Response;

namespace Lace.Source.Repository.Product.DataAccess
{
    public class HandleProductRepositoryCall : IHandleProductRepositoryCall
    {

        private bool _canHandle;

        public bool CanHandle(ILaceRequest request, ILaceResponse response)
        {
            Guid check;
            _canHandle = Guid.TryParse(request.User.UserId.ToString(), out check);

            if (!_canHandle)
            {
                NotHandledResponse(response);
            }

            return _canHandle;
        }

        public void Get(Action<IRequestProductDataFromRepository> action)
        {
            action(new RequestProductDataFromRepository());
        }

        private static void NotHandledResponse(ILaceResponse response)
        {
            response.Product = null;
        }
    }
}
