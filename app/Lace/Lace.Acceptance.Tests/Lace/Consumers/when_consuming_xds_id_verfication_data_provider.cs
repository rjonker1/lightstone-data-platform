using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataProviders.Xds.IdentityVerification;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_xds_id_verfication_data_provider : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private XdsIdentityVerificationDataProvider _provider;

        public when_consuming_xds_id_verfication_data_provider()
        {
            _command = MonitoringBusBuilder.ForXdsIdentityVerificationCommands(Guid.NewGuid());
            _request = new XdsRequestBuilder().ForIdVerificaitonWithIdNumber();
            _response = new Collection<IPointToLaceProvider>();
        }

        public override void Observe()
        {
            _provider = new XdsIdentityVerificationDataProvider(_request, null, null, _command);
            _provider.CallSource(_response);
        }

        [Observation]
        public void rgt_consumer_must_be_handled()
        {
            _response.OfType<IProvideDataFromXdsIdentityVerification>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void rgt_response_from_consumer_must_not_be_null()
        {
            _response.OfType<IProvideDataFromXdsIdentityVerification>().First().IdentityVerifications.Count().ShouldEqual(1);
            _response.OfType<IProvideDataFromXdsIdentityVerification>().First().IdentityVerifications.First().FirstName.ShouldEqual("RUDI");
            _response.OfType<IProvideDataFromXdsIdentityVerification>().First().IdentityVerifications.First().HomeAffairsId.ShouldEqual("61180391");
        }
    }
}
