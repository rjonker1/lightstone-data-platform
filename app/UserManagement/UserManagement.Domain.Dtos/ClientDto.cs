using System;
using System.Collections.Generic;
using System.Linq;

namespace UserManagement.Domain.Dtos
{
    public class ClientDto
    {
        public ClientDto()
        {
            Contracts = Enumerable.Empty<NamedEntityDto>();
        }

        public Guid Id { get; set; } 
        public string Name { get; set; }
        public ContactDetailDto ContactDetailDto { get; set; }
        public IEnumerable<Guid> ContractIds { get; set; }
        public IEnumerable<NamedEntityDto> Contracts { get; set; }
        public bool IsActive { get; set; }
    }
}