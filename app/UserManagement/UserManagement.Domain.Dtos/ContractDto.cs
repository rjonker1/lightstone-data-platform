using System;
using System.Collections.Generic;
using System.Linq;

namespace UserManagement.Domain.Dtos
{
    public class ContractDto
    {
        public ContractDto()
        {
            Clients = Enumerable.Empty<NamedEntityDto>();
            Customers = Enumerable.Empty<NamedEntityDto>();
        }

        public Guid Id { get; set; }
        public DateTime CommencementDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnteredIntoBy { get; set; }
        public DateTime? OnlineAcceptance { get; set; }
        public string RegisteredName { get; set; }
        public string RegistrationNumber { get; set; }
        public Guid ContractTypeId { get; set; }
        public Guid EscalationTypeId { get; set; }
        public Guid ContractDurationId { get; set; }
        public IEnumerable<Guid> ClientIds { get; set; }
        public IEnumerable<NamedEntityDto> Clients { get; set; }
        public IEnumerable<Guid> CustomerIds { get; set; }
        public IEnumerable<NamedEntityDto> Customers { get; set; }
    }
}