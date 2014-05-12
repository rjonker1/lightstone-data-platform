using System;
using Lace.Models.Product;

namespace Lace.Source.Repository.Tests.ProductTests.Data
{
    internal class MockGettingProductInformation : IGetProductInformation
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
