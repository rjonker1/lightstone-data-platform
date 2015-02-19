using System;
using System.Linq;
using Nancy.Security;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.Security
{
    public class UmAuthenticator : IUmAuthenticator
    {
        private readonly IRepository<User> _repository;

        public UmAuthenticator(IRepository<User> repository)
        {
            _repository = repository;
        }

        public IUserIdentity GetUserIdentity(string token)
        {
            var user = _repository.Get(new Guid(token));
            return user == null
                ? null
                : new ApiUser(user.UserName)
                {
                    Id = user.Id,
                    Claims = user.Roles != null ? user.Roles.Select(x => x.Value) : Enumerable.Empty<string>()
                };
        }
    }
}