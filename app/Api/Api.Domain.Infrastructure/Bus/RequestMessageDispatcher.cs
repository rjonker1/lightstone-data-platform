using System;
using System.Configuration;
using Api.Domain.Infrastructure.Messages;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;

namespace Api.Domain.Infrastructure.Bus
{
    public class RequestMessageDispatcher : AbstractMessageDispatcher<RequestReportMessage>
    {
        private readonly IAdvancedBus _bus;
        private readonly IExchange _exchange;
        private readonly ILog _log = LogManager.GetLogger<RequestMessageDispatcher>();

        private readonly string _exchangeName = ConfigurationManager.AppSettings["api/bus/exchange/name"] ?? "DataPlatform.Api";
        private readonly string _queueName = ConfigurationManager.AppSettings["api/bus/queue/name"] ?? "DataPlatform.Api";
        public RequestMessageDispatcher(IAdvancedBus bus)
        {
            _bus = bus;
            _exchange = _bus.ExchangeDeclare(_exchangeName,
               ExchangeType.Fanout);
            _bus.Bind(_exchange, _bus.QueueDeclare(_queueName), "");
        }

        public override void Dispatch(RequestReportMessage message)
        {
            try
            {
                _bus.Publish(_exchange, "", true, false, new Message<RequestReportMessage>(message));
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred dispatching API request meta data to bus because of {0}",ex,ex.Message);
            }
        }
    }
}