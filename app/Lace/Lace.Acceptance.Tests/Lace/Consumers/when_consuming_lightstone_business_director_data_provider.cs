using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Director;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Mothers.Requests.BusinessRequests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_lightstone_business_director_data_provider : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private LightstoneDirectorDataProvider _dataProvider;

        public when_consuming_lightstone_business_director_data_provider()
        {
            _command = MonitoringBusBuilder.ForLightstoneDirectorCommands(Guid.NewGuid());
            _request = new[] {new DirectorRequest(), };
            _response = new Collection<IPointToLaceProvider>();
        }

        public override void Observe()
        {
            _dataProvider = new LightstoneDirectorDataProvider(_request, null, null, _command);
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lightstone_director_consumer_must_be_handled()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessDirector>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lightstone_director_response_from_consumer_must_not_be_null()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessDirector>().First().ShouldNotBeNull();
        }

        [Observation]
        public void lightstone_director_response_from_consumer_must_have_a_compnany()
        {
            _response.OfType<IProvideDataFromLightstoneBusinessDirector>().First().Directors.Count().ShouldEqual(1);
        }

        [Observation]
        public void lightstone_director_consumer_next_source_must_be_null()
        {
            _dataProvider.Next.ShouldBeNull();
        }

        [Observation]
        public void lightstone_director_consumer_fallback_source_must_be_null()
        {
            _dataProvider.FallBack.ShouldBeNull();
        }
    }
}