using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Mothers.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.ErrorHandling
{
    public class when_executing_request_with_errors_for_lightstone : Specification
    {
        private ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ICollection<IPointToLaceProvider> _response;
        private LightstoneAutoDataProvider _consumer;

        public when_executing_request_with_errors_for_lightstone()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
        }

        public override void Observe()
        {
           
        }

        [Observation]
        public void then_tehcnical_error_should_be_thrown()
        {
            _request = new[] { new LicensePlateNumberLightstoneOnlyRequest() };
            _response = new Collection<IPointToLaceProvider>()
            {
                IvidResponse.WithState(DataProviderResponseState.TechnicalError)
            };

            _consumer = new LightstoneAutoDataProvider(_request, null, null, _command);
            _consumer.CallSource(_response);

            _response.HasAllRecords().ShouldBeFalse();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ResponseState.ShouldEqual(DataProviderResponseState.NoRecords);
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ResponseStateMessage.ShouldNotBeEmpty();
        }

        [Observation]
        public void then_tehcnical_no_results_should_be_thrown()
        {
            _request = new[] { new NoRecordCarIdLightstoneOnlyRequest() };
            _response = new Collection<IPointToLaceProvider>();

            _consumer = new LightstoneAutoDataProvider(_request, null, null, _command);
            _consumer.CallSource(_response);


            _response.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ResponseState.ShouldEqual(DataProviderResponseState.NoRecords);
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ResponseStateMessage.ShouldNotBeEmpty();
        }
    }
}
