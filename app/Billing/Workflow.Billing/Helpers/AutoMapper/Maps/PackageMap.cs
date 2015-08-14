using AutoMapper;
using Workflow.Billing.Domain.Dtos;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class PackageMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<Package, PackageDto>();
        }
    }
}