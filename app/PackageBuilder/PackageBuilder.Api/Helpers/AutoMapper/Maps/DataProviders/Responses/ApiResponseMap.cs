using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class ApiResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IDataProvider, ResponseDataProviderDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => x.Name.ToString()));

            Mapper.CreateMap<IDataField, ResponseDataFieldDto>();
        }
    }
}