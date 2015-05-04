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
    public class LogCommandTypes : ILogCommandTypes
    {
        private readonly ISendCommandToBus _commands;
        private readonly DataProviderCommandSource _dataProviderName;
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly DataProviderStopWatch _executeWatch;
        private readonly DataProviderStopWatch _requestWatch;


        private LogCommandTypes(ISendCommandToBus commands, DataProviderCommandSource dataProviderName,
            IAmDataProvider dataProvider)
        {
            _commands = commands;
            _dataProviderName = dataProviderName;
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _executeWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProviderName);
            _requestWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProviderName);
        }

        private LogCommandTypes(ISendCommandToBus commands, DataProviderCommandSource dataProviderName)
        {
            _commands = commands;
            _dataProviderName = dataProviderName;
            _log = LogManager.GetLogger(GetType());
            _executeWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProviderName);
            _requestWatch = new StopWatchFactory().StopWatchForDataProvider(_dataProviderName);
        }

        public static LogCommandTypes ForDataProvider(ISendCommandToBus commands, DataProviderCommandSource dataProviderName,
            IAmDataProvider dataProvider)
        {
            return new LogCommandTypes(commands,dataProviderName,dataProvider);
        }

        public static LogCommandTypes ForEntryPoint(ISendCommandToBus commands)
        {
            return new LogCommandTypes(commands, DataProviderCommandSource.EntryPoint);
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
            SendAsyc(CommandType.Fault, payload, metadata);
        }

        public void LogRequest(ConnectionTypeIdentifier connection, object payload)
        {
            SendRequestAsync(
                new DataProviderIdentifier(_dataProviderName, DataProviderAction.Request, DataProviderState.Successful)
                    .SetPrice(_dataProvider), connection, payload, _requestWatch);

        }

        public void LogResponse(DataProviderState state, ConnectionTypeIdentifier connection, object payload)
        {
            SendResponseAsync(new DataProviderIdentifier(_dataProviderName, DataProviderAction.Response, state)
                .SetPrice(
                    _dataProvider), connection, payload, _requestWatch);
        }

        public void LogEntryPointRequest(ICollection<IPointToLaceRequest> request)
        {
            SendEntryPointRequestAsync(request);
        }

        public void LogEntryPointResponse(object payload, DataProviderState state,
            ICollection<IPointToLaceRequest> request)
        {
            SendEntryPointResponseAsync(payload, state, request);
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
                        _commands.Workflow.Begin(payload, _executeWatch, _dataProviderName);
                    }
                    catch (Exception ex)
                    {
                        _log.ErrorFormat("An error occured sending a request to the bus because of {0}", ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occured sending a request to the bus because of {0}", ex.Message);
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
                        _commands.Workflow.End(payload, _executeWatch, _dataProviderName);
                    }
                    catch (Exception ex)
                    {
                        _log.ErrorFormat("An error occured sending a request to the bus because of {0}", ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occured sending a request to the bus because of {0}", ex.Message);
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
                        _commands.Workflow.Send(commandType, payload, metadata, _dataProviderName);
                    }
                    catch (Exception ex)
                    {
                        _log.ErrorFormat("An error occured sending a command to the bus because of {0}", ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occured sending a command to the bus because of {0}", ex.Message);
            }
        }

        private void SendRequestAsync(DataProviderIdentifier dataProvider,
            ConnectionTypeIdentifier connection, object payload,
            DataProviderStopWatch stopWatch)
        {
            try
            {
                Task.Run(() =>
                {
                    try
                    {
                        _commands.Workflow.DataProviderRequest(dataProvider, connection, payload, stopWatch);
                    }
                    catch (Exception ex)
                    {
                        _log.ErrorFormat("An error occured sending a request to the bus because of {0}", ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occured sending a request to the bus because of {0}", ex.Message);
            }
        }

        private void SendResponseAsync(DataProviderIdentifier dataProvider,
            ConnectionTypeIdentifier connection, object payload,
            DataProviderStopWatch stopWatch)
        {
            try
            {
                Task.Run(() =>
                {
                    try
                    {
                        _commands.Workflow.DataProviderResponse(dataProvider, connection, payload, stopWatch);
                    }
                    catch (Exception ex)
                    {
                        _log.ErrorFormat("An error occured sending a response to the bus because of {0}", ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occured sending a response to the bus because of {0}", ex.Message);
            }
        }

        private void SendEntryPointRequestAsync(ICollection<IPointToLaceRequest> request)
        {
            try
            {
                Task.Run(() =>
                {
                    try
                    {
                        _commands.Workflow.EntryPointRequest(request, _requestWatch);
                    }
                    catch (Exception ex)
                    {
                        _log.ErrorFormat("An error occured sending entry point request to the bus because of {0}", ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occured sending entry point request to the bus because of {0}", ex.Message);
            }
        }

        private void SendEntryPointResponseAsync(object payload, DataProviderState state,
            ICollection<IPointToLaceRequest> request)
        {
            try
            {
                Task.Run(() =>
                {
                    try
                    {
                        _commands.Workflow.EntryPointResponse(payload, _requestWatch, state, request);
                    }
                    catch (Exception ex)
                    {
                        _log.ErrorFormat("An error occured sending entry point request to the bus because of {0}", ex.Message);
                    }
                });
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occured sending entry point request to the bus because of {0}", ex.Message);
            }
        }
    }
}
