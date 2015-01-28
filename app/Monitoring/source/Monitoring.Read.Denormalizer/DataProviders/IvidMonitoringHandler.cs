using System;
using System.Text;
using Lace.Shared.Extensions;
using Lace.Shared.Monitoring.Messages.Events;
using Monitoring.Domain.Core.Contracts;
using Monitoring.Read.ReadModel.Models;
using NServiceBus;

namespace Monitoring.Read.Denormalizer.DataProviders
{
    public class IvidMonitoringHandler : IHandleMessages<IvidExecutionHasStarted>, IHandleMessages<IvidExcutionHasEnded>,
        IHandleMessages<IvidDataSourceCallHasStarted>, IHandleMessages<IvidDataSourceCallHasEnded>,
        IHandleMessages<IvidSecurityFlag>, IHandleMessages<IvidConfigured>, IHandleMessages<IvidResponseTransformed>
    {

        private readonly IAccessToStorage _storage;

        public IvidMonitoringHandler(IAccessToStorage storage)
        {
            _storage = storage;
        }

        public void Handle(IvidExecutionHasStarted message)
        {
            var model = new MonitoringStorageModel(message.Id)
            {
                Payload = Encoding.UTF8.GetBytes(message.ObjectToJson()),
                Source = (int) message.DataProviderCommandSource,
                Date = message.Date,
                TimeStamp = DateTime.UtcNow
            };

            _storage.Add(model);
        }

        public void Handle(IvidExcutionHasEnded message)
        {
            var model = new MonitoringStorageModel(message.Id)
            {
                Payload = Encoding.UTF8.GetBytes(message.ObjectToJson()),
                Source = (int) message.DataProviderCommandSource,
                Date = message.Date,
                TimeStamp = DateTime.UtcNow
            };

            _storage.Add(model);
        }

        public void Handle(IvidResponseTransformed message)
        {
            var model = new MonitoringStorageModel(message.Id)
            {
                Payload = Encoding.UTF8.GetBytes(message.ObjectToJson()),
                Source = (int) message.DataProviderCommandSource,
                Date = message.Date,
                TimeStamp = DateTime.UtcNow
            };

            _storage.Add(model);
        }

        public void Handle(IvidConfigured message)
        {
            var model = new MonitoringStorageModel(message.Id)
            {
                Payload = Encoding.UTF8.GetBytes(message.ObjectToJson()),
                Source = (int) message.DataProviderCommandSource,
                Date = message.Date,
                TimeStamp = DateTime.UtcNow
            };

            _storage.Add(model);
        }

        public void Handle(IvidSecurityFlag message)
        {
            var model = new MonitoringStorageModel(message.Id)
            {
                Payload = Encoding.UTF8.GetBytes(message.ObjectToJson()),
                Source = (int) message.DataProviderCommandSource,
                Date = message.Date,
                TimeStamp = DateTime.UtcNow
            };

            _storage.Add(model);
        }

        public void Handle(IvidDataSourceCallHasEnded message)
        {
            var model = new MonitoringStorageModel(message.Id)
            {
                Payload = Encoding.UTF8.GetBytes(message.ObjectToJson()),
                Source = (int) message.DataProviderCommandSource,
                Date = message.Date,
                TimeStamp = DateTime.UtcNow
            };

            _storage.Add(model);
        }

        public void Handle(IvidDataSourceCallHasStarted message)
        {
            var model = new MonitoringStorageModel(message.Id)
            {
                Payload = Encoding.UTF8.GetBytes(message.ObjectToJson()),
                Source = (int) message.DataProviderCommandSource,
                Date = message.Date,
                TimeStamp = DateTime.UtcNow
            };

            _storage.Add(model);
        }
    }
}
