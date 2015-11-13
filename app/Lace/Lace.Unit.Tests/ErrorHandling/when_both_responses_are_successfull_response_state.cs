using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPlatform.Shared.Enums;
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

namespace Lace.Unit.Tests.ErrorHandling
{
    public class when_both_responses_are_successfull_response_state : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_both_responses_are_successfull_response_state()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForLightstoneLicensePlate();
            var ividResponse = IvidResponse.WithState(DataProviderResponseState.Successful);
            ividResponse.HasBeenHandled();

            var lightstoneResponse = LightstoneAutoResponse.WithState(DataProviderResponseState.Successful);
            lightstoneResponse.HasBeenHandled();

            _response = new Collection<IPointToLaceProvider>()
            {
                ividResponse,
                lightstoneResponse
            };
            _dataProvider = new LightstoneAutoDataProvider(_request, null, null, _command);
        }

        public override void Observe()
        {
           
        }

        [Observation]
        public void response_should_successful_result_and_should_continue()
        {
            _response.HasAllRecords().ShouldBeTrue();
            _response.IsPartial().ShouldBeFalse();
            _response.State().ShouldEqual(DataProviderResponseState.Successful);
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.ShouldNotBeNull();

        }
    }
}
