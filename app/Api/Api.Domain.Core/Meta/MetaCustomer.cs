using System;
using System.Collections.Generic;

namespace Api.Domain.Core.Meta
{
    public class MetaCustomer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MetaContractDto> Contracts { get; set; }
    }
}