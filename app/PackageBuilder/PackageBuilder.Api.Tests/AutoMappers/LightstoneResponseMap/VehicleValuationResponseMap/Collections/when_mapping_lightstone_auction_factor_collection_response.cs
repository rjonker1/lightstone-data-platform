using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using Lace.Domain.Core.Contracts.DataProviders.Specifics;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestObjects.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.LightstoneResponseMap.VehicleValuationResponseMap.Collections
{
    public class when_mapping_lightstone_auction_factor_collection_response : Specification
    {
        private IDataField _dataField;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dataField = Mapper.Map<IEnumerable<IRespondWithAuctionFactorModel>, IDataField>(LightstoneResponseMother.Response.VehicleValuation.AuctionFactors);
        }

        [Observation]
        public void should_map_auction_factor_data_fields()
        {
            _dataField.Name.ShouldEqual("AuctionFactors");
            _dataField.Type.ShouldEqual(typeof(List<IRespondWithAuctionFactorModel>));

            var dataFields = _dataField.DataFields;

            dataFields.Count().ShouldEqual(2);

            dataFields.FirstOrDefault(x => x.Name == "Make").Name.ShouldEqual("Make");
            dataFields.FirstOrDefault(x => x.Name == "Make").Type.ShouldEqual(typeof(string));

            dataFields.FirstOrDefault(x => x.Name == "Value").Name.ShouldEqual("Value");
            dataFields.FirstOrDefault(x => x.Name == "Value").Type.ShouldEqual(typeof(decimal));
        }
    }
}