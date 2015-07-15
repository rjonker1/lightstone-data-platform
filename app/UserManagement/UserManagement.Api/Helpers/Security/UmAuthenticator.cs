using System;
using System.Linq;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy.Security;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Core.Security;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.Security
{
    public interface IUmAuthenticator : IAuthenticateUser
    {
        IUserIdentity GetUserIdentity(string username, string password);
    }

    public class UmAuthenticator : IUmAuthenticator
    {
        private readonly IRepository<User> _repository;
        private readonly IHashProvider _hashProvider;

        public UmAuthenticator(IRepository<User> repository, IHashProvider hashProvider)
        {
            _repository = repository;
            _hashProvider = hashProvider;
        }

        public IUserIdentity GetUserIdentity(string token)
        {
            var user = _repository.Get(new Guid(token));
            return user == null
                ? null
                : new UserIdentity(user.UserName)
                {
                    Id = user.Id,
                    Claims = user.Roles != null ? user.Roles.ToList().Select(x => x.Value) : Enumerable.Empty<string>()
                };
        }

        public IUserIdentity GetUserIdentity(string username, string password)
        {
            var user = _repository.FirstOrDefault(x => (x.UserName + "").Trim().ToLower() == (username + "").Trim().ToLower());
            if (user == null)
            {
                this.Error(() => "User not found: {0}".FormatWith(username));
                return null;                
            }

            var isValid = _hashProvider.VerifyHashString(password, user.Password, user.Salt);

            return isValid
                ? new UserIdentity(user.UserName)
                {
                    Id = user.Id,
                    Claims = user.Roles != null ? user.Roles.ToList().Select(x => x.Value) : Enumerable.Empty<string>()
                }
                : null;
        }
    }
}