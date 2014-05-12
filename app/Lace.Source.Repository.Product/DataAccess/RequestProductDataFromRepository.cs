using System;
using Lace.Response;

namespace Lace.Source.Repository.Product.DataAccess
{
    public class RequestProductDataFromRepository : IRequestProductDataFromRepository
    {

        public void FetchDataFromRepository(ILaceResponse response, IGetProductDataFromRepository repository)
        {
            repository.GetTheProductData(response);
        }
    }
}
