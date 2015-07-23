using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneResponseMap.VehicleValuationResponseMap.Items
{
    /// <summary>
    /// IRespondWithAmortisationFactorModel Deprecated
    /// </summary>
    //public class when_mapping_lightstone_amortisation_factor_response : when_not_persisting_entities
    //{
    //    private IEnumerable<IDataField> _dataField;

    //    public override void Observe()
    //    {
    //        base.Observe();

    //        _dataField = Mapper.Map<IRespondWithAmortisationFactorModel, IEnumerable<DataField>>(LightstoneResponseMother.Response.VehicleValuation.AmortisationFactors.First());
    //    }

    //    [Observation]
    //    public void should_map_amortisation_factor_data_fields()
    //    {
    //        _dataField.Count().ShouldEqual(2);

    //        _dataField.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
    //        _dataField.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int).ToString());

    //        _dataField.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
    //        _dataField.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double).ToString());
    //    }
    //}
}