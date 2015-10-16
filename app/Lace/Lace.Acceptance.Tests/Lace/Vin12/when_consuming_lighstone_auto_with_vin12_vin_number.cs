using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Domain.DataProviders.Vin12;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Mothers.Requests.Vin12Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Vin12
{
    public class when_consuming_lighstone_auto_with_vin12_vin_number : Specification
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private readonly ISendCommandToBus _vin12Commands;
        private readonly ICollection<IPointToLaceProvider> _response;
        private LightstoneAutoDataProvider _consumer;


        public when_consuming_lighstone_auto_with_vin12_vin_number()
        {
            _command = MonitoringBusBuilder.ForLightstoneCommands(Guid.NewGuid());
            _vin12Commands = MonitoringBusBuilder.ForVin12Commands(Guid.NewGuid());
            _request = new[] {new LighstoneAutoVin12Request()};
            _response = new Collection<IPointToLaceProvider>();
        }

        public override void Observe()
        {
            _consumer = new LightstoneAutoDataProvider(_request, null, new Vin12DataProvider(_request, null, null, _vin12Commands), _command);
            _consumer.CallSource(_response);
        }

        [Observation]
        public void then_vin12_response_from_consumer_must_not_be_empty()
        {
            _response.Count(w => w.Handled).ShouldEqual(2);

            _response.OfType<IProvideDataFromLightstoneAuto>().First().Handled.ShouldBeTrue();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ShouldNotBeNull();
            _response.OfType<IProvideDataFromLightstoneAuto>().First().ResponseState.ShouldEqual(DataProviderResponseState.NoRecords);

            _response.OfType<IProvideDataFromVin12>().First().Vin12Information.ShouldNotBeNull();
            _response.OfType<IProvideDataFromVin12>().First().ResponseState.ShouldEqual(DataProviderResponseState.VinShort);
            _response.OfType<IProvideDataFromVin12>().First().Vin12Information.First().BodyShape.ShouldNotBeEmpty();
            _response.OfType<IProvideDataFromVin12>().First().Vin12Information.Count().ShouldEqual(24);
        }
    }
}
