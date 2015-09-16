using AutoMapper;
using Workflow.Billing.Domain.Dtos;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class StageBillingUserDtoMap : Profile, ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<StageBilling, UserDto>();
            Mapper.CreateMap<UserMeta, UserDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(s => s.LastName));
        }
    }
}