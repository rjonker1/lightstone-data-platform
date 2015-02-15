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
            Mapper.CreateMap<ContactDetail, ContactDetailDto>();
            Mapper.CreateMap<ContactDetailDto, ContactDetail>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id == new Guid() ? Guid.NewGuid() : x.Id))
                .ForMember(dest => dest.PhysicalAddress, opt => opt.Ignore())
                .ForMember(dest => dest.PostalAddress, opt => opt.Ignore());
        }
    }
}