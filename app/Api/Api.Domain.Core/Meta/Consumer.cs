using System;
using System.Collections.Generic;

namespace Api.Domain.Core.Meta
{
    public class Consumer
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}