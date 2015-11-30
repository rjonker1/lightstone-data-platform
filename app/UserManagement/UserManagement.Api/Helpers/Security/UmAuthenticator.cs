using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy.Security;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;
using Shared.Logging;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Helpers.Security
{
    public interface IUmAuthenticator : IAuthenticateUser
    {
        IUserIdentity GetUserIdentity(string username, string password);
    }

    public class UmAuthenticator : IUmAuthenticator
    {
        private readonly IUserRepository _repository;

        public UmAuthenticator(IUserRepository repository)
        {
            _repository = repository;
        }

        public IUserIdentity GetUserIdentity(string token)
        {
            var user = _repository.Get(new Guid(token));
            return user != null
                ? new UserIdentity(user.Id, user.UserName, user.Roles != null ? user.Roles.ToList().Select(x => x.Value).ToArray() : Enumerable.Empty<string>().ToArray())
                : null;
        }

        public IUserIdentity GetUserIdentity(string username, string password)
        {
            var user = _repository.GetByUserName(username);
            if (user == null)
            {
                this.Error(() => "User not found: {0}".FormatWith(username), SystemName.UserManagement);
                return null;                
            }

            var isValid = user.ValidatePassword(password);

            return isValid
                ? new UserIdentity(user.Id, user.UserName, user.Roles != null ? user.Roles.ToList().Select(x => x.Value).ToArray() : Enumerable.Empty<string>().ToArray())
                : null;
        }
    }
}