using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PackageBuilder.Api.Helpers.AutoMaps
{
    public class PackageMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            //Mapper.CreateMap<DataProviderDto, DataProvider>()
            //    .ConvertUsing(x => new DataProvider(x.Id, x.Name, Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<IDataField>>(x.DataFields)));
        }
    }
}