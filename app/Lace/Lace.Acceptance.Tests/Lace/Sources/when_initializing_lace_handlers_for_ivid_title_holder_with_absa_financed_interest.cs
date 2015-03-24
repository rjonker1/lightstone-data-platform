using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.IvidTitleHolder;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Responses;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources
{
    public class when_initializing_lace_handlers_for_ivid_title_holder_with_absa_financed_interest : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ICollection<IPointToLaceProvider> _response;
        private readonly ISendMonitoringCommandsToBus _monitoring;
        private readonly IExecuteTheDataProviderSource _dataProvider;

        public when_initializing_lace_handlers_for_ivid_title_holder_with_absa_financed_interest()
        {
            _monitoring = MonitoringBusBuilder.ForIvidTitleHolderCommands(Guid.NewGuid());
            _request = new LicensePlateRequestBuilder().ForIvidTitleHolderWithAbsaFinancedInterest();
            _response = new LaceResponseBuilder().WithIvidResponseAndFinancedInterestVin();
            _dataProvider = new IvidTitleHolderDataProvider(_request, null, null, _monitoring);
        }

        public override void Observe()
        {
            _dataProvider.CallSource(_response);
        }

        [Observation]
        public void ivid_title_holder_with_absa_financed_interest_response_should_be_handled()
        {
            _response.OfType<IProvideDataFromIvidTitleHolder>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void ivid_title_holder_with_absa_financed_interest_response_shuould_not_be_null()
        {
            _response.OfType<IProvideDataFromIvidTitleHolder>().First().ShouldNotBeNull();
        }

        [Observation]
        public void ivid_title_holder_with_absa_financed_interest_should_be_available()
        {
            _response.OfType<IProvideDataFromIvidTitleHolder>().First().FinancialInterestAvailable.ShouldBeTrue();
        }

    }
}
