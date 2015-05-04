using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Fakes.Lace.Consumer;
using Workflow.Lace.Domain;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Shared;

namespace Lace.Test.Helper.Fakes.Lace.Builder
{
    public class FakeSourceSpecification
    {
        public static readonly Func<Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>
            Chain =
                () =>
                    (request, bus, response, requestId) =>
                        new FakeIvidSourceExecution(request,
                            new FakeLightstoneSourceExecution(request,
                                new FakeIvidTitleHolderSourceExecution(request,
                                    new FakeRgtVinSourceExecution(request,
                                        new FakeRgtSourceExecution(request,
                                            new FakeSignioDataProvider(request, null, null,
                                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.SignioDecryptDriversLicense)),null,
                                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Rgt)), null,
                                        CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.RgtVin)), null,
                                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IvidTitleHolder)), null,
                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneAuto)),
                            null, CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Ivid))
                            .CallSource(response);


        private readonly Func<Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>
            _driversLicenseDecryptionRequestSpecification =
                () =>
                    (request, bus, response, requestId) =>
                        new FakeSignioDataProvider(request, null, null,
                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.SignioDecryptDriversLicense)).CallSource(response);


        private readonly Func<Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>
            _ficaRequestSpecification =
                () =>
                    (request, bus, response, requestId) =>
                        new FakePCubedDataProvider(request, null, null,
                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.PCubedFica)).CallSource(response);

        //public static Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid> Builder
        //{
        //    get
        //    {
        //        return Chain();
        //    }
        //}

        //public
        //    IEnumerable
        //        <
        //            KeyValuePair
        //                <string, Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>>
        //    Specifications
        //{
        //    get
        //    {
        //        return new Dictionary
        //            <string, Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>()
        //        {
        //            {
        //                "License plate search", _licenseNumberRequestSpecification()
        //            },
        //            {
        //                "License Scan", _driversLicenseDecryptionRequestSpecification()
        //            },
        //            {
        //                "Fica", _ficaRequestSpecification()
        //            }
        //        };
        //    }
        //}
    }
}
