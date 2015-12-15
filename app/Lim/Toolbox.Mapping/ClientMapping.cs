using System.Collections.Generic;
using System.Linq;
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
                            client.ModifiedBy, client.DateModified).WithConfigurations(Mapper.Map<List<Configuration>, List<ConfigurationDto>>(client.Configurations.ToList())))
                            .ForAllMembers(opt => opt.Ignore());

            Mapper.CreateMap<ClientDto, Client>();
        }
    }
}