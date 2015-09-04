using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Finance;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class BmwFinanceResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<IProvideDataFromBmwFinance, IEnumerable<DataField>>()
               .ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            Mapper.CreateMap<IEnumerable<IRespondWithBmwFinance>, DataField>()
              .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
              .ForMember(d => d.DataFields, opt => opt.MapFrom(x => x != null ? x.SelectMany(Mapper.Map<object, IEnumerable<DataField>>).ToList() : Enumerable.Empty<IDataField>()));
            Mapper.CreateMap<IRespondWithBmwFinance, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
        }
    }
}