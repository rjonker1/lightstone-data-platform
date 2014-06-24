using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class CustomerBuilder
    {
        public static ICustomer Get(string customerName, IUser user, IContract contract)
        {
            var customer = new Customer(customerName);
            customer.Add(user);
            customer.Add(contract);
            return customer;
        }
    }
}