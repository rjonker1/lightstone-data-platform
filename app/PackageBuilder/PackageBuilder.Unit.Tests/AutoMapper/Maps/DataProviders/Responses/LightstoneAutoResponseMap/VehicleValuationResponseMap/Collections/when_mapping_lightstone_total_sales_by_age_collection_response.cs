﻿namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders.Responses.LightstoneAutoResponseMap.VehicleValuationResponseMap.Collections
{
    /// <summary>
    /// IRespondWithTotalSalesByAgeModel Deprecated
    /// </summary>
    //public class when_mapping_lightstone_total_sales_by_age_collection_response : when_not_persisting_entities
    //{
    //    private IDataField _dataField;

    //    public override void Observe()
    //    {
    //        base.Observe();

    //        _dataField = Mapper.Map<IEnumerable<IRespondWithTotalSalesByAgeModel>, DataField>(LightstoneResponseMother.Response.VehicleValuation.TotalSalesByAge);
    //    }

    //    [Observation]
    //    public void should_map_total_sales_by_age_data_fields()
    //    {
    //        _dataField.Name.ShouldEqual("TotalSalesByAge");
    //        _dataField.Type.ShouldEqual(typeof(List<IRespondWithTotalSalesByAgeModel>).ToString());

    //        var dataFields = _dataField.DataFields;

    //        dataFields.Count().ShouldEqual(2);

    //        dataFields.FirstOrDefault(x => x.Name == "Band").Name.ShouldEqual("Band");
    //        dataFields.FirstOrDefault(x => x.Name == "Band").Type.ShouldEqual(typeof(string).ToString());

    //        dataFields.FirstOrDefault(x => x.Name == "Values").Name.ShouldEqual("Values");
    //        dataFields.FirstOrDefault(x => x.Name == "Values").Type.ShouldEqual(typeof(IPair<string, double>[]).ToString());
    //    }
    //}
}