using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.Core.Shared
{
    public sealed class LogCommandTypes : ILogCommandTypes
    {
        private readonly ISendCommandToBus _commands;
        private readonly DataProviderCommandSource _dataProviderName;
        private readonly DataProviderNoRecordState _billNoRecords;
        private static readonly ILog Log = LogManager.GetLogger<LogCommandTypes>();
        private readonly IAmDataProvider _dataProvider;
        private readonly DataProviderStopWatch _executeWatch;
        private readonly DataProviderStopWatch _requestWatch;

        private LogCommandTypes(ISendCommandToBus commands, DataProviderCommandSource dataProviderName,
            IAmDataProvider dataProvider,DataProviderNoRecordState billNoRecords)
        {
            _commands = commands;
            _dataProviderName = dataProviderName;
            _dataProvider = dataProvider;
            _executeWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProviderName);
            _requestWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProviderName);
            _billNoRecords = billNoRecords;
        }

        private LogCommandTypes(ISendCommandToBus commands, DataProviderCommandSource dataProviderName,DataProviderNoRecordState billNoRecords)
        {
            _commands = commands;
            _dataProviderName = dataProviderName;
            _executeWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProviderName);
            _requestWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProviderName);
            _billNoRecords = billNoRecords;
        }

        public static LogCommandTypes ForDataProvider(ISendCommandToBus commands, DataProviderCommandSource dataProviderName,
            IAmDataProvider dataProvider,DataProviderNoRecordState billNoRecords)
        {
            return new LogCommandTypes(commands,dataProviderName,dataProvider,billNoRecords);
        }

        public static LogCommandTypes ForEntryPoint(ISendCommandToBus commands, DataProviderNoRecordState billNoRecords)
        {
            return new LogCommandTypes(commands, DataProviderCommandSource.EntryPoint,billNoRecords);
        }

        public void LogSecurity(object payload, object metadata)
        {
            SendAsyc(CommandType.Security, payload, metadata);
        }

        public void LogConfiguration(object payload, object metadata)
        {
            SendAsyc(CommandType.Configuration, payload, metadata);
        }

        public void LogTransformation(object payload, object metadata)
        {
            SendAsyc(CommandType.Transformation, payload, metadata);
        }

        public void LogFault(object payload, object metadata)
        {
            SendAsyc(CommandType.Error, payload, metadata);
        }

        public void LogRequest(ConnectionTypeIdentifier connection, object payload, DataProviderNoRecordState billNoRecords, string referenceNumber)
        {
            SendRequestAsync(
                new DataProviderIdentifier(_dataProviderName, DataProviderAction.Request, DataProviderResponseState.Successful,billNoRecords)
                    .SetPrice(_dataProvider), connection, payload, _requestWatch,referenceNumber);

        }

        public void LogResponse(DataProviderResponseState state, ConnectionTypeIdentifier connection, object payload, DataProviderNoRecordState billNoRecords, string referenceNumber)
        {
            SendResponseAsync(new DataProviderIdentifier(_dataProviderName, DataProviderAction.Response, state,billNoRecords)
                .SetPrice(
                    _dataProvider), connection, payload, _requestWatch, referenceNumber);
        }

        public void LogEntryPointRequest(ICollection<IPointToLaceRequest> request,DataProviderNoRecordState billNoRecords)
        {
            SendEntryPointRequestAsync(request,billNoRecords);
        }

        public void LogEntryPointResponse(object payload, DataProviderResponseState state, ICollection<IPointToLaceRequest> request, DataProviderNoRecordState billNoRecords)
        {
            SendEntryPointResponseAsync(payload, state, request,billNoRecords);
        }

        public void LogBegin(object payload)
        {
            SendBeginAsyc(payload);
        }

        public void LogEnd(object payload)
        {
              SendEndAsyc(payload);
        }

        private void SendBeginAsyc(object payload)
        {
            try
            {
                Task.Run(() =>
                {
                    try
                    {
                        _commands.Workflow.Begin(payload, _executeWatch, _dataProviderName, _billNoRecords);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("An error occured sending a request to the bus because of {0}", ex, ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occured sending a request to the bus because of {0}",ex, ex.Message);
            }
        }

        private void SendEndAsyc(object payload)
        {
            try
            {

                Task.Run(() =>
                {
                    try
                    {
                        _commands.Workflow.End(payload, _executeWatch, _dataProviderName, _billNoRecords);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("An error occured sending a request to the bus because of {0}", ex, ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occured sending a request to the bus because of {0}",ex, ex.Message);
            }
        }


        private void SendAsyc(CommandType commandType, object payload, object metadata)
        {
            try
            {

                Task.Run(() =>
                {
                    try
                    {
                        _commands.Workflow.Send(commandType, payload, metadata, _dataProviderName, _billNoRecords);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("An error occured sending a command to the bus because of {0}", ex, ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occured sending a command to the bus because of {0}",ex, ex.Message);
            }
        }

        private void SendRequestAsync(DataProviderIdentifier dataProvider, ConnectionTypeIdentifier connection, object payload, DataProviderStopWatch stopWatch, string referenceNumber)
        {
            try
            {

                Task.Run(() =>
                {
                    try
                    {
                        _commands.Workflow.DataProviderRequest(dataProvider, connection, payload, stopWatch,referenceNumber);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("An error occured sending a request to the bus because of {0}", ex, ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occured sending a request to the bus because of {0}",ex, ex.Message);
            }
        }

        private void SendResponseAsync(DataProviderIdentifier dataProvider, ConnectionTypeIdentifier connection, object payload, DataProviderStopWatch stopWatch, string referenceNumber)
        {
            try
            {
                
                Task.Run(() =>
                {
                    try
                    {
                        _commands.Workflow.DataProviderResponse(dataProvider, connection, payload, stopWatch,referenceNumber);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("An error occured sending a response to the bus because of {0}", ex, ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occured sending a response to the bus because of {0}",ex, ex.Message);
            }
        }

        private void SendEntryPointRequestAsync(ICollection<IPointToLaceRequest> request,DataProviderNoRecordState billNoRecords)
        {
            try
            {

                Task.Run(() =>
                {
                    try
                    {
                        _commands.Workflow.EntryPointRequest(request, _requestWatch,billNoRecords);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("An error occured sending entry point request to the bus because of {0}", ex, ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occured sending entry point request to the bus because of {0}",ex, ex.Message);
            }
        }

        private void SendEntryPointResponseAsync(object payload, DataProviderResponseState state,
            ICollection<IPointToLaceRequest> request, DataProviderNoRecordState billNoRecords)
        {
            try
            {

                Task.Run(() =>
                {
                    try
                    {
                        _commands.Workflow.EntryPointResponse(payload, _requestWatch, state, request, billNoRecords);
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("An error occured sending entry point request to the bus because of {0}", ex, ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occured sending entry point request to the bus because of {0}",ex, ex.Message);
            }
        }
    }
}
