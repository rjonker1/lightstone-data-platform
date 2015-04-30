using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using PackageBuilder.Domain.Dtos.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.Messages
{
    public class MessageMaps : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<PackageDto, PackageMessage>()
                .ForMember(dest => dest.PackageId, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.PackageName, opt => opt.MapFrom(x => x.Name));
        }
    }
}