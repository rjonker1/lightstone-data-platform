using System;
using Lace.Models.Product;

namespace Lace.Source.Repository
{
    public interface IGetProductInformation
    {
        ILaceProduct GetProductDetails(Guid userId);
    }
}
