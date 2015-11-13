using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Bmw.Finance;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Mothers.Requests.FinanceRequests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Finance
{
    public class when_consuming_bmw_finance_with_account_number : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private BmwFinanceDataProvider _consumer;

        public when_consuming_bmw_finance_with_account_number()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _request = new[] { new BmwFinanceRequestWithAccountNumber(),  };
            _response = new Collection<IPointToLaceProvider>();
        }

        public override void Observe()
        {
            _consumer = new BmwFinanceDataProvider(_request, null, null, _command);
            _consumer.CallSource(_response);
        }

        [Observation]
        public void bmw_finance_response_from_consumer_must_not_be_empty()
        {
            _response.OfType<IProvideDataFromBmwFinance>().First().Finances.ShouldNotBeNull();
            _response.OfType<IProvideDataFromBmwFinance>().First().Finances.First().Description.ShouldEqual("VOLVO XC60 T5 EXCEL POWERSHIFT");
            _response.OfType<IProvideDataFromBmwFinance>().First().Finances.First().RegistrationYear.ShouldEqual(2011);
        }
    }
}
