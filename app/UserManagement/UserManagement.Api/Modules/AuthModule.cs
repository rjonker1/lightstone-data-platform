using System.Linq;
using Common.Logging;
using Nancy;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class AuthModule : NancyModule
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();

        public AuthModule(IAuthenticateUser authenticator, IRepository<User> users)
        {
            Post["/authenticate"] = parameters =>
            {
                _log.InfoFormat("authenticate");

                var token = Context.AuthorizationHeaderToken();

                return string.IsNullOrWhiteSpace(token) ? Response.AsJson((string)null) : Response.AsJson(authenticator.GetUserIdentity(token));
            };

            Post["/login"] = parameters =>
            {
                var username = Context.Request.Headers["Username"];
                var password = Context.Request.Headers["Username"];

                var user = users.First(x => x.UserName.ToLower() == username.ToString().ToLower());

                return Response.AsJson(new ApiUser(user.UserName));
            };
        }
    }
}