using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Rgt;
using Lace.Domain.DataProviders.RgtVin;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Responses;
using Lace.Test.Helper.Mothers.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_rgt_data_provider : Specification
    {
        private readonly ILaceRequest _request;
        private readonly ISendMonitoringCommandsToBus _monitoring;
        private readonly ICollection<IPointToLaceProvider> _response;
        private RgtDataProvider _provider;


        public when_consuming_rgt_data_provider()
        {
            _monitoring = MonitoringBusBuilder.ForRgtCommands(Guid.NewGuid());
            _request = new LicensePlateNumberRgtOnlyRequest();
            _response = new LaceResponseBuilder().WithIvidResponseHandled();
        }

        public override void Observe()
        {
            _provider = new RgtDataProvider(_request, null, null, _monitoring);
            _provider.CallSource(_response);
        }


        [Observation]
        public void rgt_consumer_must_be_handled()
        {
            _response.OfType<IProvideDataFromRgt>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void rgt_response_from_consumer_must_not_be_null()
        {
            _response.OfType<IProvideDataFromRgt>().First().ShouldNotBeNull();
        }

        [Observation]
        public void rgt_consumer_next_source_must_be_null()
        {
            _provider.Next.ShouldBeNull();
        }

        [Observation]
        public void rgt_consumer_fallback_source_must_be_null()
        {
            _provider.FallBack.ShouldBeNull();
        }
    }
}
