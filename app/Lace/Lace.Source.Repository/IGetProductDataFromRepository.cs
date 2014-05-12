using System;
using Lace.Response;
namespace Lace.Source.Repository
{
    public interface IGetProductDataFromRepository
    {
        void GetTheProductData(ILaceResponse response);
    }
}
