using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
{
    public class Customer : NamedEntity, ICustomer
    {
        private readonly IList<ICustomerUser> _customerUsers = new List<ICustomerUser>(); 
        public Customer(string name)
            : base(name)
        {
        }

        public IEnumerable<ICustomerUser> CustomerUsers
        {
            get { return _customerUsers; }
        }

        public IEnumerable<IUser> Users
        {
            get { return _customerUsers.Select(x => x.User); }
        }

        public void Add(IUser user)
        {
            var customerUser = _customerUsers.FirstOrDefault(x => Equals(x.User, user));
            if (customerUser != null) return;
            customerUser = new CustomerUser(this, user);
            _customerUsers.Add(customerUser);
        }
    }

    public class CustomerUser : ICustomerUser
    {
        public int Id { get; set; }
        public ICustomer Customer { get; set; }
        public IUser User { get; set; }

        public CustomerUser(ICustomer customer, IUser user)
        {
            Customer = customer;
            User = user;
        }
    }
}