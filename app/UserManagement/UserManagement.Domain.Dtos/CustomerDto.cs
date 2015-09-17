using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Dtos
{
    public class CustomerDto : NamedEntityDto
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Name must be atleast 3 characters long")]
        [Display(Name = "Customer name is required")]
        public string Name { get; set; }
        public string CustomerAccountNumber { get; set; }
        [Required]
        [Display(Name = "Account owner is required")]
        public Guid AccountOwnerId { get; set; }
        public string AccountOwnerName { get; set; }
        public string AccountOwnerLastName { get; set; }
        public Guid accountownerlastname_primary_key { get; set; }
        [Required]
        [Display(Name = "Commercial state is required")]
        public Guid? CommercialStateId { get; set; }
        public string CommercialStateValue { get; set; }
        public string CreateSourceValue { get; set; }
        public Guid PlatformStatusId { get; set; }
        public string PlatformStatusValue { get; set; }
        public IEnumerable<Guid> Industries { get; set; }
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
        [Phone(ErrorMessage = "Billing Info Contact Number is not a valid phone number")]
        public string BillingAccountContactNumber { get; set; }
        [EmailAddress]
        public string BillingAccountContactEmail { get; set; }
        [Required]
        [Display(Name = "Payment type is required")]
        public PaymentType BillingPaymentType { get; set; }
        public DateTime? BillingDebitOrderDate { get; set; }
        public string BillingDebitOrderAccountOwner { get; set; }
        public string BillingDebitOrderAccountNumber { get; set; }
        [Phone(ErrorMessage = "Contact Info Contact Number is not a valid phone number")]
        public string ContactDetailContactNumber { get; set; }
        public ContactNumberType ContactNumberDetailContactNumberType { get; set; }
        [Required]
        [Display(Name = "Contact person is required")]
        public string ContactDetailContactPerson { get; set; }  
        public Guid ContactDetailId { get; set; }
        [EmailAddress]
        public string ContactDetailEmailAddress { get; set; }
        public Guid ContactDetailPhysicalAddressId { get; set; }
        public string ContactDetailPhysicalAddressType { get; set; }
        public string ContactDetailPhysicalAddressLine1 { get; set; }
        public string ContactDetailPhysicalAddressLine2 { get; set; }
        public string ContactDetailPhysicalAddressSuburb { get; set; }
        public string ContactDetailPhysicalAddressCity { get; set; }
        public Guid ContactDetailPhysicalAddressCountryId { get; set; }
        public string ContactDetailPhysicalAddressPostalCode { get; set; }
        public Guid ContactDetailPhysicalAddressProvinceId { get; set; }
        public Guid ContactDetailPostalAddressId { get; set; }
        public string ContactDetailPostalAddressType { get; set; }
        public string ContactDetailPostalAddressLine1 { get; set; }
        public string ContactDetailPostalAddressLine2 { get; set; }
        public string ContactDetailPostalAddressSuburb { get; set; }
        public string ContactDetailPostalAddressCity { get; set; }
        public Guid ContactDetailPostalAddressCountryId { get; set; }
        public string ContactDetailPostalAddressPostalCode { get; set; }
        public Guid ContactDetailPostalAddressProvinceId { get; set; }
        // Work around for AutoMapper to map address as Nancy does not support nested Model binding when using url encoded form posts
        public AddressDto PhysicalAddressDto { get; set; }
        // Work around for AutoMapper to map address as Nancy does not support nested Model binding when using url encoded form posts
        public AddressDto PostalAddressDto { get; set; }
        public CreateSourceType CreateSource { get; set; }
        public bool? IsActive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? TrialExpiration { get; set; }
        public IEnumerable<Guid> ClientIds { get; set; }
        public IEnumerable<NamedEntityDto> Clients { get; set; }
        public IEnumerable<Guid> ContractIds { get; set; }
        public IEnumerable<NamedEntityDto> Contracts { get; set; }
        public IEnumerable<Guid> UserIds { get; set; }
        public IEnumerable<UserDto> Users { get; set; }

        public CustomerDto()
        {
            Clients = Enumerable.Empty<NamedEntityDto>();
            Contracts = Enumerable.Empty<NamedEntityDto>();
            Users = Enumerable.Empty<UserDto>();
        }
    }
}