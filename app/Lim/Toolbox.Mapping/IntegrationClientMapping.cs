using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class IntegrationClientMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<IntegrationClient, IntegrationClientDto>()
                .ConstructUsing(
                    client =>
                        IntegrationClientDto.Existing(client.Id, client.ClientCustomerId, client.AccountNumber,
                            client.Configuration.Id,
                            client.IsActive, client.DateModified, client.ModifiedBy)).ForAllMembers(opt => opt.Ignore());

            Mapper.CreateMap<IntegrationClientDto, IntegrationClient>();
        }
    }
}