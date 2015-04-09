using System.Linq;
using Nancy;
using Nancy.Authentication.Token;
using UserManagement.Api.Helpers.Security;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(IUmAuthenticator authenticator, IRepository<User> users, ITokenizer tokenizer)
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
                var username = Context.Request.Headers["Username"];
                var password = Context.Request.Headers["Password"];

                var userIdentity = authenticator.GetUserIdentity(username.FirstOrDefault(), password.FirstOrDefault());

                return userIdentity == null 
                    ? HttpStatusCode.Unauthorized 
                    : Response.AsText(tokenizer.Tokenize(userIdentity, Context));
            };
        }
    }
}