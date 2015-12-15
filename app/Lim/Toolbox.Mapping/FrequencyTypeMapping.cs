using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class FrequencyTypeMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<FrequencyType, FrequencyTypeDto>()
                .ConstructUsing(type => FrequencyTypeDto.Existing(type.Id, type.Type)).ForAllMembers(opt => opt.Ignore()); ;
            Mapper.CreateMap<FrequencyTypeDto, FrequencyType>();
        }
    }
}
