using System;
using System.Text;
using DataPlatform.Shared.Messaging.Events;
using Monitoring.Domain.Core.Contracts;
using Monitoring.Read.ReadModel.Models;
using NServiceBus;

namespace Monitoring.Read.Denormalizer
{
    public class MonitoringHandler : IHandleMessages<MonitoringEvent>
    {
        private readonly IAccessToStorage _storage;

        public MonitoringHandler(IAccessToStorage storage)
        {
            _storage = storage;
        }

        public void Handle(MonitoringEvent message)
        {
            var model = new MonitoringStorageModel(message.AggregateId)
            {
                Payload = Encoding.UTF8.GetBytes(message.Payload),
                Source = (int) message.Source,
                Date = message.Date,
                TimeStamp = DateTime.UtcNow
            };

            _storage.Add(model);
        }
    }
}
