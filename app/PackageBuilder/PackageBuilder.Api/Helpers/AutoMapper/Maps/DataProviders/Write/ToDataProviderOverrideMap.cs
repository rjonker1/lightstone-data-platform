using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Write
{
    public class ToDataProviderOverrideMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<DataProviderDto, DataProviderOverride>()
                .ForMember(d => d.RequestFieldOverrides, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataFieldOverride>>(x.RequestFields)))
                .ForMember(d => d.DataFieldOverrides, opt => opt.MapFrom(x => Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataFieldOverride>>(x.DataFields)))
                .AfterMap((s, d) =>
                {
                    if (s.FieldLevelCostPriceOverride)
                    {
                        d.CostOfSale = 0;
                        s.DataFields.ToList()
                               .RecursiveForEach(x =>
                               {
                                   if (x.IsSelected == true && !x.DataFields.Any())
                                   {
                                       d.CostOfSale += x.CostOfSale;
                                   }
                               });
                    }

                });
        }
    }
}