﻿using System.Collections.Generic;
using LiveAuto.Api.Routes;
using LiveAuto.Web.Dtos;
using Nancy;
using Nancy.ModelBinding;
using Shared.BuildingBlocks.Api.ApiClients;

namespace LiveAuto.Web.Modules
{
    public class AuthorizationModule : NancyModule
    {
        public AuthorizationModule(IUserManagementApiClient userManagementApi)
        {
            Get[LiveAutoApiRoute.Authorization.GetChangePassword] = _ =>
            {
                var dto = new ChangePasswordDto(_.token, "");
                return View["index", dto];
            };

            Post[LiveAutoApiRoute.Authorization.PutChangePassword] = _ =>
            {
                var dto = this.Bind<ChangePasswordDto>();
                if ((dto.Password + "").Length < 5)
                {
                    dto.Message = "Password length must be at least 5 characters long";
                    return View["index", dto];                    
                }

                dto.Message = userManagementApi.Put("", "Users/ResetPassword/{token}", new[] { new KeyValuePair<string, string>("token", dto.Token + "") }, dto, null);
                if (!dto.Message.Contains("Password changed"))
                    dto.Message = "Error updating password";

                return View["index", dto];
            };
        }
    }
}