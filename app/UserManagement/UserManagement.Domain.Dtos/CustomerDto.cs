using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UserManagement.Domain.Dtos
{
    public class CustomerDto
    {
        public CustomerDto()
        {
            CreateSourceIds = Enumerable.Empty<Guid>();
        }

        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Customer name is required")]
        [MinLength(5)]
        public string Name { get; set; }

        public string AccountOwnerName { get; set; }
        public Guid CommercialStateId { get; set; }
        public IEnumerable<Guid> CreateSourceIds { get; set; }
        public Guid PlatformStatusId { get; set; }
        public Guid BillingId { get; set; }
        public string BillingContactNumber { get; set; }
        public string BillingContractPerson { get; set; }
        public string BillingCompanyRegistration { get; set; }
        public DateTime? BillingDebitOrderDate { get; set; }
        public string BillingPastelId { get; set; }
        public string BillingVatNumber { get; set; }
        public Guid BillingPaymentTypeId { get; set; }
        public Guid ContactDetailId { get; set; }
        public string ContactDetailLegalEntityName { get; set; }
        public string ContactDetailAccountsContactName { get; set; }
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
    }
}