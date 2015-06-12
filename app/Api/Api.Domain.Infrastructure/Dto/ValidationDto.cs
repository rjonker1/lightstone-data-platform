using System;
using System.Collections.Generic;

namespace Api.Domain.Infrastructure.Dto
{
    public class ValidationDto
    {
        public Guid Id { get; set; }
        public string CommercialStateValue { get; set; }
        public DateTime? TrialExpiration { get; set; }
        public bool? IsActive { get; set; }
        public bool IsLocked { get; set; }

        public IEnumerable<NamedEntityDto> Clients { get; set; }
        public IEnumerable<NamedEntityDto> Customers { get; set; }
        public IEnumerable<NamedEntityDto> Contracts { get; set; }
        public IEnumerable<KeyValuePair<Guid, string>> Packages { get; set; }
    }
}