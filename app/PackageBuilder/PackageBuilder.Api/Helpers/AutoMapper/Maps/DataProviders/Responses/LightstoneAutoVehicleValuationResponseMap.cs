﻿using System.Collections.Generic;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class LightstoneAutoVehicleValuationResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            #region AmortisationFactors
            //Mapper.CreateMap<IEnumerable<IRespondWithAmortisationFactorModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "AmortisationFactors"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithAmortisationFactorModel>()));
            //Mapper.CreateMap<IRespondWithAmortisationFactorModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region AreaFactors
            //Mapper.CreateMap<IEnumerable<IRespondWithAreaFactorModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "AreaFactors"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithAreaFactorModel>()));
            //Mapper.CreateMap<IRespondWithAreaFactorModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region AuctionFactors
            //Mapper.CreateMap<IEnumerable<IRespondWithAuctionFactorModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "AuctionFactors"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithAuctionFactorModel>()));
            //Mapper.CreateMap<IRespondWithAuctionFactorModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region AccidentDistribution
            //Mapper.CreateMap<IEnumerable<IRespondWithAccidentDistributionModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "AccidentDistribution"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithAccidentDistributionModel>()));
            //Mapper.CreateMap<IRespondWithAccidentDistributionModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region RepairIndex
            //Mapper.CreateMap<IEnumerable<IRespondWithRepairIndexModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "RepairIndex"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithRepairIndexModel>()));
            //Mapper.CreateMap<IRespondWithRepairIndexModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region TotalSalesByAge
            //Mapper.CreateMap<IEnumerable<IRespondWithTotalSalesByAgeModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "TotalSalesByAge"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithTotalSalesByAgeModel>()));
            //Mapper.CreateMap<IRespondWithTotalSalesByAgeModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region TotalSalesByGender
            //Mapper.CreateMap<IEnumerable<IRespondWithTotalSalesByGenderModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "TotalSalesByGender"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithTotalSalesByGenderModel>()));
            //Mapper.CreateMap<IRespondWithTotalSalesByGenderModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region EstimatedValue
            Mapper.CreateMap<IEnumerable<IRespondWithEstimatedValueModel>, DataField>()
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithEstimatedValueModel>()));
            Mapper.CreateMap<IRespondWithEstimatedValueModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region LastFiveSales
            Mapper.CreateMap<IEnumerable<IRespondWithSaleModel>, DataField>()
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => NestedDataFieldBuilder.Build(x)));
            Mapper.CreateMap<IRespondWithSaleModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region Prices
            Mapper.CreateMap<IEnumerable<IRespondWithPriceModel>, DataField>()
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithPriceModel>()));
            Mapper.CreateMap<IRespondWithPriceModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region Frequency
            Mapper.CreateMap<IEnumerable<IRespondWithFrequencyModel>, DataField>()
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithFrequencyModel>()));
            Mapper.CreateMap<IRespondWithFrequencyModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region Confidence
            Mapper.CreateMap<IEnumerable<IRespondWithConfidenceModel>, DataField>()
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithConfidenceModel>()));
            Mapper.CreateMap<IRespondWithConfidenceModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region AmortisedValues
            Mapper.CreateMap<IEnumerable<IRespondWithAmortisedValueModel>, DataField>()
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithAmortisedValueModel>()));
            Mapper.CreateMap<IRespondWithAmortisedValueModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region ImageGauges
            Mapper.CreateMap<IEnumerable<IRespondWithImageGaugeModel>, DataField>()
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(NestedDataFieldBuilder.Build<IRespondWithImageGaugeModel>()));
            Mapper.CreateMap<IRespondWithImageGaugeModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
        }
    }
}