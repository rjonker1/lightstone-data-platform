using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Fakes.Lace.Consumer;
using NServiceBus;

namespace Lace.Test.Helper.Fakes.Lace.Builder
{
    public class FakeSourceSpecification
    {
        private readonly Func<Action<ICollection<IPointToLaceRequest>, IBus, ICollection<IPointToLaceProvider>, Guid>>
            _licenseNumberRequestSpecification =
                () =>
                    (request, bus, response, requestId) =>
                        new FakeIvidSourceExecution(request,
                            new FakeLightstoneSourceExecution(request,
                                new FakeIvidTitleHolderSourceExecution(request,
                                    new FakeRgtVinSourceExecution(request,
                                        new FakeRgtSourceExecution(request,
                                            new FakeAudatexSourceExecution(request, null, null,
                                                MonitoirngCommandSenderBuilder.ForAudatexCommands(bus, requestId,
                                                    (int) ExecutionOrder.Sixth)), null,
                                            MonitoirngCommandSenderBuilder.ForRgtCommands(bus, requestId,
                                                (int) ExecutionOrder.Fifth)), null,
                                        MonitoirngCommandSenderBuilder.ForRgtVinCommands(bus, requestId,
                                            (int) ExecutionOrder.Fourth)), null,
                                    MonitoirngCommandSenderBuilder.ForIvidTitleHolderCommands(bus, requestId,
                                        (int) ExecutionOrder.Third)), null,
                                MonitoirngCommandSenderBuilder.ForLighstoneCommands(bus, requestId, (int) ExecutionOrder.Second)),
                            null, MonitoirngCommandSenderBuilder.ForIvidCommands(bus, requestId, (int) ExecutionOrder.First))
                            .CallSource(response);


        private readonly Func<Action<ICollection<IPointToLaceRequest>, IBus, ICollection<IPointToLaceProvider>, Guid>>
            _driversLicenseDecryptionRequestSpecification =
                () =>
                    (request, bus, response, requestId) =>
                        new FakeSignioDataProvider(request, null, null,
                            new SendSignioCommands(bus, requestId, (int)ExecutionOrder.First)).CallSource(response);


        private readonly Func<Action<ICollection<IPointToLaceRequest>, IBus, ICollection<IPointToLaceProvider>, Guid>>
            _ficaRequestSpecification =
                () =>
                    (request, bus, response, requestId) =>
                        new FakePCubedDataProvider(request, null, null,
                            new SendPCubedCommands(bus, requestId, (int)ExecutionOrder.First)).CallSource(response);


        public
            IEnumerable
                <
                    KeyValuePair
                        <string, Action<ICollection<IPointToLaceRequest>, IBus, ICollection<IPointToLaceProvider>, Guid>>>
            Specifications
        {
            get
            {
                return new Dictionary
                    <string, Action<ICollection<IPointToLaceRequest>, IBus, ICollection<IPointToLaceProvider>, Guid>>()
                {
                    {
                        "License plate search", _licenseNumberRequestSpecification()
                    },
                    {
                        "License Scan", _driversLicenseDecryptionRequestSpecification()
                    },
                    {
                        "Fica", _ficaRequestSpecification()
                    }
                };
            }
        }
    }
}
