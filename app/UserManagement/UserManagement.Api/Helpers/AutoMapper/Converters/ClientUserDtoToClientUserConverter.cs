using AutoMapper;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Converters
{
    public class ClientUserDtoToClientUserConverter : TypeConverter<ClientUserDto, ClientUser>
    {
        private readonly IRepository<Client> _clients;

        public ClientUserDtoToClientUserConverter(IRepository<Client> clients)
        {
            _clients = clients;
        }

        protected override ClientUser ConvertCore(ClientUserDto source)
        {
            var client = _clients.Get(source.ClientId);
            return new ClientUser(client, null, source.UserAlias);
        }
    }
}