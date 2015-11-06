using System;
using System.Collections.Generic;

namespace Cradle.KeepAlive.Service.Domain.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ContractDto> Contracts { get; set; }
    }
}