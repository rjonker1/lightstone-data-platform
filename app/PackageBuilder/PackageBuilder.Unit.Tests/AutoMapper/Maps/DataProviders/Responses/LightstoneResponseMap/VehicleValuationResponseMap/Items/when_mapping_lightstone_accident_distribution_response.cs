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
    /// IRespondWithAccidentDistributionModel Deprecated
    /// </summary>
    //public class when_mapping_lightstone_accident_distribution_response : when_not_persisting_entities
    //{
    //    private IEnumerable<IDataField> _dataField;

    //    public override void Observe()
    //    {
    //        base.Observe();

    //        _dataField = Mapper.Map<IRespondWithAccidentDistributionModel, IEnumerable<DataField>>(LightstoneResponseMother.Response.VehicleValuation.AccidentDistribution.First());
    //    }

    //    [Observation]
    //    public void should_map_accident_distribution_data_fields()
    //    {
    //        _dataField.Count().ShouldEqual(2);

    //        _dataField.FirstOrDefault(x => x.Name == "Band").Name.ShouldEqual("Band");
    //        _dataField.FirstOrDefault(x => x.Name == "Band").Type.ShouldEqual(typeof(string).ToString());

    //        _dataField.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
    //        _dataField.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double).ToString());
    //    }
    //}
}