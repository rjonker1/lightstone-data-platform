using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Mothers.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Consumers
{
    public class when_consuming_ivid_data_provider_with_license_number_mismatch : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ICollection<IPointToLaceProvider> _response;
        private IvidDataProvider _consumer;

        //samples
        //        Request     Response
        //        2SNAZI4GP   BP48JXGP    
        //        yxn332gp    DZD309FS    
        //        HJF622MP    HHS608EC    
        //        Bz24tggp    ND509499
        //        HLX051GP

        public when_consuming_ivid_data_provider_with_license_number_mismatch()
        {
            _command = MonitoringBusBuilder.ForIvidCommands(Guid.NewGuid());
            _request = new[] { new LicensePlateNumberIvidMisMatchRequest() };
            _response = new Collection<IPointToLaceProvider>();
        }

        public override void Observe()
        {
            _consumer = new IvidDataProvider(_request, null, null,_command);
            _consumer.CallSource(_response);
        }


        [Observation]
        public void ivid_consumer_must_be_handled()
        {
            _response.OfType<IProvideDataFromIvid>().First().Handled.ShouldBeTrue();
        }

        [Observation]
        public void ivid_response_from_consumer_must_not_be_null()
        {
            _response.OfType<IProvideDataFromIvid>().First().ShouldNotBeNull();
        }

        [Observation]
        public void ivid_consumer_should_have_has_issues_flag_raised()
        {
            _response.OfType<IProvideDataFromIvid>().First().HasIssues.ShouldBeTrue();
        }

        [Observation]
        public void ivid_consumer_should_have_license_mismatch_status_message_raised()
        {
            _response.OfType<IProvideDataFromIvid>().First().ReportStatusMessages.ShouldNotBeNull();
            _response.OfType<IProvideDataFromIvid>().First().HasIssues.ShouldBeTrue();
            _response.OfType<IProvideDataFromIvid>().First().ReportStatusMessages[1].ShouldEqual("The licence plate number for this vehicle has changed. Please check the vehicle carefully.");
        }

        [Observation]
        public void ivid_consumer_should_have_further_investigation_status_raised()
        {
            _response.OfType<IProvideDataFromIvid>().First().ReportStatusMessages.ShouldNotBeNull();
            _response.OfType<IProvideDataFromIvid>().First().HasIssues.ShouldBeTrue();
            _response.OfType<IProvideDataFromIvid>().First().ReportStatusMessages.First().ShouldEqual("Vehicle requires further investigation.  Please contact IVID on (033) 234 4083 or ivid@telkomsa.net");
        }
    }
}
