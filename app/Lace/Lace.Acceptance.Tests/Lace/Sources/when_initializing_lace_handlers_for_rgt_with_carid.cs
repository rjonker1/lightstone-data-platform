﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Rgt;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_rgt_with_carid : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_rgt_with_carid()
        {
            _command = MonitoringBusBuilder.ForRgtCommands(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForRgt();
            _response = new Collection<IPointToLaceProvider>();
            _dataProvider = new RgtDataProvider(_request, null, null, _command);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lace_rgt_response_should_be_handled()
        {
            _response.OfType<IProvideDataFromRgt>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_rgt_response_should_not_be_null()
        {
            _response.OfType<IProvideDataFromRgt>().First().ShouldNotBeNull();
        }

        [Observation]
        public void lace_rgt_response_car_full_name_should_not_be_null()
        {
            _response.OfType<IProvideDataFromRgt>().First().CarFullname.ShouldNotBeNull();
        }
    }
}
