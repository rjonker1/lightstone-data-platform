using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using DataProviders.MMCode;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Bmw.Finance;
using Lace.Domain.DataProviders.Ivid;
using Lace.Domain.DataProviders.IvidTitleHolder;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Domain.DataProviders.Lightstone.Business.Company;
using Lace.Domain.DataProviders.Lightstone.Business.Director;
using Lace.Domain.DataProviders.Lightstone.Consumer.Specifications;
using Lace.Domain.DataProviders.Lightstone.Property;
using Lace.Domain.DataProviders.PCubed.EzScore;
using Lace.Domain.DataProviders.Rgt;
using Lace.Domain.DataProviders.RgtVin;
using Lace.Domain.DataProviders.Signio.DriversLicense;
using Lace.Domain.DataProviders.Vin12;
using Lace.Domain.Infrastructure.Core.Contracts;
using Workflow.Lace.Messages.Shared;

namespace Lace.Domain.Infrastructure.EntryPoint.Specification
{

    public class AllDataProviderSpecification : AbstractSpecificationExecutor, IExecuteSpecification
    {
        private readonly ChainType _chainType;
        public AllDataProviderSpecification(IExecuteSpecification next, ChainType chainType)
            : base(next)
        {
            _chainType = chainType;
        }

        public Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid> Execute()
        {
            return _chainType != ChainType.All ? ExecuteNext() : _chain();
        }

        private readonly Func<Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>
            _chain =
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
                                                        new LightstoneDirectorDataProvider(request,
                                                            new PCubedEzScoreDataProvider(request,
                                                                new ConsumerSpecificationsDataProvider(request,
                                                                    new BmwFinanceDataProvider(request,
                                                                        new MmCodeDataProvider(request, null, null,
                                                                            CommandSender.InitCommandSender(bus, requestId,
                                                                                DataProviderCommandSource.MMCode_E_DB)), null,
                                                                        CommandSender.InitCommandSender(bus, requestId,
                                                                            DataProviderCommandSource.BMWFSTitle_E_DB)), null,
                                                                    CommandSender.InitCommandSender(bus, requestId,
                                                                        DataProviderCommandSource.LSConsumerRepair_E_WS)), null,
                                                                CommandSender.InitCommandSender(bus, requestId,
                                                                    DataProviderCommandSource.PCubedEZScore_E_WS)), null,
                                                            CommandSender.InitCommandSender(bus, requestId,
                                                                DataProviderCommandSource.LSBusinessDirector_E_WS)), null,
                                                        CommandSender.InitCommandSender(bus, requestId,
                                                            DataProviderCommandSource.LSBusinessCompany_E_WS)), null,
                                                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSPropertySearch_E_WS)),
                                                null,
                                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoDecryptDriverLic_I_WS)),
                                            null,
                                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoSpecs_I_DB)), new Vin12DataProvider(request, null, null,
                                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoVIN12_I_DB)),
                                        CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoVINMaster_I_DB)), null,
                                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IVIDTitle_E_WS)),
                                new Vin12DataProvider(request, null, null,
                                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoVIN12_I_DB)),
                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LSAutoCarStats_I_DB)), null,
                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.IVIDVerify_E_WS))
                            .CallSource(response);
    }
}