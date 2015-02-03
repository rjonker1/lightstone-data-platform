﻿using Nancy;
using Nancy.Responses.Negotiation;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class UserTypeModule : NancyModule
    {
        public UserTypeModule(IRepository<UserType> userTypes)
        {
            Get["/UserTypes"] = _ =>
            {
                return Negotiate
                    .WithView("Index")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new {data = userTypes});
            };
        }
    }
}