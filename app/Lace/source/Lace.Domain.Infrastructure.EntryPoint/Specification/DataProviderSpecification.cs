using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid;
using Lace.Domain.DataProviders.IvidTitleHolder;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Domain.DataProviders.Lightstone.Business.Company;
using Lace.Domain.DataProviders.Lightstone.Property;
using Lace.Domain.DataProviders.Rgt;
using Lace.Domain.DataProviders.RgtVin;
using Lace.Domain.DataProviders.Signio.DriversLicense;
using Workflow.Lace.Messages.Shared;

namespace Lace.Domain.Infrastructure.EntryPoint.Specification
{
    public class DataProviderSpecification
    {
        public static readonly Func<Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>
            Chain =
                () =>
                    (request, bus, response, requestId) =>
                        new IvidDataProvider(request,
                            new LightstoneAutoDataProvider(request,
                                new IvidTitleHolderDataProvider(request,
                                    new RgtVinDataProvider(request,
                                        new RgtDataProvider(request,
                                            new SignioDataProvider(request,
                                                new LightstonePropertyDataProvider(request,
                                                    new LightstoneCompanyDataProvider(request, null, null,
                                                        CommandSender.InitCommandSender(bus, requestId,
                                                            DataProviderCommandSource.LightstoneBusinessCompany)), null,
                                                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneProperty)),
                                                null,
                                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.SignioDecryptDriversLicense)),
                                            null,
                                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Rgt)), null,
                                        CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.RgtVin)), null,
                                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IvidTitleHolder)), null,
                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneAuto)), null,
                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Ivid))
                            .CallSource(response);

    }
}