using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class AuthenticationTypeMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AuthenticationType, AuthenticationTypeDto>()
                .ConstructUsing(type => AuthenticationTypeDto.Existing(type.Id, type.Type)).ForAllMembers(opt => opt.Ignore()); ;
            Mapper.CreateMap<AuthenticationTypeDto, AuthenticationType>();
        }
    }
}
