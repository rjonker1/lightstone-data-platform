using System;
using System.Collections.Generic;
using AutoMapper;
using Nancy;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class MetaDetailModule : SecureModule
    {
        public MetaDetailModule(IUserRepository userRepository)
        {
            Get["/Meta/User/{username}"] = parameters =>
            {
                var username = (String) parameters.username;
                var dto = Mapper.Map<User, MetaDetailDto>(userRepository.GetByUserName(username));

                return Response.AsJson(dto);
            };
        }
    }

    public class MetaDetailDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public IEnumerable<MetaCustomerDto> Customers { get; set; } 
        public IEnumerable<MetaClientDto> Clients { get; set; } 
    }

    public class MetaCustomerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MetaContractDto> Contracts { get; set; }
    }

    public class MetaClientDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MetaContractDto> Contracts { get; set; }
    }

    public class MetaContractDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MetaPackageDto> Packages { get; set; }
    }

    public class MetaPackageDto
    {
        public Guid PackageId { get; set; }
        public string PackageName { get; set; }
    }
}