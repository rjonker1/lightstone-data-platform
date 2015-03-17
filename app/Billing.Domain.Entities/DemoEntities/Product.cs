using System;
using Billing.Domain.Core.Entities;

namespace Billing.Domain.Entities.DemoEntities
{
    public class Product : Entity
    {
        public virtual string ProductName { get; set; }

        public Product()
        {
            ProductName = "PROD001";
        }
    }
}