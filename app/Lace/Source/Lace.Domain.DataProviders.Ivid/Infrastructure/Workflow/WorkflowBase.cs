using System;
using System.Threading.Tasks;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Infrastructure;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Workflow
{
    public class WorkflowBase
    {
        private readonly ISendCommandToBus _commands;
        private readonly DataProviderCommandSource _dataProviderName;
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;

        public WorkflowBase(ISendCommandToBus commands, DataProviderCommandSource dataProviderName,
            IAmDataProvider dataProvider)
        {
            _commands = commands;
            _dataProviderName = dataProviderName;
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
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

        public void LogRequest(ConnectionTypeIdentifier connection, DataProviderStopWatch stopWatch, object payload)
        {
            SendRequestAsync(
                new DataProviderIdentifier(_dataProviderName, DataProviderAction.Request, DataProviderState.Successful)
                    .SetPrice(_dataProvider), connection, payload, stopWatch);

        }

        public void LogResponse(DataProviderState state, ConnectionTypeIdentifier connection,
            DataProviderStopWatch stopWatch, object payload)
        {
            SendResponseAsync(new DataProviderIdentifier(_dataProviderName, DataProviderAction.Response, state)
                .SetPrice(
                    _dataProvider), connection, payload, stopWatch);
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
    }
}
