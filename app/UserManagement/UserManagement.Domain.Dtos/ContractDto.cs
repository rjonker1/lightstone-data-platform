using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enums;

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
        [Required]
        [Display(Name = "Commence date required")]
        public DateTime? CommencementDate { get; set; }
        [Required]
        [Display(Name = "Contract name required")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description required")]
        public string Description { get; set; }
        public string EnteredIntoBy { get; set; }
        public DateTime? OnlineAcceptance { get; set; }
        public string RegisteredName { get; set; }
        public string RegistrationNumber { get; set; }
        [Required]
        [Display(Name = "Contract type required")]
        public Guid? ContractTypeId { get; set; }
        [Required]
        [Display(Name = "Escalation type required")]
        public EscalationType EscalationType { get; set; }
        [Required]
        [Display(Name = "Contract durations required")]
        public ContractDuration ContractDuration { get; set; }
        public IEnumerable<Guid> ClientIds { get; set; } // Used to post Ids on form submit
        public IEnumerable<NamedEntityDto> Clients { get; set; } // Used in populating edit view
        public IEnumerable<Guid> CustomerIds { get; set; } // Used to post Ids on form submit
        public IEnumerable<NamedEntityDto> Customers { get; set; }// Used in populating edit view
        public IEnumerable<string> PackageIdNames { get; set; } // Used to post Ids on form submit
        public IEnumerable<KeyValuePair<Guid, string>> Packages { get; set; } // Used in populating edit view
        public bool HasPackage { get; set; }
        public bool HasPackagePriceOverride { get; set; }
        public Guid ContractBundleId { get; set; }
        public decimal ContractBundlePrice { get; set; }
        public int ContractBundleTransactionLimit { get; set; }
        public IEnumerable<ContractBundle> ContractBundleList { get; set; } 

        public bool IsActive { get; set; }
    }
}