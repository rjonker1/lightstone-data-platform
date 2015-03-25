using System;

namespace UserManagement.Domain.Dtos
{
    public class ClientDto : EntityDto
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
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