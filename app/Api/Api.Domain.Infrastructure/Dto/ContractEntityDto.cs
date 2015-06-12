using System;
using System.Collections.Generic;

namespace Api.Domain.Infrastructure.Dto
{
    public class ContractEntityDto
    {
        public Guid Id { get; set; }
        public IEnumerable<NamedEntityDto> Clients { get; set; }
        public IEnumerable<NamedEntityDto> Customers { get; set; }
        public IEnumerable<KeyValuePair<Guid, string>> Packages { get; set; }
    }
}