using System;
using System.Configuration;
using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using LiveAuto.Api.Routes;
using MemBus;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.ModelBinding;
using UserManagement.Api.Helpers.Security;
using UserManagement.Api.Routes;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities.Commands.Email;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Enums;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class AuthModule : NancyModule
    {
        public AuthModule(IUmAuthenticator authenticator, IUserRepository userRepository, ITokenizer tokenizer, IBus bus)
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
                    var user = userRepository.GetByUserName(userIdentity.UserName);
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

                this.Info(() => "UserIdentity: {0}, log in attempt".FormatWith(userIdentity));

                if (userIdentity != null)
                {
                    var user = userRepository.GetByUserName(userIdentity.UserName);
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

            Put[UserManagementApiRoute.User.RequestResetPassword] = _ =>
            {
                var username = (string)(_.username + "");
                var entity = userRepository.GetByUserName(username);
                if (entity == null) throw new LightstoneAutoException("Could not find username {0}".FormatWith(username));
                var token = entity.AssignResetPasswordToken();
                var url = ConfigurationManager.AppSettings["LiveAutoBaseUrl"] + LiveAutoApiRoute.Authorization.ChangePassword + "/" + token;

                bus.Publish(new CreateUpdateEntity(entity, "Update"));
                bus.Publish(new EmailMessage(new[] { entity.UserName }, "Password reset", url));

                return Response.AsText("Password reset mail sent");
            };

            Put[UserManagementApiRoute.User.ResetPassword] = _ =>
            {
                var model = this.Bind<ResetPasswordDto>();
                var token = (Guid)_.token;
                var user = userRepository.GetByResetToken(token);

                user.HashPassword(model.Password);
                user.ClearResetPasswordToken();

                return Response.AsText("Password changed");
            };
        }
    }
}