using System;
using System.Collections.Generic;
using AutoMapper;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Modules
{
    public class MetaDetailModule : NancyModule
    {
        public MetaDetailModule(IRepository<User> userRepository)
        {
            Get["/Meta/User/{id:guid}"] = parameters =>
            {
                var id = (Guid) parameters.id;
                var dto = Mapper.Map<User, MetaDetailDto>(userRepository.Get(id));

                return Response.AsJson(dto);
            };
        }
    }

    public class MetaDetailDto
    {
        public Guid Id { get; set; }
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
        public string PackageEventType { get; set; }
    }
}