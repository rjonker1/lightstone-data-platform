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

        public DataProviderQueueFunctions Queue { get; private set; }

        public DataProviderCommands(object request, IHaveQueueActions actions, Guid aggregateId, bool setupAndTearDown = true)
        {
            _request = request;
            _aggregateId = aggregateId;
            _actions = actions;
            _setupAndTearDown = setupAndTearDown;
        }

        public DataProviderCommands ForIvid()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.Ivid, _actions, _aggregateId,
                _setupAndTearDown);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForIvidCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessageWithRequest(DataProviderRequestBuilder.ForIvidLicensePlateSearch())
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
                    new {ContextMessage = "Ivid Data Provider Credentials"})
                .StartCallingMessageWithDataProviderSourceRequest(DataProviderSourceRequestBuilder.ForIvid())
                .FaultCallingMessage(new {NoRequestReceived = "No response received from Ivid Data Provider"})
                .EndCallingMessage(DataProviderResponseBuilder.FromIvid())
                .TransformationMessage(DataProviderTransformationBuilder.ForIvid(),
                    new {TrasformationMetaData = "Transforming Response from Ivid"})
                .EndingDataProviderWithResponse(ResponseFromDataProvider.FromIvid());

            return this;
        }

        public DataProviderCommands ForAudatex()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.Audatex, _actions,
                _aggregateId, _setupAndTearDown);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForAudatexCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessageWithRequest(DataProviderRequestBuilder.ForAudatexLicensePlateSearch())
                .ConfigurationMessage(DataProviderConfigurationBuiler.ForAudatex())
                .StartCallingMessageWithDataProviderSourceRequest(DataProviderSourceRequestBuilder.ForAudatex())
                .FaultCallingMessage(new {NoRequestReceived = "No response received from Audatex Data Provider"})
                .EndCallingMessage(DataProviderResponseBuilder.FromAudatex())
                .TransformationMessage(DataProviderTransformationBuilder.ForAudatex(),
                    new {TrasformationMetaData = "Transforming Response from Audatex"})
                .EndingDataProviderWithResponse(ResponseFromDataProvider.ForAudatex());

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
                .StartingDataProviderMessageWithRequest(DataProviderRequestBuilder.ForIvidTitleHolderLicensePlateSearch())
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
                .StartCallingMessageWithDataProviderSourceRequest(DataProviderSourceRequestBuilder.ForIvidTitleHolder())
                .FaultCallingMessage(
                   new { NoRequestReceived = "No response received from Ivid Title Holder Data Provider" })
                .EndCallingMessage(DataProviderResponseBuilder.FromIvidTitleHolder())
                .TransformationMessage(DataProviderTransformationBuilder.ForIvidTitleHolder(),
                    new { TrasformationMetaData = "Transforming Response from Ivid Title Holder" })
                .EndingDataProviderWithResponse(ResponseFromDataProvider.FromIvidTitleHolder());
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
                .StartingDataProviderMessageWithRequest(DataProviderRequestBuilder.ForLightstoneLicensePlateSearch())
                //.ConfigurationMessage)
                //.SecurityMessage(DataProviderConfigurationBuiler.ForAudatex(), null)
                .StartingDataProviderMessageWithRequest(DataProviderSourceRequestBuilder.ForLightstone())
                .FaultCallingMessage(new { NoRequestReceived = "No response received from Lightstone Data Provider" })
                .EndCallingMessage(DataProviderResponseBuilder.FromLightstone())
                .TransformationMessage(DataProviderTransformationBuilder.ForLightstone(),
                    new { TrasformationMetaData = "Transforming Response from Lightstone" })
                .EndingDataProviderWithResponse(ResponseFromDataProvider.FromLighstone());
            return this;
        }

        public DataProviderCommands ForRgt()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.Rgt, _actions, _aggregateId, _setupAndTearDown);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForRgtCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessageWithRequest(DataProviderRequestBuilder.ForRgtLicensePlateSearch())
                .StartCallingMessageWithDataProviderSourceRequest(DataProviderSourceRequestBuilder.ForRgt())
                .FaultCallingMessage(new { NoRequestReceived = "No response received from Rgt Data Provider" })
                .EndCallingMessage(DataProviderResponseBuilder.FromRgt())
                .TransformationMessage(DataProviderTransformationBuilder.ForRgt(),
                    new { TrasformationMetaData = "Transforming Response from Rgt" })
                .EndingDataProviderWithResponse(ResponseFromDataProvider.FromRgt());
            return this;
        }

        public DataProviderCommands ForRgtVin()
        {
            var queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.RgtVin, _actions, _aggregateId, _setupAndTearDown);
            queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForRgtVinCommands(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessageWithRequest(DataProviderRequestBuilder.ForRgtVinLicensePlateSearch())
                .ConfigurationMessage(new { VinNumber = "AHT31UNK408007735" })
                //.SecurityMessage()
                .StartCallingMessageWithDataProviderSourceRequest(DataProviderSourceRequestBuilder.ForRgtVin())
                .FaultCallingMessage(new { NoRequestReceived = "No VINs were received" })
                .EndCallingMessage(DataProviderResponseBuilder.FromRgtVin())
                .TransformationMessage(DataProviderTransformationBuilder.ForRgtVin(),
                    new { TrasformationMetaData = "Transforming Response from Rgt Vin" })
                .EndingDataProviderWithResponse(ResponseFromDataProvider.FromRgtVin());
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
                .EndingDataProviderWithResponse(ResponseFromDataProvider.ForVViProduct());
            return this;
        }

        public DataProviderCommands ForEntryPointStart()
        {
            Queue = new DataProviderQueueFunctions(_request, DataProviderCommandSource.EntryPoint, _actions,
                _aggregateId, _setupAndTearDown);
            Queue.TearDown()
                .Setup()
                .InitBus(BusBuilder.ForEntryPoint(_aggregateId))
                .InitStopWatch()
                .StartingDataProviderMessage();
            return this;
        }

        public DataProviderCommands ForEntryPointEnd()
        {
            Queue.EndingDataProviderWithResponse(ResponseFromDataProvider.ForVViProduct());
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
