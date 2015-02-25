using System;
using AutoMapper;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.ContactDetails
{
    public class ContactDetailMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<CustomerDto, ContactDetail>()
                .BeforeMap((s, d) =>
                {
                    s.PhysicalAddressDto = new AddressDto
                    {
                        Id = s.ContactDetailPhysicalAddressId,
                        Type = s.ContactDetailPhysicalAddressType,
                        Line1 = s.ContactDetailPhysicalAddressLine1,
                        Line2 = s.ContactDetailPhysicalAddressLine2,
                        Suburb = s.ContactDetailPhysicalAddressSuburb,
                        City = s.ContactDetailPhysicalAddressCity,
                        Country = s.ContactDetailPhysicalAddressCountry,
                        PostalCode = s.ContactDetailPhysicalAddressPostalCode,
                        ProvinceId = s.ContactDetailPhysicalAddressProvinceId
                    };
                    s.PostalAddressDto = new AddressDto
                    {
                        Id = s.ContactDetailPostalAddressId,
                        Type = s.ContactDetailPostalAddressType,
                        Line1 = s.ContactDetailPostalAddressLine1,
                        Line2 = s.ContactDetailPostalAddressLine2,
                        Suburb = s.ContactDetailPostalAddressSuburb,
                        City = s.ContactDetailPostalAddressCity,
                        Country = s.ContactDetailPostalAddressCountry,
                        PostalCode = s.ContactDetailPostalAddressPostalCode,
                        ProvinceId = s.ContactDetailPostalAddressProvinceId
                    };
                })
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.LegalEntityName, opt => opt.MapFrom(x => x.ContactDetailLegalEntityName))
                .ForMember(dest => dest.AccountsContactName, opt => opt.MapFrom(x => x.ContactDetailAccountsContactName))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(x => x.ContactDetailEmailAddress))
                .ForMember(dest => dest.TelephoneNumber, opt => opt.MapFrom(x => x.ContactDetailTelephoneNumber))
                .ForMember(dest => dest.PhysicalAddress, opt => opt.MapFrom(x => Mapper.Map<AddressDto, Address>(x.PhysicalAddressDto)))
                .ForMember(dest => dest.PostalAddress, opt => opt.MapFrom(x => Mapper.Map<AddressDto, Address>(x.PostalAddressDto)));
        }
    }
}