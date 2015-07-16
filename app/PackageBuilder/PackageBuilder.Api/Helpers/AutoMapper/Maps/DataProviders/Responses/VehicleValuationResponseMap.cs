using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.DataFields.Write;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class VehicleValuationResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            #region AmortisationFactors
            //Mapper.CreateMap<IEnumerable<IRespondWithAmortisationFactorModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "AmortisationFactors"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithAmortisationFactorModel>()));
            //Mapper.CreateMap<IRespondWithAmortisationFactorModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region AreaFactors
            //Mapper.CreateMap<IEnumerable<IRespondWithAreaFactorModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "AreaFactors"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithAreaFactorModel>()));
            //Mapper.CreateMap<IRespondWithAreaFactorModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region AuctionFactors
            //Mapper.CreateMap<IEnumerable<IRespondWithAuctionFactorModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "AuctionFactors"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithAuctionFactorModel>()));
            //Mapper.CreateMap<IRespondWithAuctionFactorModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region AccidentDistribution
            //Mapper.CreateMap<IEnumerable<IRespondWithAccidentDistributionModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "AccidentDistribution"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithAccidentDistributionModel>()));
            //Mapper.CreateMap<IRespondWithAccidentDistributionModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region RepairIndex
            //Mapper.CreateMap<IEnumerable<IRespondWithRepairIndexModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "RepairIndex"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithRepairIndexModel>()));
            //Mapper.CreateMap<IRespondWithRepairIndexModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region TotalSalesByAge
            //Mapper.CreateMap<IEnumerable<IRespondWithTotalSalesByAgeModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "TotalSalesByAge"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithTotalSalesByAgeModel>()));
            //Mapper.CreateMap<IRespondWithTotalSalesByAgeModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region TotalSalesByGender
            //Mapper.CreateMap<IEnumerable<IRespondWithTotalSalesByGenderModel>, DataField>()
            //    .ForMember(s => s.Name, opt => opt.MapFrom(x => "TotalSalesByGender"))
            //    .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
            //    .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithTotalSalesByGenderModel>()));
            //Mapper.CreateMap<IRespondWithTotalSalesByGenderModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region EstimatedValue
            Mapper.CreateMap<IEnumerable<IRespondWithEstimatedValueModel>, DataField>()
                .ForMember(s => s.Name, opt => opt.MapFrom(x => "EstimatedValue"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithEstimatedValueModel>()));
            Mapper.CreateMap<IRespondWithEstimatedValueModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region LastFiveSales
            Mapper.CreateMap<IEnumerable<IRespondWithSaleModel>, DataField>()
                .ForMember(s => s.Name, opt => opt.MapFrom(x => "LastFiveSales"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithSaleModel>()));
            Mapper.CreateMap<IRespondWithSaleModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region Prices
            Mapper.CreateMap<IEnumerable<IRespondWithPriceModel>, DataField>()
                .ForMember(s => s.Name, opt => opt.MapFrom(x => "Prices"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithPriceModel>()));
            Mapper.CreateMap<IRespondWithPriceModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region Frequency
            Mapper.CreateMap<IEnumerable<IRespondWithFrequencyModel>, DataField>()
                .ForMember(s => s.Name, opt => opt.MapFrom(x => "Frequency"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithFrequencyModel>()));
            Mapper.CreateMap<IRespondWithFrequencyModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region Confidence
            Mapper.CreateMap<IEnumerable<IRespondWithConfidenceModel>, DataField>()
                .ForMember(s => s.Name, opt => opt.MapFrom(x => "Confidence"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithConfidenceModel>()));
            Mapper.CreateMap<IRespondWithConfidenceModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region AmortisedValues
            Mapper.CreateMap<IEnumerable<IRespondWithAmortisedValueModel>, DataField>()
                .ForMember(s => s.Name, opt => opt.MapFrom(x => "AmortisedValues"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithAmortisedValueModel>()));
            Mapper.CreateMap<IRespondWithAmortisedValueModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
            #region ImageGauges
            Mapper.CreateMap<IEnumerable<IRespondWithImageGaugeModel>, DataField>()
                .ForMember(s => s.Name, opt => opt.MapFrom(x => "ImageGauges"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(SourceMember<IRespondWithImageGaugeModel>()));
            Mapper.CreateMap<IRespondWithImageGaugeModel, IEnumerable<DataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            #endregion
        }

        private static Expression<Func<IEnumerable<T>, IEnumerable<DataField>>> SourceMember<T>()
        {
            return x => x != null ? x.SelectMany(arg => Mapper.Map<object, IEnumerable<DataField>>(arg)).ToList() : Enumerable.Empty<DataField>();
        }
    }
}