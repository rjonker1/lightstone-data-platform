using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class AuditApiIntegrationMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<AuditApiIntegration, AuditApiIntegrationDto>();
            Mapper.CreateMap<AuditApiIntegrationDto, AuditApiIntegration>();
        }
    }
}
