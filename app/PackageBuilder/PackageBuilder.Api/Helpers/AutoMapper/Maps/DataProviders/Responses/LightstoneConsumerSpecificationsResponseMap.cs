using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class LightstoneConsumerSpecificationsResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromLightstoneConsumerSpecifications, IEnumerable<DataField>>()
             .ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);

            Mapper.CreateMap<IEnumerable<IRespondWithRepairData>, DataField>()
               .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
               .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithRepairData>()));
        }

        private static Expression<Func<IEnumerable<T>, IEnumerable<DataField>>> SourceMember<T>()
        {
            return x => x != null ? x.SelectMany(arg => Mapper.Map<object, IEnumerable<DataField>>(arg)).ToList() : Enumerable.Empty<DataField>();
        }
    }
}