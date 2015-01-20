using System;
using DataPlatform.Shared.Enums;
using Monitoring.Queuing.Contracts;
using Monitoring.Test.Helper.Mothers;
using Monitoring.Test.Helper.Queues;

namespace Monitoring.Test.Helper.Builder
{
    public class DataProviderCommands
    {
        private readonly object _request;

        private readonly Guid _aggregateId;
        private readonly IHaveQueueActions _actions;
        private readonly bool _setupAndTearDown;

        public DataProviderCommands(object request, IHaveQueueActions actions, Guid aggregateId, bool setupAndTearDown = true)
        {
            this._request = request;
            this._aggregateId = aggregateId;
            this._actions = actions;
            _setupAndTearDown = setupAndTearDown;
        }

        public DataProviderCommands ForIvid()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.Ivid, _actions, _aggregateId, _setupAndTearDown);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForIvidCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessage()
                .ConfigurationMessage(DataProviderConfigurationBuiler.ForIvid())
                .SecurityMessage(new
                {
                    Credentials =
                        new
                        {
                            UserName = "CARSTATS-CARSTATS",
                            Password = "8B5Jk3Q66"
                        }
                },
                    new { ContextMessage = "Ivid Data Provider Credentials" })
                .StartCallingMessage()
                .FaultCallingMessage(new { NoRequestReceived = "No response received from Ivid Data Provider" })
                .EndCallingMessage(DataProviderResponseBuilder.FromIvid())
                .TransformationMessage(DataProviderTransformationBuilder.ForIvid(),
                    new { TrasformationMetaData = "Transforming Response from Ivid" })
                .EndingDataProvider();

            return this;
        }

        public DataProviderCommands ForAudatex()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.Audatex, _actions, _aggregateId, _setupAndTearDown);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForAudatexCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessage()
                .ConfigurationMessage(DataProviderConfigurationBuiler.ForAudatex())
                //.SecurityMessage(DataProviderConfigurationBuiler.ForAudatex(), null)
                .StartCallingMessage()
                .FaultCallingMessage(new { NoRequestReceived = "No response received from Audatex Data Provider" })
                .EndCallingMessage(DataProviderResponseBuilder.FromAudatex())
                .TransformationMessage(DataProviderTransformationBuilder.ForAudatex(), new { TrasformationMetaData = "Transforming Response from Audatex" })
                .EndingDataProvider();

            return this;
        }

        public DataProviderCommands ForIvidTitleHolder()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.IvidTitleHolder, _actions,
                _aggregateId, _setupAndTearDown);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForIvidTitleHolderCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessage()
                .ConfigurationMessage(DataProviderConfigurationBuiler.ForIvidTitleHolder())
                .SecurityMessage(new
                {
                    Credentials =
                        new
                        {
                            UserName = "CARSTATS-CARSTATS",
                            Password = "8B5Jk3Q66"
                        }
                },
                    new { ContextMessage = "Ivid Title Holder Data Provider Credentials" })
                .StartCallingMessage()
                .FaultCallingMessage(
                    new { NoRequestReceived = "No response received from Ivid Title Holder Data Provider" })
                .EndCallingMessage(DataProviderResponseBuilder.FromIvidTitleHolder())
                .TransformationMessage(DataProviderTransformationBuilder.ForIvidTitleHolder(),
                    new { TrasformationMetaData = "Transforming Response from Ivid Title Holder" })
                .EndingDataProvider();
            return this;
        }

        public DataProviderCommands ForLightstone()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.Audatex, _actions,
              _aggregateId, _setupAndTearDown);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForLightstoneCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessage()
                //.ConfigurationMessage)
                //.SecurityMessage(DataProviderConfigurationBuiler.ForAudatex(), null)
                .StartCallingMessage()
                .FaultCallingMessage(new { NoRequestReceived = "No response received from Lightstone Data Provider" })
                .EndCallingMessage(DataProviderResponseBuilder.FromLightstone())
                .TransformationMessage(DataProviderTransformationBuilder.ForLightstone(),
                    new { TrasformationMetaData = "Transforming Response from Lightstone" })
                .EndingDataProvider();
            return this;
        }

        public DataProviderCommands ForRgt()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.Rgt, _actions, _aggregateId, _setupAndTearDown);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForRgtCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessage()
                //.ConfigurationMessage(DataProviderConfigurationBuiler.ForIvid())
                //.SecurityMessage(new
                //{
                //    Credentials =
                //        new
                //        {
                //            UserName = "CARSTATS-CARSTATS",
                //            Password = "8B5Jk3Q66"
                //        }
                //},
                //    new {ContextMessage = "Ivid Data Provider Credentials"})
                .StartCallingMessage()
                .FaultCallingMessage(new { NoRequestReceived = "No response received from Rgt Data Provider" })
                .EndCallingMessage(DataProviderResponseBuilder.FromRgt())
                .TransformationMessage(DataProviderTransformationBuilder.ForRgt(),
                    new { TrasformationMetaData = "Transforming Response from Rgt" })
                .EndingDataProvider();
            return this;
        }

        public DataProviderCommands ForRgtVin()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.RgtVin, _actions, _aggregateId, _setupAndTearDown);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForRgtVinCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessage()
                .ConfigurationMessage(new { VinNumber = "AHT31UNK408007735" })
                //.SecurityMessage()
                .StartCallingMessage()
                .FaultCallingMessage(new { NoRequestReceived = "No VINs were received" })
                .EndCallingMessage(DataProviderResponseBuilder.FromRgtVin())
                .TransformationMessage(DataProviderTransformationBuilder.ForRgtVin(),
                    new { TrasformationMetaData = "Transforming Response from Rgt Vin" })
                .EndingDataProvider();
            return this;
        }

        public DataProviderCommands ForEntryPoint()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.EntryPoint, _actions,
                _aggregateId, _setupAndTearDown);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForEntryPoint(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessage()
                .EndingDataProvider();
            return this;
        }

        public DataProviderCommands SetupAndTearDownOnly()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.EntryPoint, _actions, _aggregateId);
            queue.TearDown()
                .Setup();
            return this;
        }
    }
}
