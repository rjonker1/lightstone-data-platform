using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UserManagement.Domain.Dtos
{
    public class CustomerDto : EntityDto
    {
        public CustomerDto()
        {
            CreateSourceIds = Enumerable.Empty<Guid>();
        }

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Customer name is required")]
        public string Name { get; set; }
        public string CustomerAccountNumber { get; set; }
        public string AccountOwnerName { get; set; }
        public Guid CommercialStateId { get; set; }
        public string CommercialStateValue { get; set; }
        public IEnumerable<Guid> CreateSourceIds { get; set; }
        public Guid PlatformStatusId { get; set; }
        public string PlatformStatusValue { get; set; }
        public Guid BillingId { get; set; }
        [Required]
        [Display(Name = "Billing contact number is required")]
        public string ContactDetailContactNumber { get; set; }
        public string ContactDetailContactPerson { get; set; }
        public string BillingCompanyRegistration { get; set; }
        public DateTime? BillingDebitOrderDate { get; set; }
        public string BillingPastelId { get; set; }
        public string BillingVatNumber { get; set; }
        public Guid BillingPaymentTypeId { get; set; }
        public Guid ContactDetailId { get; set; }
        [Required]
        public string BillingLegalEntityName { get; set; }
        public string BillingAccountContactName { get; set; }
        public string ContactDetailEmailAddress { get; set; }
        public string ContactDetailTelephoneNumber { get; set; }
        public Guid ContactDetailPhysicalAddressId { get; set; }
        [Required]
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
    }
}