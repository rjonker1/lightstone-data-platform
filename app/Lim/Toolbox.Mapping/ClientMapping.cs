using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class ClientMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Client, ClientDto>()
                .ConstructUsing(
                    client =>
                        ClientDto.Existing(client.Id, client.IsActive, client.Name, client.Email, client.ContactPerson, client.ContactNumber,
                            client.ModifiedBy, client.DateModified))
                            .ForMember(m => m.Configurations, o => o.MapFrom(s => s.Configurations));

            Mapper.CreateMap<ClientDto, Client>();

        }
    }
}
