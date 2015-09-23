using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Unit.Tests.CriticalErrors
{
    public class when_response_has_a_critical_failure : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_response_has_a_critical_failure()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForLightstoneLicensePlate();
            _response = new Collection<IPointToLaceProvider>()
            {
                IvidResponse.Failure("Ivid Has Failed. criticalFailure Error")
            }; 
            _dataProvider = new LightstoneAutoDataProvider(_request, null, null, _command);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void response_should_have_critical_error_and_should_not_continue()
        {
            _response.HasCriticalError().ShouldBeTrue();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeFalse();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.ShouldNotBeNull();

        }
    }
}
