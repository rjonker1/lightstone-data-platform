using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataProviders.Lightstone.MMCode;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_mmcode_with_carid: Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendCommandToBus _command;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_mmcode_with_carid()
        {
            _command = MonitoringBusBuilder.ForRgtCommands(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForMmCode();
            _response = new Collection<IPointToLaceProvider>();
            _dataProvider = new MmCodeDataProvider(_request, null, null, _command);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void lace_mmcode_response_should_be_handled()
        {
            _response.OfType<IProvideDataFromMmCode>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lace_mmcode_response_should_not_be_null()
        {
            _response.OfType<IProvideDataFromMmCode>().First().ShouldNotBeNull();
        }
    }
}