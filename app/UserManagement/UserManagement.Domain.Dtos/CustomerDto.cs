using System;
using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Dtos
{
    public class CustomerDto : EntityDto
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Name must be atleast 3 characters long")]
        [Display(Name = "Customer name is required")]
        public string Name { get; set; }
        public string CustomerAccountNumber { get; set; }
        [Required]
        [Display(Name = "Account owner is required")]
        public string AccountOwnerName { get; set; }
        [Required]
        [Display(Name = "Commercial state is required")]
        public Guid CommercialStateId { get; set; }
        public string CommercialStateValue { get; set; }
        public string CreateSourceValue { get; set; }
        public Guid PlatformStatusId { get; set; }
        public string PlatformStatusValue { get; set; }
        public Guid BillingId { get; set; }

        public string BillingCompanyRegistration { get; set; }
        public DateTime? BillingDebitOrderDate { get; set; }
        public string BillingPastelId { get; set; }
        public string BillingVatNumber { get; set; }
        [Required]
        [Display(Name = "Legal entity name is required")]
        public string BillingLegalEntityName { get; set; }
        [Required]
        [Display(Name = "Account contact name is required")]
        public string BillingAccountContactName { get; set; }
        [Required]
        [Display(Name = "Payment type is required")]
        public Guid BillingPaymentTypeId { get; set; }

        public string ContactDetailContactNumber { get; set; }
        [Required]
        [Display(Name = "Contact person is required")]
        public string ContactDetailContactPerson { get; set; }  
        public Guid ContactDetailId { get; set; }

        public string ContactDetailEmailAddress { get; set; }
        public string ContactDetailTelephoneNumber { get; set; }
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
        public CreateSourceType CreateSourceType { get; set; }
        public bool? IsActive { get; set; }
    }
}