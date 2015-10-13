using System;
using System.Collections.Generic;

namespace Api.Domain.Core.Meta
{
    public class MetaConsumer
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<MetaCustomer> Customers { get; set; }
        public IEnumerable<MetaClient> Clients { get; set; }
    }
}