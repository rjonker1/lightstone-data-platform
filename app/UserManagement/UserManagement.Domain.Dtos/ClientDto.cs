using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Dtos
{
    public class ClientDto : EntityDto
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Client name is required")]
        public string Name { get; set; }
        public string ClientAccountNumber { get; set; }
        public IEnumerable<Guid> Industries { get; set; }
        public Guid ContactDetailId { get; set; }
        public string ContactDetailContactNumber { get; set; }
        [Required]
        [Display(Name = "Commercial state is required")]
        public Guid? CommercialStateId { get; set; }
        public string CommercialStateValue { get; set; }
        public Guid BillingId { get; set; }
        public string BillingCompanyRegistration { get; set; }
        public string BillingPastelId { get; set; }
        public string BillingVatNumber { get; set; }
        [Required]
        [Display(Name = "Legal entity name is required")]
        public string BillingLegalEntityName { get; set; }
        [Required]
        [Display(Name = "Account contact name is required")]
        public string BillingAccountContactName { get; set; }
        public string BillingAccountContactNumber { get; set; }
        public string BillingAccountContactEmail { get; set; }
        [Required]
        [Display(Name = "Payment type is required")]
        public Guid? BillingPaymentTypeId { get; set; }
        public DateTime? BillingDebitOrderDate { get; set; }
        public string BillingDebitOrderAccountOwner { get; set; }
        public string BillingDebitOrderAccountNumber { get; set; }

        public ContactType ContactDetailContactType { get; set; }
        [Required]
        [Display(Name = "Contact person is required")]
        public string ContactDetailContactPerson { get; set; }
        public string ContactDetailEmailAddress { get; set; }
        public Guid ContactDetailPhysicalAddressId { get; set; }
        public string ContactDetailPhysicalAddressType { get; set; }
        public string ContactDetailPhysicalAddressLine1 { get; set; }
        public string ContactDetailPhysicalAddressLine2 { get; set; }
        public string ContactDetailPhysicalAddressSuburb { get; set; }
        public string ContactDetailPhysicalAddressCity { get; set; }
        public string ContactDetailPhysicalAddressCountry { get; set; }
        public string ContactDetailPhysicalAddressPostalCode { get; set; }
        public Guid ContactDetailPhysicalAddressProvinceId { get; set; }
        public Guid ContactDetailPostalAddressId { get; set; }
        public string ContactDetailPostalAddressType { get; set; }
        public string ContactDetailPostalAddressLine1 { get; set; }
        public string ContactDetailPostalAddressLine2 { get; set; }
        public string ContactDetailPostalAddressSuburb { get; set; }
        public string ContactDetailPostalAddressCity { get; set; }
        public string ContactDetailPostalAddressCountry { get; set; }
        public string ContactDetailPostalAddressPostalCode { get; set; }
        public Guid ContactDetailPostalAddressProvinceId { get; set; }
        // Work around for AutoMapper to map address as Nancy does not support nested Model binding when using url encoded form posts
        public AddressDto PhysicalAddressDto { get; set; }
        // Work around for AutoMapper to map address as Nancy does not support nested Model binding when using url encoded form posts
        public AddressDto PostalAddressDto { get; set; }
        public bool? IsActive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? TrialExpiration { get; set; }
        public IEnumerable<Guid> CustomerIds { get; set; }
        public IEnumerable<NamedEntityDto> Customers { get; set; }
        public IEnumerable<UserDto> Users { get; set; }
        public IEnumerable<UserAliasDto> UserAliases { get; set; }

        public ClientDto()
        {
            Customers = Enumerable.Empty<NamedEntityDto>();
            UserAliases = Enumerable.Empty<UserAliasDto>(); 
        }
    }
}