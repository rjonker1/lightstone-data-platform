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
                        Id = s.PhysicalAddressId,
                        Type = s.PhysicalAddressType,
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
                        Type = s.PostalAddressType,
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
                .ForMember(dest => dest.ContactNumberType, opt => opt.MapFrom(x => x.ContactNumberDetailContactNumberType))
                .ForMember(dest => dest.ContactPerson, opt => opt.MapFrom(x => x.IndividualName))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(x => x.IndividualEmail))
                .ForMember(dest => dest.PhysicalAddress, opt => opt.MapFrom(x => Mapper.Map<AddressDto, Address>(x.PhysicalAddressDto)))
                .ForMember(dest => dest.PostalAddress, opt => opt.MapFrom(x => Mapper.Map<AddressDto, Address>(x.PostalAddressDto)));
        }
    }
}