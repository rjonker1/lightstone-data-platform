using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
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
        private readonly Func<Action<ILaceRequest, IBus, IProvideResponseFromLaceDataProviders, Guid>>
            _licenseNumberRequestSpecification =
                () =>
                    (request, bus, response, requestId) =>
                        new FakeIvidSourceExecution(request,
                            new FakeLightstoneSourceExecution(request,
                                new FakeIvidTitleHolderSourceExecution(request,
                                    new FakeRgtVinSourceExecution(request,
                                        new FakeRgtSourceExecution(request,
                                            new FakeAudatexSourceExecution(request, null, null,
                                                CommandSenderBuilder.ForAudatexCommands(bus, requestId,
                                                    (int) ExecutionOrder.Sixth)), null,
                                            CommandSenderBuilder.ForRgtCommands(bus, requestId,
                                                (int) ExecutionOrder.Fifth)), null,
                                        CommandSenderBuilder.ForRgtVinCommands(bus, requestId,
                                            (int) ExecutionOrder.Fourth)), null,
                                    CommandSenderBuilder.ForIvidTitleHolderCommands(bus, requestId,
                                        (int) ExecutionOrder.Third)), null,
                                CommandSenderBuilder.ForLighstoneCommands(bus, requestId, (int) ExecutionOrder.Second)),
                            null, CommandSenderBuilder.ForIvidCommands(bus, requestId, (int) ExecutionOrder.First))
                            .CallSource(response);


        private readonly Func<Action<ILaceRequest, IBus, IProvideResponseFromLaceDataProviders, Guid>>
            _driversLicenseDecryptionRequestSpecification =
                () =>
                    (request, bus, response, requestId) =>
                        new FakeSignioDataProvider(request, null, null,
                            new SendSignioCommands(bus, requestId, (int)ExecutionOrder.First)).CallSource(response);


        private readonly Func<Action<ILaceRequest, IBus, IProvideResponseFromLaceDataProviders, Guid>>
            _ficaRequestSpecification =
                () =>
                    (request, bus, response, requestId) =>
                        new FakePCubedDataProvider(request, null, null,
                            new SendPCubedCommands(bus, requestId, (int)ExecutionOrder.First)).CallSource(response);


        public
            IEnumerable
                <
                    KeyValuePair
                        <string, Action<ILaceRequest, IBus, IProvideResponseFromLaceDataProviders, Guid>>>
            Specifications
        {
            get
            {
                return new Dictionary
                    <string, Action<ILaceRequest, IBus, IProvideResponseFromLaceDataProviders, Guid>>()
                {
                    {
                        "License plate search", _licenseNumberRequestSpecification()
                    },
                    {
                        "Drivers License", _driversLicenseDecryptionRequestSpecification()
                    },
                    {
                        "Fica", _ficaRequestSpecification()
                    }
                };
            }
        }
    }
}
