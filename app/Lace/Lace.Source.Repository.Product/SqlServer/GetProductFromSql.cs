using System;
using Lace.Models.Product;

namespace Lace.Source.Repository.Product.SqlServer
{
    public class GetProductFromSql : IGetProductInformation
    {
        public ILaceProduct GetProductDetails(Guid userId)
        {
            return new LaceProduct()
            {
                ContractId = 4406,
                CustomerId = 18973,
                ProductIsAvailable = true,
                ProductName = "VVi+ADX+VPi,VVi+VPi,VPi,VLi+"
            };
        }

    }
}
