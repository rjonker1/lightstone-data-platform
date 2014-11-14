using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.LightstoneResponseMap.VehicleValuationResponseMap.Items
{
    public class when_mapping_lightstone_amortisation_factor_response : Specification
    {
        private IEnumerable<IDataField> _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IRespondWithAmortisationFactorModel, IEnumerable<IDataField>>(LightstoneResponseMother.Response.VehicleValuation.AmortisationFactors.First());
        }

        [Observation]
        public void should_map_amortisation_factor_data_fields()
        {
            _dataField.Count().ShouldEqual(2);

            _dataField.FirstOrDefault(x => x.Name == "Year").Name.ShouldEqual("Year");
            _dataField.FirstOrDefault(x => x.Name == "Year").Type.ShouldEqual(typeof(int));

            _dataField.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            _dataField.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(double));
        }
    }
}