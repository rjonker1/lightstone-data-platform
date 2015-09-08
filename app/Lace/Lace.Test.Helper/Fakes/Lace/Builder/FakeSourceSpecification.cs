﻿using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Fakes.Lace.Consumer;
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
                                            new FakeSignioDataProvider(request,
                                                new FakeLightstoneBusinessCompanyExecution(request,
                                                    new FakeLightstoneBusinessDirectorExecution(request, null, null,
                                                        CommandSender.InitCommandSender(bus, requestId,
                                                            DataProviderCommandSource.LightstoneBusinessDirector)), null,
                                                    CommandSender.InitCommandSender(bus, requestId,
                                                        DataProviderCommandSource.LightstoneBusinessCompany)), null,
                                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.SignioDecryptDriversLicense)),
                                            null,
                                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LsaSpecifications)), null,
                                        CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.VinMaster)), null,
                                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IvidTitleHolder)), null,
                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneAuto)),
                            null, CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Ivid))
                            .CallSource(response);

    }
}