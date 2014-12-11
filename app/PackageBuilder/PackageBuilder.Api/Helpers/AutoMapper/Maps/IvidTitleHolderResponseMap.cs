using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps
{
    public class IvidTitleHolderResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromIvidTitleHolder, IEnumerable<IDataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
        }
    }
}