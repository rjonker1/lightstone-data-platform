using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Mothers.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_ivid_with_license_and_vin_number_in_same_request : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private IvidDataProvider _consumer;

        public when_consuming_ivid_with_license_and_vin_number_in_same_request()
        {
            _command = MonitoringBusBuilder.ForIvidCommands(Guid.NewGuid());
            _request = new[] { new LicensePlateNumberAndVinNumberIvidRequest() };
            _response = new Collection<IPointToLaceProvider>();
        }

        public override void Observe()
        {
            _consumer = new IvidDataProvider(_request, null, null, _command);
            _consumer.CallSource(_response);
        }

        [Observation]
        public void then_only_one_response_should_execute()
        {
            Thread.Sleep(5000);
            _response.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromIvid>().First().Registration.ShouldEqual("FFB715K");
        }
    }
}
