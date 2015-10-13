using System;
using System.Collections.Generic;

namespace Api.Domain.Core.Meta
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Contract> Contracts { get; set; }
    }
}