using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Authentication.Token;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api.ApiClients;
using UserManagement.Api.Routes;

namespace CentralInterfuseApplication.Api.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(IUserManagementApiClient client, ITokenizer tokenizer)
        {
            Get["/login"] = parameters =>
            {
                return View["Index"];
            };

            Get["/logout"] = parameters =>
            {
                return this.Logout("/");
            };

            Post["/login"] = parameters =>
            {
                var model = this.Bind<AuthModel>();

                var token = client.Post("", "/login", null, null, new[] { new KeyValuePair<string, string>("Username", model.Username), new KeyValuePair<string, string>("Password", model.Password) });

                var userIdentity = tokenizer.Detokenize(token, Context, new DefaultUserIdentityResolver());

                Context.CurrentUser = userIdentity;

                return token;
            };

            Get["/forgotPassword/{username}"] = _ =>
            {
                ViewBag.Message = client.Put("", UserManagementApiRoute.User.RequestResetPassword, new[] { new KeyValuePair<string, string>("username", _.username + "") }, null, null);
                return View["Login"];
            };
        }
    }

    public class AuthModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}