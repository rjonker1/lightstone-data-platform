using System.Linq;
using DataPlatform.Shared.Helpers.Extensions;
using Nancy;
using Nancy.Authentication.Token;
using UserManagement.Api.Helpers.Security;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Enums;

namespace UserManagement.Api.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(IUmAuthenticator authenticator, IRepository<User> users, IRepository<Role> roles, ITokenizer tokenizer)
        {
            //Post["/authenticate"] = parameters =>
            //{
            //    _log.InfoFormat("authenticate");

            //    //var token = Context.AuthorizationHeaderToken();
            //    var token = tokenizer.Tokenize(userIdentity, Context);

            //    return string.IsNullOrWhiteSpace(token) ? Response.AsJson((string)null) : Response.AsJson(authenticator.GetUserIdentity(token));
            //};

            Post["/login"] = parameters =>
            {
                var username = Context.Request.Headers["Username"].FirstOrDefault();
                var password = Context.Request.Headers["Password"].FirstOrDefault();
                var userIdentity = authenticator.GetUserIdentity(username, password);

                //foreach (var roleValue in userIdentity.Claims)
                //{
                //    var role = roles.Where(r => r.Value == roleValue);
                //}

                //.Where(x => x.Roles.Select(r => r.Value == "AccountOwner").FirstOrDefault());

                if (userIdentity != null)
                {
                    var user = users.FirstOrDefault(x => x.UserName == userIdentity.UserName);
                    if (user != null)
                    {
                        var userType = user.UserType;
                        if (userType != UserType.Internal)
                        {
                            userIdentity = null;
                            this.Error(() => "Log in attempt failed: User {0}, ActionedUserType: {1}".FormatWith(username, userType));
                        }
                    }
                }

                return userIdentity == null
                    ? HttpStatusCode.Unauthorized
                    : Response.AsText(tokenizer.Tokenize(userIdentity, Context));
            };

            Post["/login/api"] = parameters =>
            {
                var username = Context.Request.Headers["Username"].FirstOrDefault();
                var password = Context.Request.Headers["Password"].FirstOrDefault();
                var userIdentity = authenticator.GetUserIdentity(username, password);

                if (userIdentity != null)
                {
                    var user = users.FirstOrDefault(x => x.UserName == userIdentity.UserName);
                    if (user != null)
                    {
                        var userType = user.UserType;
                        if (userType != UserType.Internal && userType != UserType.External)
                        {
                            userIdentity = null;
                            this.Error(() => "Log in attempt failed: User {0}, ActionedUserType: {1}".FormatWith(username, userType));
                        }
                    }
                }

                return userIdentity == null
                    ? HttpStatusCode.Unauthorized
                    : Response.AsText(tokenizer.Tokenize(userIdentity, Context));
            };
        }
    }
}