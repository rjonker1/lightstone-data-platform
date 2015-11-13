using System.Collections.Generic;
using System.Linq;
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
            // NB: Work around
            // Bug: Would map multiple destination items of the 1st item in the source collection
            // Eg: Source containing 2 data providers Ivid & LightstoneAuto, would map and return 2 destination items of Ivid instead of Ivid & LightstoneAuto
            // Cause: Passing in DataProvider instead of IDataProvider as source
            Mapper.CreateMap<IEnumerable<IDataProvider>, IEnumerable<IProvideResponseDataProvider>>()
                .ConvertUsing(x => x.Select(Mapper.Map<IDataProvider, ResponseDataProviderDto>));
            // End of work around

            Mapper.CreateMap<IDataProvider, ResponseDataProviderDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => x.Name.ToString()))
                .ForMember(d => d.ResponseState, opt => opt.MapFrom(m => m.ResponseState));

            Mapper.CreateMap<IDataField, ResponseDataFieldDto>();
        }
    }
}