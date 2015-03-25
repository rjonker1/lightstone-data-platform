using System;
using System.Collections.Generic;
using System.Linq;

namespace UserManagement.Domain.Dtos
{
    public class ContractDto : EntityDto
    {
        public ContractDto()
        {
            Clients = Enumerable.Empty<NamedEntityDto>();
            Customers = Enumerable.Empty<NamedEntityDto>();
            Packages = Enumerable.Empty<KeyValuePair<Guid, string>>();
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
        public IEnumerable<Guid> ClientIds { get; set; } // Used to post Ids on form submit
        public IEnumerable<NamedEntityDto> Clients { get; set; } // Used in populating edit view
        public IEnumerable<Guid> CustomerIds { get; set; } // Used to post Ids on form submit
        public IEnumerable<NamedEntityDto> Customers { get; set; }// Used in populating edit view
        public IEnumerable<string> PackageIdNames { get; set; } // Used to post Ids on form submit
        public IEnumerable<KeyValuePair<Guid, string>> Packages { get; set; } // Used in populating edit view

        public bool IsActive { get; set; }
    }
}