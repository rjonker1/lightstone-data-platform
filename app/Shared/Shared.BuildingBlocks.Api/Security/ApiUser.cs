using System;
using System.Collections.Generic;
using DataPlatform.Shared.Entities;
using Nancy.Security;

namespace Shared.BuildingBlocks.Api.Security
{
    public class ApiUser : IUserIdentity, IEntity
    {
        public ApiUser()
        {
        }

        public ApiUser(string userName)
        {
            UserName = userName;
            Claims = new List<string>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public IEnumerable<string> Claims { get; set; }
    }
}