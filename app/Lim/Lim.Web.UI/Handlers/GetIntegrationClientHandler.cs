using System.Collections.Generic;
using System.Linq;
using Lim.Core;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Dtos;
using Lim.Entities;

namespace Lim.Web.UI.Handlers
{
    public class GetIntegrationClientHandler : IHandleGettingIntegrationClient
    {
        private readonly IRepository _repository;

        public GetIntegrationClientHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetIntegrationClients command)
        {
            var items = _repository.GetAll<Lim.Entities.Client>();
            var dto = AutoMapper.Mapper.Map<List<Lim.Entities.Client>, List<ClientDto>>(items.ToList());
            command.Set(dto.Any() ? dto : Enumerable.Empty<ClientDto>());

        }

        public void Handle(GetIntegrationClient command)
        {
            var item = _repository.Get<Client>(w => w.Id == command.Id);
            var dto = AutoMapper.Mapper.Map<Client, ClientDto>(item.FirstOrDefault());
            command.Set(dto);

        }
    }
}
