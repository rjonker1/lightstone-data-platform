using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Vin12;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Mothers.Requests.Vin12Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Vin12
{
    public class when_consuming_vin12_data_provider : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private Vin12DataProvider _consumer;

        public when_consuming_vin12_data_provider()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _request = new[] { new Vin12Request() };
            _response = new Collection<IPointToLaceProvider>();
        }
        public override void Observe()
        {
            _consumer = new Vin12DataProvider(_request, null, null, _command);
            _consumer.CallSource(_response);
        }

        [Observation]
        public void then_vin12_response_from_consumer_must_not_be_empty()
        {
            _response.OfType<IProvideDataFromVin12>().First().Vin12Information.ShouldNotBeNull();
            _response.OfType<IProvideDataFromVin12>().First().Vin12Information.First().BodyShape.ShouldNotBeEmpty();
            _response.OfType<IProvideDataFromVin12>().First().Vin12Information.Count().ShouldEqual(80);
        }
    }
}
