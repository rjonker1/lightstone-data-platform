using System;
using System.Linq;
using Lace.Shared.Monitoring.Messages.Core;
using Monitoring.Read.Denormalizer.DataProvider;
using Monitoring.Read.ReadModel.Models.DataProviders;
using Monitoring.Test.Helper.Builder.DataProviderEvents;
using Monitoring.Test.Helper.Fakes;
using Xunit.Extensions;

namespace Monitoring.Unit.Tests.DataProviders
{
    public class when_handling_data_provider_events : Specification
    {
        private readonly DataProviderMonitoringHandler _handler;
        private readonly FakeMonitoringReadStoreage _storage;
        private readonly Guid _aggregateId;

        public when_handling_data_provider_events()
        {
            _aggregateId = Guid.NewGuid();
            _storage = new FakeMonitoringReadStoreage();
            _handler = new DataProviderMonitoringHandler(_storage);
        }

        public override void Observe()
        {

        }

        [Observation]
        public void then_database_should_be_added_with_data_provider_call_ended_event()
        {
            _handler.Handle(new DataProviderEvents().ForDataProviderCallEndedEvent(_aggregateId,
                DataProvider.Ivid, Category.Performance));
            _storage.Database.Count.ShouldEqual(1);
            _storage.Database.FirstOrDefault().ShouldBeType<MonitoringDataProviderModel>();
        }

        [Observation]
        public void then_database_should_be_added_with_data_provider_executing_event()
        {
            _handler.Handle(new DataProviderEvents().ForDataProviderExecutingEvent(_aggregateId,
                DataProvider.Ivid, Category.Performance));
            _storage.Database.Count.ShouldEqual(1);
            _storage.Database.FirstOrDefault().ShouldBeType<MonitoringDataProviderModel>();
        }

        [Observation]
        public void then_database_should_be_added_with_data_provider_configuration_event()
        {
            _handler.Handle(new DataProviderEvents().ForDataProviderHasConfigurationEvent(_aggregateId,
                DataProvider.Ivid, Category.Configuration));
            _storage.Database.Count.ShouldEqual(1);
            _storage.Database.FirstOrDefault().ShouldBeType<MonitoringDataProviderModel>();
        }

        [Observation]
        public void then_database_should_be_added_with_data_provider_has_executed_event()
        {
            _handler.Handle(new DataProviderEvents().ForDataProviderHasExecutedEvent(_aggregateId,
                DataProvider.Ivid, Category.Performance));
            _storage.Database.Count.ShouldEqual(1);
            _storage.Database.FirstOrDefault().ShouldBeType<MonitoringDataProviderModel>();
        }

        [Observation]
        public void then_database_should_be_added_with_data_provider_has_fault_event()
        {
            _handler.Handle(new DataProviderEvents().ForDataProviderHasFaultEvent(_aggregateId,
                DataProvider.Ivid, Category.Fault));
            _storage.Database.Count.ShouldEqual(1);
            _storage.Database.FirstOrDefault().ShouldBeType<MonitoringDataProviderModel>();
        }

        [Observation]
        public void then_database_should_be_added_with_data_provider_has_security_event()
        {
            _handler.Handle(new DataProviderEvents().ForDataProviderHasSecurityEvent(_aggregateId,
                DataProvider.Ivid, Category.Security));
            _storage.Database.Count.ShouldEqual(1);
            _storage.Database.FirstOrDefault().ShouldBeType<MonitoringDataProviderModel>();
        }

        [Observation]
        public void then_database_should_be_added_with_data_provider_has_transformed_event()
        {
            _handler.Handle(new DataProviderEvents().ForDataProviderasBeenTransformedEvent(_aggregateId,
                DataProvider.Ivid, Category.Configuration));
            _storage.Database.Count.ShouldEqual(1);
            _storage.Database.FirstOrDefault().ShouldBeType<MonitoringDataProviderModel>();
        }

        [Observation]
        public void then_database_should_be_added_with_data_provider_is_called_event()
        {
            _handler.Handle(new DataProviderEvents().ForDataProviderIsCalledEvent(_aggregateId,
                DataProvider.Ivid, Category.Performance));
            _storage.Database.Count.ShouldEqual(1);
            _storage.Database.FirstOrDefault().ShouldBeType<MonitoringDataProviderModel>();
        }
    }
}
