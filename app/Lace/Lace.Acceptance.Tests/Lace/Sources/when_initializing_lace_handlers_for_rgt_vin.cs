﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_rgt_vin : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_rgt_vin()
        {
            _command = MonitoringBusBuilder.ForRgtVinCommands(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForRgtVin();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
            _dataProvider = new RgtVinDataProvider(_request, null, null, _command);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lace_functional_test_rgt_vin_response_should_be_handled()
        {
            _response.OfType<IProvideDataFromRgtVin>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_functional_test_rgt_vin_response_shuould_not_be_null()
        {
            _response.OfType<IProvideDataFromRgtVin>().First().ShouldNotBeNull();
        }
    }
}
