﻿using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
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
            var customerUser = _customerUsers.FirstOrDefault(x => Equals(x.User, user));
            if (customerUser != null) return;
            user.Customer = this;
            customerUser = new CustomerUser(this, user);
            _customerUsers.Add(customerUser);
        }

        public void Add(IContract contract)
        {
            var customerCoontract = _customerContracts.FirstOrDefault(x => Equals(x.Contract, contract));
            if (customerCoontract != null) return;
            customerCoontract = new CustomerContract(this, contract);
            _customerContracts.Add(customerCoontract);
        }
    }
}