using System;
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
                                                            DataProviderCommandSource.LSBusinessDirector_E_WS)), null,
                                                    CommandSender.InitCommandSender(bus, requestId,
                                                        DataProviderCommandSource.LSBusinessCompany_E_WS)), null,
                                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoDecryptDriverLic_I_WS)),
                                            null,
                                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoSpecs_I_DB)), null,
                                        CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoVINMaster_I_DB)), null,
                                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IVIDTitle_E_WS)), null,
                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoCarStats_I_DB)),
                            null, CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IVIDVerify_E_WS))
                            .CallSource(response);

    }
}