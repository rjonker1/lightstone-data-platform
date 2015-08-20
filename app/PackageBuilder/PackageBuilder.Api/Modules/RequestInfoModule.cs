using System;
using System.Collections.Generic;
using Shared.BuildingBlocks.Api.ApiClients;
using Shared.BuildingBlocks.Api.Security;

namespace PackageBuilder.Api.Modules
{
    public class RequestInfoModule : SecureModule
    {
        public RequestInfoModule(IUserManagementApiClient userManagementApi)
        {
            Get["/RequestInfo"] = _ =>
            {
                var token = Context.Request.Headers.Authorization.Split(' ')[1];
                var user = userManagementApi.Get<RequestInfoDto>(token, "/RequestInfo/{username}", new[] { new KeyValuePair<string, string>("username", Context.CurrentUser.UserName) });
                return user;
            };
        }
    }

    public class EntityDto
    {
        public string Modified { get; set; }
        public string ModifiedBy { get; set; }
        public string Created { get; set; }
        public string CreatedBy { get; set; }
    }

    public class NamedEntityDto : EntityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AssemblyQualifiedName { get; set; }
    }

    public class RequestInfoDto
    {
        public IEnumerable<RequestInfoCustomerDto> Customers { get; set; }
    }

    public class RequestInfoCustomerDto : NamedEntityDto
    {
        public IEnumerable<RequestInfoContractDto> Contracts { get; set; }
    }

    public class RequestInfoContractDto : NamedEntityDto
    {
        public IEnumerable<RequestInfoPackageDto> Packages { get; set; }
    }

    public class RequestInfoPackageDto : NamedEntityDto
    {
        public IEnumerable<RequestInfoRequestFieldDto> RequestFields { get; set; }
    }

    public class RequestInfoRequestFieldDto
    {
        public int Index { get; set; }
        public string Name { get; set; }
    }
}