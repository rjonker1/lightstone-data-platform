using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.Api.Helpers.AutoMapper.Maps.DataProviders.Responses
{
    public class VehicleValuationResponseMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            #region AmortisationFactors
            Mapper.CreateMap<IEnumerable<IRespondWithAmortisationFactorModel>, IDataField>().ConvertUsing(s => new DataField("AmortisationFactors", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithAmortisationFactorModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region AreaFactors
            Mapper.CreateMap<IEnumerable<IRespondWithAreaFactorModel>, IDataField>().ConvertUsing(s => new DataField("AreaFactors", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithAreaFactorModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region AuctionFactors
            Mapper.CreateMap<IEnumerable<IRespondWithAuctionFactorModel>, IDataField>().ConvertUsing(s => new DataField("AuctionFactors", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithAuctionFactorModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region AccidentDistribution
            Mapper.CreateMap<IEnumerable<IRespondWithAccidentDistributionModel>, IDataField>().ConvertUsing(s => new DataField("AccidentDistribution", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithAccidentDistributionModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region RepairIndex
            Mapper.CreateMap<IEnumerable<IRespondWithRepairIndexModel>, IDataField>().ConvertUsing(s => new DataField("RepairIndex", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithRepairIndexModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region TotalSalesByAge
            Mapper.CreateMap<IEnumerable<IRespondWithTotalSalesByAgeModel>, IDataField>().ConvertUsing(s => new DataField("TotalSalesByAge", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithTotalSalesByAgeModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region TotalSalesByGender
            Mapper.CreateMap<IEnumerable<IRespondWithTotalSalesByGenderModel>, IDataField>().ConvertUsing(s => new DataField("TotalSalesByGender", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithTotalSalesByGenderModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region EstimatedValue
            Mapper.CreateMap<IEnumerable<IRespondWithEstimatedValueModel>, IDataField>().ConvertUsing(s => new DataField("EstimatedValue", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithEstimatedValueModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region LastFiveSales
            Mapper.CreateMap<IEnumerable<IRespondWithSaleModel>, IDataField>().ConvertUsing(s => new DataField("LastFiveSales", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithSaleModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region Prices
            Mapper.CreateMap<IEnumerable<IRespondWithPriceModel>, IDataField>().ConvertUsing(s => new DataField("Prices", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithPriceModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region Frequency
            Mapper.CreateMap<IEnumerable<IRespondWithFrequencyModel>, IDataField>().ConvertUsing(s => new DataField("Frequency", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithFrequencyModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region Confidence
            Mapper.CreateMap<IEnumerable<IRespondWithConfidenceModel>, IDataField>().ConvertUsing(s => new DataField("Confidence", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithConfidenceModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region AmortisedValues
            Mapper.CreateMap<IEnumerable<IRespondWithAmortisedValueModel>, IDataField>().ConvertUsing(s => new DataField("AmortisedValues", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithAmortisedValueModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
            #region ImageGauges
            Mapper.CreateMap<IEnumerable<IRespondWithImageGaugeModel>, IDataField>().ConvertUsing(s => new DataField("ImageGauges", s.GetType(), ToDataFields(s)));
            Mapper.CreateMap<IRespondWithImageGaugeModel, IEnumerable<IDataField>>().ConvertUsing(Mapper.Map<object, IEnumerable<IDataField>>);
            #endregion
        }

        private static IEnumerable<IDataField> ToDataFields<T>(IEnumerable<T> s)
        {
            return s.SelectMany(x => Mapper.Map<object, IEnumerable<IDataField>>(x)).ToList();
        }
    }
}