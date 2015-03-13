using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.WriteModels.Responses
{
    public class LightstonePropertyResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromLightstoneProperty, IEnumerable<IDataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            Mapper.CreateMap<IEnumerable<IRespondWithProperty>, IDataField>().ConvertUsing(s => new DataField("PropertyInformation", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithProperty, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
        }

        private static IEnumerable<IDataField> ToDataFields<T>(IEnumerable<T> s)
        {
            return s.SelectMany(x => Mapper.Map<object, IEnumerable<IDataField>>(x)).ToList();
        }
    }
}