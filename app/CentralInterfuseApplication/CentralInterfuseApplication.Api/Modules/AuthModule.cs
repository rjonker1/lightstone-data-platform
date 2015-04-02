using System;
using System.Collections.Generic;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Authentication.Token;
using Shared.BuildingBlocks.Api.ApiClients;

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
                var token = client.Post("", "/login", null, new[] { new KeyValuePair<string, string>("Username", "murraytopdog"), new KeyValuePair<string, string>("Password", "WCo8RtYv5mlSdRq1F+jnhoTPoUGdLHvqGoNH7yGqJuc=") });

                var userIdentity = tokenizer.Detokenize(token, Context, new DefaultUserIdentityResolver());

                Context.CurrentUser = userIdentity;

                return token;
            };
        }
    }
}