using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Write.Responses
{
    public class AudatexResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromAudatex, IEnumerable<IDataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);

            Mapper.CreateMap<IEnumerable<IProvideAccidentClaim>, IDataField>().ConvertUsing(s => new DataField("AccidentClaims", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IProvideAccidentClaim, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
        }

        private static IEnumerable<IDataField> ToDataFields<T>(IEnumerable<T> s)
        {
            return s.SelectMany(x => Mapper.Map<object, IEnumerable<IDataField>>(x)).ToList();
        }
    }
}