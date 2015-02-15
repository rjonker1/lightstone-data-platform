using AutoMapper;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Billings
{
    public class BillingMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Billing, BillingDto>();
            Mapper.CreateMap<BillingDto, Billing>();
        }
    }
}