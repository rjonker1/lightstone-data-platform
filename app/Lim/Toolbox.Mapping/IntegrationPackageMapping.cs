using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class IntegrationPackageMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<IntegrationPackage, IntegrationPackageDto>()
                .ConstructUsing(
                    package =>
                        IntegrationPackageDto.Existing(package.Id, package.Configuration.Id, package.PackageId, package.IsActive, package.DateModified,
                            package.ModifiedBy, package.ContractId)).ForAllMembers(opt => opt.Ignore());
            Mapper.CreateMap<IntegrationPackageDto, IntegrationPackage>();
        }
    }
}
