using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.DataProviders.Ivid;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Mothers.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Unit.Tests.ErrorHandling
{
    public class when_ivid_data_provider_is_causes_a_technical_failure : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private IvidDataProvider _consumer;

        public when_ivid_data_provider_is_causes_a_technical_failure()
        {
            _command = MonitoringBusBuilder.ForIvidCommands(Guid.NewGuid());
            _request = new[] {new IvidTechnicalFailureRequest()};
            _response = new Collection<IPointToLaceProvider>();
        }

        public override void Observe()
        {
            _consumer = new IvidDataProvider(_request, null, null, _command);
            _consumer.CallSource(_response);
        }

        [Observation]
        public void then_technical_error_should_be_raised_on_error()
        {
            _response.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();
            _response.HasAllRecords().ShouldBeFalse();
            _response.OfType<IProvideDataFromIvid>().First().ResponseState.ShouldEqual(DataProviderResponseState.TechnicalError);
            _response.OfType<IProvideDataFromIvid>().First().ResponseStateMessage.ShouldNotBeEmpty();
        }
    }
}