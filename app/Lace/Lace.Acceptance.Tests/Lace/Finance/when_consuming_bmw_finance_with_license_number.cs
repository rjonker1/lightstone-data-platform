using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Bmw.Finance;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests.FinanceRequests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Finance
{
    public class when_consuming_bmw_finance_with_license_number : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private BmwFinanceDataProvider _consumer;

        public when_consuming_bmw_finance_with_license_number()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _request = new[] { new BmwFinanceRequestWithLicenseNumber(),  };
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
        }

        public override void Observe()
        {
            _consumer = new BmwFinanceDataProvider(_request, null, null, _command);
            _consumer.CallSource(_response);
        }

        [Observation]
        public void lightstone_consumer_must_be_handled()
        {
            _response.OfType<IProvideDataFromBmwFinance>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void lightstone_response_from_consumer_must_not_be_null()
        {
            _response.OfType<IProvideDataFromBmwFinance>().First().ShouldNotBeNull();
        }

        [Observation]
        public void lightstone_response_from_consumer_must_not_be_empty()
        {
            _response.OfType<IProvideDataFromBmwFinance>().First().Finances.ShouldNotBeNull();
            _response.OfType<IProvideDataFromBmwFinance>().First().Finances.First().Description.ShouldEqual("BMW 320i M SPORT LINE A/T (F30)");
            _response.OfType<IProvideDataFromBmwFinance>().First().Finances.First().RegistrationYear.ShouldEqual(2014);
        }
    }
}
