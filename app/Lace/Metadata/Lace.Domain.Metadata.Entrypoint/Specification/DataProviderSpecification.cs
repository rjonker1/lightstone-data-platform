using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Metadata.DataProviders.Ivid;
using Lace.Domain.Metadata.DataProviders.IvidTitleHolder;
using Lace.Domain.Metadata.DataProviders.Lighstone.Property;
using Lace.Domain.Metadata.DataProviders.Lightstone.Business.Company;
using Lace.Domain.Metadata.DataProviders.Lightstone.Business.Director;
using Lace.Domain.Metadata.DataProviders.LightstoneAuto;
using Lace.Domain.Metadata.DataProviders.Rgt;
using Lace.Domain.Metadata.DataProviders.RgtVin;
using Lace.Domain.Metadata.DataProviders.Signio.DriversLicense;
using Workflow.Lace.Messages.Shared;

namespace Lace.Domain.Metadata.EntryPoint.Specification
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
                                                    new LightstoneCompanyDataProvider(request,
                                                        new LightstoneDirectorDataProvider(request, null, null,
                                                            CommandSender.InitCommandSender(bus, requestId,
                                                                DataProviderCommandSource.LightstoneBusinessDirector)), null,
                                                        CommandSender.InitCommandSender(bus, requestId,
                                                            DataProviderCommandSource.LightstoneBusinessCompany)), null,
                                                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneProperty)),
                                                null,
                                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.SignioDecryptDriversLicense)),
                                            null,
                                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LsaSpecifications)), null,
                                        CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.VinMaster)), null,
                                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IvidTitleHolder)), null,
                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneAuto)), null,
                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Ivid))
                            .CallSource(response);

    }
}