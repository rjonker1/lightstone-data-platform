using AutoMapper;
using PackageBuilder.Domain.Dtos.Read;
using PackageBuilder.Domain.Entities.DataProviders.Read;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Read
{
    public class ToDataProviderDtoMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<DataProvider, DataProviderDto>();
        }
    }
}