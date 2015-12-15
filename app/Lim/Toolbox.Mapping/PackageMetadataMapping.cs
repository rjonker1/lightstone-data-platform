using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class PackageMetadataMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<PackageMetadata, PackageMetadataDto>()
                .ConstructUsing(meta => new PackageMetadataDto(meta.Description, meta.Payload, meta.Id)).ForAllMembers(opt => opt.Ignore());
            Mapper.CreateMap<PackageMetadataDto, PackageMetadata>();
        }
    }
}