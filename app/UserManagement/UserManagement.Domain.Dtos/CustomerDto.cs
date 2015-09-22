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
        [Required, MinLength(3, ErrorMessage = "Name must be atleast 3 characters long"), Display(Name = "Customer name is required")]
        public string Name { get; set; }
        public string CustomerAccountNumber { get; set; }
        [Required, Display(Name = "Account owner is required")]
        public Guid AccountOwnerId { get; set; }
        public string AccountOwnerName { get; set; }
        public string AccountOwnerIndividualSurname { get; set; }
        public Guid accountownerlastname_primary_key { get; set; }
        [Required, Display(Name = "Commercial state is required")]
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
        [Required, Display(Name = "Legal entity name is required")]
        public string BillingLegalEntityName { get; set; }
        [Required, Display(Name = "Account contact name is required")]
        public string BillingAccountContactName { get; set; }
        [Phone(ErrorMessage = "Billing Info Contact Number is not a valid phone number")]
        public string BillingAccountContactNumber { get; set; }
        [EmailAddress]
        public string BillingAccountContactEmail { get; set; }
        [Required, Display(Name = "Payment type is required")]
        public PaymentType BillingPaymentType { get; set; }
        public DateTime? BillingDebitOrderDate { get; set; }
        public string BillingDebitOrderAccountOwner { get; set; }
        public string BillingDebitOrderAccountNumber { get; set; }
        //public ContactNumberType ContactNumberDetailContactNumberType { get; set; }
        public Guid IndividualId { get; set; }
        [Required, Display(Name = "Contact name is required")]
        public string IndividualName { get; set; }
        [Required, Display(Name = "Contact surname is required")]
        public string IndividualSurname { get; set; }
        [Required, Display(Name = "Contact ID number is required")]
        public string IndividualIdNumber { get; set; }
        public Guid IndividualContactNumberId { get; set; }
        [Phone(ErrorMessage = "Contact Info Contact Number is not a valid phone number")]
        public string IndividualContactNumber { get; set; }
        public Guid IndividualEmailId { get; set; }
        [Required, EmailAddress]
        public string IndividualEmail { get; set; }
        public Guid PhysicalAddressId { get; set; }
        public string CustomerPhysicalAddressType { get; set; }
        public string PhysicalAddressLine1 { get; set; }
        public string PhysicalAddressLine2 { get; set; }
        public string PhysicalAddressSuburb { get; set; }
        public string PhysicalAddressCity { get; set; }
        public Guid PhysicalAddressCountryId { get; set; }
        public string PhysicalAddressPostalCode { get; set; }
        public Guid PhysicalAddressProvinceId { get; set; }
        public Guid PostalAddressId { get; set; }
        public string CustomerPostalAddressType { get; set; }
        public string PostalAddressLine1 { get; set; }
        public string PostalAddressLine2 { get; set; }
        public string PostalAddressSuburb { get; set; }
        public string PostalAddressCity { get; set; }
        public Guid PostalAddressCountryId { get; set; }
        public string PostalAddressPostalCode { get; set; }
        public Guid PostalAddressProvinceId { get; set; }
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