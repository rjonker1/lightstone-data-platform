﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_confidence_collection_response : Specification
    {
        private IDataField _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IEnumerable<IRespondWithConfidenceModel>, IDataField>(LightstoneResponseMother.Response.VehicleValuation.Confidence);
        }

        [Observation]
        public void should_map_confidence_data_fields()
        {
            _dataField.Name.ShouldEqual("Confidence");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithConfidenceModel>));

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(3);

            dataFields.FirstOrDefault(x => x.Name == "CarType").Name.ShouldEqual("CarType");
            dataFields.FirstOrDefault(x => x.Name == "CarType").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            dataFields.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int));

            dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double));
        }
    }
}