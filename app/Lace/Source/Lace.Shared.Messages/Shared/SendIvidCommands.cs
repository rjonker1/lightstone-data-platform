using Common.Logging;
using System;
using System.Threading.Tasks;
using DataPlatform.Shared.Enums;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Infrastructure;
using Lace.Shared.Monitoring.Messages.Infrastructure.Dto;
using Lace.Shared.Monitoring.Messages.Infrastructure.Extensions;
using Lace.Shared.Monitoring.Messages.Publisher;
using NServiceBus;


namespace Lace.Shared.Monitoring.Messages.Shared
{
    public class SendIvidCommands : ISendCommandsToBus
    {
        private readonly IPublishCommandMessages _publisher;
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        private readonly int _orderOfExecution;

        private readonly Guid _requestId;

        public SendIvidCommands(IBus bus, Guid requestAggregateId, int orderOfExecution)
        {
            _publisher = new CommandPublisher(bus);
            _requestId = requestAggregateId;
            _orderOfExecution = orderOfExecution;
        }

        public void Begin(dynamic payload, DataProviderStopWatch stopWatch)
        {
            //Begin(payload, new MetadataContainer()).SendToBus(_publisher, _log);
            BusExtensions.SendToBus(Begin(payload, new MetadataContainer()), _publisher, _log);
            stopWatch.Start();
        }

        public void End(dynamic payload, DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();
            //End(payload, new MetadataContainer(stopWatch.ToObject())).SendToBus(_publisher, _log);
            BusExtensions.SendToBus(End(payload, new PerformanceMetadata(stopWatch.ToObject())), _publisher, _log);
        }

        public void StartCall(dynamic payload, DataProviderStopWatch stopWatch)
        {
            //StartCall(payload, new MetadataContainer()).SendToBus(_publisher, _log);
            BusExtensions.SendToBus(StartCall(payload, new MetadataContainer()), _publisher, _log);
            stopWatch.Start();
        }

        public void EndCall(dynamic payload, DataProviderStopWatch stopWatch)
        {
            stopWatch.Stop();
            //EndCall(payload, new MetadataContainer(stopWatch.ToObject())).SendToBus(_publisher, _log);
            BusExtensions.SendToBus(EndCall(payload, new PerformanceMetadata(stopWatch.ToObject())), _publisher, _log);
        }

        public void Send(CommandType commandType, dynamic payload, dynamic metadata)
        {
            SendToBus(payload, metadata, commandType);
        }

        private StartIvidExecution Begin(object payload, MetadataContainer metadata)
        {
            return new StartIvidExecution(_requestId, DataProviderCommandSource.Ivid,
                CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.Ivid),
                payload, metadata, DateTime.UtcNow,
                Category.Performance);

            //var command = new
            //{
            //    StartIvidExecution =
            //        new StartIvidExecution(_requestId, DataProviderCommandSource.Ivid,
            //            CommandDescriptions.StartExecutionDescription(DataProviderCommandSource.Ivid),
            //            payload, metadata, DateTime.UtcNow,
            //            Category.Performance)
            //};

            //var cmd = command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.FirstThing,_orderOfExecution);
            //return cmd;
        }

        private EndIvidExecution End(object payload, object metadata)
        {
            return new EndIvidExecution(_requestId, DataProviderCommandSource.Ivid,
                CommandDescriptions.EndExecutionDescription(DataProviderCommandSource.Ivid),
                payload, metadata, DateTime.UtcNow,
                Category.Performance);

            //var command = new
            //{
            //    EndIvidExcution =
            //        new EndIvidExcution(_requestId, DataProviderCommandSource.Ivid,
            //            CommandDescriptions.EndExecutionDescription(DataProviderCommandSource.Ivid),
            //            payload, metadata, DateTime.UtcNow,
            //            Category.Performance)
            //};

            //return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.FirstThing, _orderOfExecution);
        }

        private StartIvidDataSourceCall StartCall(object payload, MetadataContainer metadata)
        {
            return new StartIvidDataSourceCall(_requestId, DataProviderCommandSource.Ivid,
                CommandDescriptions.StartCallDescription(DataProviderCommandSource.Ivid),
                payload, metadata, DateTime.UtcNow,
                Category.Performance);
            //var command = new
            //{
            //    StartIvidDataSourceCall =
            //        new StartIvidDataSourceCall(_requestId, DataProviderCommandSource.Ivid,
            //            CommandDescriptions.StartCallDescription(DataProviderCommandSource.Ivid),
            //            payload, metadata, DateTime.UtcNow,
            //            Category.Performance)
            //};

            //return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.FirstThing, _orderOfExecution);
        }

        private EndIvidDataSourceCall EndCall(object payload, object metadata)
        {

            return new EndIvidDataSourceCall(_requestId, DataProviderCommandSource.Ivid,
                CommandDescriptions.EndCallDescription(DataProviderCommandSource.Ivid),
                payload, metadata, DateTime.UtcNow,
                Category.Performance);

            //    var command = new
            //    {
            //        EndIvidDataSourceCall =
            //            new EndIvidDataSourceCall(_requestId, DataProviderCommandSource.Ivid,
            //                CommandDescriptions.EndCallDescription(DataProviderCommandSource.Ivid),
            //                payload, metadata, DateTime.UtcNow,
            //                Category.Performance)
            //    };

            //    return command.ObjectToJson().GetCommand(_requestId,(int) DisplayOrder.FirstThing,_orderOfExecution);
        }

        private ThrowError Fault(dynamic payload, MetadataContainer metadata)
        {
            return new ThrowError(_requestId, DataProviderCommandSource.Ivid,
                CommandDescriptions.FaultDescription(DataProviderCommandSource.Ivid), payload, metadata,
                DateTime.UtcNow,
                Category.Fault);
            //var command = new
            //{
            //    ThrowError =
            //        new ThrowError(_requestId, DataProviderCommandSource.Ivid,
            //            CommandDescriptions.FaultDescription(DataProviderCommandSource.Ivid), payload, metadata,
            //            DateTime.UtcNow,
            //            Category.Performance)
            //};

            //return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private RaiseIvidSecurityFlag Security(dynamic payload, MetadataContainer metadata)
        {
            return new RaiseIvidSecurityFlag(_requestId, DataProviderCommandSource.Ivid,
                CommandDescriptions.SecurityDescription(DataProviderCommandSource.Ivid),
                payload,
                metadata, DateTime.UtcNow, Category.Security);
            //var command = new
            //{
            //    IvidSecurityFlag = new RaiseIvidSecurityFlag(_requestId, DataProviderCommandSource.Ivid,
            //        CommandDescriptions.SecurityDescription(DataProviderCommandSource.Ivid),
            //        payload,
            //        metadata, DateTime.UtcNow, Category.Security)
            //};

            //return command.ObjectToJson().GetCommand(_requestId, (int)DisplayOrder.InTheMiddle,_orderOfExecution);
        }

        private ConfigureIvid Configuration(dynamic payload, MetadataContainer metadata)
        {
            return new ConfigureIvid(_requestId, DataProviderCommandSource.Ivid,
                CommandDescriptions.ConfigurationDescription(DataProviderCommandSource.Ivid),
                payload, metadata,
                DateTime.UtcNow, Category.Configuration);
            //var command = new
            //{
            //    ConfigureIvid = new ConfigureIvid(_requestId, DataProviderCommandSource.Ivid,
            //        CommandDescriptions.ConfigurationDescription(DataProviderCommandSource.Ivid),
            //        payload, metadata,
            //        DateTime.UtcNow, Category.Configuration)
            //};

            //return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private TransformIvidResponse Transformation(dynamic payload, MetadataContainer metadata)
        {
            return new TransformIvidResponse(_requestId, DataProviderCommandSource.Ivid,
                CommandDescriptions.TransformationDescription(DataProviderCommandSource.Ivid),
                payload, metadata,
                DateTime.UtcNow, Category.Configuration);
            //var command = new
            //{
            //    TrasformIvidResponse = new TrasformIvidResponse(_requestId, DataProviderCommandSource.Ivid,
            //        CommandDescriptions.TransformationDescription(DataProviderCommandSource.Ivid),
            //        payload, metadata,
            //        DateTime.UtcNow, Category.Configuration)
            //};

            //return command.ObjectToJson().GetCommand(_requestId, (int) DisplayOrder.InTheMiddle, _orderOfExecution);
        }

        private void SendToBus<T>(T payload, dynamic metadata, CommandType type) where T : class
        {
            Task.Run(() =>
            {
                switch (type)
                {
                    case CommandType.Fault:
                        Fault(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.Accounting:
                        break;
                    case CommandType.Configuration:
                        Configuration(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.Security:
                        Security(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.BeginExecution:
                        Begin(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.EndExecution:
                        End(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.StartSourceCall:
                        StartCall(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.EndSourceCall:
                        EndCall(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;
                    case CommandType.Transformation:
                        Transformation(payload, new MetadataContainer(metadata))
                            .SendToBus(_publisher, _log);
                        break;

                }
            });
        }
    }
}
