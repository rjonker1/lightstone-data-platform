using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class Customer : NamedEntity, ICustomer
    {
        private readonly IList<ICustomerUser> _customerUsers = new List<ICustomerUser>();
        private readonly IList<ICustomerContract> _customerContracts = new List<ICustomerContract>(); 
        public Customer(string name)
            : base(name)
        {
        }

        public IEnumerable<ICustomerUser> CustomerUsers
        {
            get { return _customerUsers; }
        }

        public IEnumerable<ICustomerContract> CustomerContracts
        {
            get { return _customerContracts; }
        }

        public IEnumerable<IUser> Users
        {
            get { return _customerUsers.Select(x => x.User); }
        }

        public IEnumerable<IContract> Contracts
        {
            get { return _customerContracts.Select(x => x.Contract); }
        }

        public void Add(IUser user)
        {
            if (user == null) return;

            var customerUser = _customerUsers.FirstOrDefault(x => Equals(x.User, user));
            if (customerUser != null) return;

            //user.Customer = this;
            customerUser = new CustomerUser(this, user);
            _customerUsers.Add(customerUser);
        }

        public void Add(IContract contract)
        {
            if (contract == null) return;

            var customerContract = _customerContracts.FirstOrDefault(x => Equals(x.Contract, contract));
            if (customerContract != null) return;

            //contract.Customer = this;
            customerContract = new CustomerContract(this, contract);
            _customerContracts.Add(customerContract);
        }
    }
}