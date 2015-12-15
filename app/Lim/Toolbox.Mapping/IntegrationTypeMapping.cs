using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class IntegrationTypeMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<IntegrationType, IntegrationTypeDto>()
                .ConstructUsing(type => IntegrationTypeDto.Existing(type.Id, type.Type)).ForAllMembers(opt => opt.Ignore()); ;
            Mapper.CreateMap<IntegrationTypeDto, IntegrationType>();
        }
    }
}
