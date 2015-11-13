using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.Maps
{
    public class PackageMetaMaps : Profile, ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<PackageMessage, PackageMeta>();
            Mapper.CreateMap<PackageMeta, Package>();
        }
    }
}