using System;

namespace Lace.Source.Repository.Product.DataAccess
{
    public class HandleProductRepositoryCall : IHandleProductRepositoryCall
    {
        public void Get(Action<IRequestProductDataFromRepository> action)
        {
            action(new RequestProductDataFromRepository());
        }
    }
}
