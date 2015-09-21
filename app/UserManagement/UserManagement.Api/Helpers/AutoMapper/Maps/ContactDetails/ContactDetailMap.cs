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
                        Id = s.PhysicalAddressId,
                        Type = s.CustomerPhysicalAddressType,
                        Line1 = s.PhysicalAddressLine1,
                        Line2 = s.PhysicalAddressLine2,
                        Suburb = s.PhysicalAddressSuburb,
                        City = s.PhysicalAddressCity,
                        CountryId = s.PhysicalAddressCountryId,
                        PostalCode = s.PhysicalAddressPostalCode,
                        ProvinceId = s.PhysicalAddressProvinceId
                    };
                    s.PostalAddressDto = new AddressDto
                    {
                        Id = s.PostalAddressId,
                        Type = s.CustomerPostalAddressType,
                        Line1 = s.PostalAddressLine1,
                        Line2 = s.PostalAddressLine2,
                        Suburb = s.PostalAddressSuburb,
                        City = s.PostalAddressCity,
                        CountryId = s.PostalAddressCountryId,
                        PostalCode = s.PostalAddressPostalCode,
                        ProvinceId = s.PostalAddressProvinceId
                    };
                })
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.IndividualId == new Guid() ? Guid.NewGuid() : x.IndividualId))
                .ForMember(dest => dest.ContactNumber, opt => opt.MapFrom(x => x.IndividualContactNumber))
                //.ForMember(dest => dest.ContactNumberType, opt => opt.MapFrom(x => x.ContactNumberDetailContactNumberType))
                .ForMember(dest => dest.ContactPerson, opt => opt.MapFrom(x => x.IndividualName))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(x => x.IndividualEmail))
                .ForMember(dest => dest.PhysicalAddress, opt => opt.MapFrom(x => Mapper.Map<AddressDto, Address>(x.PhysicalAddressDto)))
                .ForMember(dest => dest.PostalAddress, opt => opt.MapFrom(x => Mapper.Map<AddressDto, Address>(x.PostalAddressDto)));

            Mapper.CreateMap<ClientDto, ContactDetail>()
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
                        CountryId = s.ContactDetailPhysicalAddressCountryId,
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
                        CountryId = s.ContactDetailPostalAddressCountryId,
                        PostalCode = s.ContactDetailPostalAddressPostalCode,
                        ProvinceId = s.ContactDetailPostalAddressProvinceId
                    };
                })
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.ContactDetailId == new Guid() ? Guid.NewGuid() : x.ContactDetailId))
                .ForMember(dest => dest.ContactNumber, opt => opt.MapFrom(x => x.ContactDetailContactNumber))
                .ForMember(dest => dest.ContactNumberType, opt => opt.MapFrom(x => x.ContactNumberDetailContactNumberType))
                .ForMember(dest => dest.ContactPerson, opt => opt.MapFrom(x => x.ContactDetailContactPerson))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(x => x.ContactDetailEmailAddress))
                .ForMember(dest => dest.PhysicalAddress, opt => opt.MapFrom(x => Mapper.Map<AddressDto, Address>(x.PhysicalAddressDto)))
                .ForMember(dest => dest.PostalAddress, opt => opt.MapFrom(x => Mapper.Map<AddressDto, Address>(x.PostalAddressDto)));
        }
    }
}