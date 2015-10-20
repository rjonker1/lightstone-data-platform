using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using DataProviders.MMCode;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Domain.DataProviders.Rgt;
using Workflow.Lace.Messages.Shared;

namespace Lace.Domain.Infrastructure.EntryPoint.Specification
{
    public static class CarIdSpecification
    {
        public static readonly Func<Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>
            Chain = () => (request, bus, response, requestId) =>
                        new LightstoneAutoDataProvider(request,new RgtDataProvider(request,new MmCodeDataProvider(request, null, null,
                                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.MMCode_E_DB)), null,
                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoVIN12_I_DB)), null,
                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoCarStats_I_DB)).CallSource(response);
    }
}