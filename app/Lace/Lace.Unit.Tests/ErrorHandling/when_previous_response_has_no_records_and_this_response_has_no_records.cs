using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    public class when_previous_response_has_no_records_and_this_response_has_no_records : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_previous_response_has_no_records_and_this_response_has_no_records()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForLightstoneLicensePlate();
            var ividResponse = IvidResponse.WithState(DataProviderResponseState.NoRecords);
            ividResponse.HasBeenHandled();
            _response = new Collection<IPointToLaceProvider>()
            {
                ividResponse
            }; 
            _dataProvider = new LightstoneAutoDataProvider(_request, null, null, _command);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void response_should_have_no_records_result_and_should_continue()
        {
            _response.HasAllRecords().ShouldBeFalse();
            _response.IsPartial().ShouldBeFalse();
            _response.IsTechnicalErrorsOnly().ShouldBeFalse();
            _response.State().ShouldEqual(DataProviderResponseState.NoRecords);
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().VehicleValuation.ShouldNotBeNull();

        }
    }
}
