using EasyNetQ;
using Lim.Domain.EventStore;
using Lim.Test.Helper.Fakes;
using Lim.Test.Helper.Fakes.Repository;
using Toolbox.LightstoneAuto.Consumers.Read;
using Toolbox.LightstoneAuto.Domain;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;
using Toolbox.LightstoneAuto.Domain.Events;
using Toolbox.LightstoneAuto.Infrastructure.Handlers;

namespace Lim.Test.Helper.Builder
{
    public static class FakeBusBuilder
    {
        public static FakeBus LsAutoBus()
        {
            var bus = new FakeBus();
            var eventStoreRepository = FakeDataBaseBuilder.ForEventStore();
            var storage = new EventStore(bus, eventStoreRepository);
            var repository = new AggregateRepository<DatabaseExtract>(storage);
            var commands = new DataSetCommandHandler(repository);
            bus.RegisterHandler<CreateDataExtract>(commands.Handle);
            bus.RegisterHandler<DeActivateDataExtract>(commands.Handle);
            bus.RegisterHandler<ModifyDataExtract>(commands.Handle);

            var detailConsumer = new DatabaseExtractEventConsumer(bus,new FakeLsAutoDataSetCommit());
            bus.RegisterConsumer<DatabaseExtractCreated>((message) => detailConsumer.Consume((IMessage<DatabaseExtractCreated>) message));
            bus.RegisterConsumer<DatabaseExtractDeActivated>((message) => detailConsumer.Consume((IMessage<DatabaseExtractDeActivated>)message));
            bus.RegisterConsumer<DatabaseExtractModified>((message) => detailConsumer.Consume((IMessage<DatabaseExtractModified>)message));

            var viewConsumer = new DatabaseViewEventConsumer(bus, bus, new FakeLsAutoViewCommit(), new FakeDataSetReadModel());
            bus.RegisterConsumer<DatabaseViewLoaded>((message) => viewConsumer.Consume((IMessage<DatabaseViewLoaded>)message));
            bus.RegisterConsumer<DatabaseViewModified>((message) => viewConsumer.Consume((IMessage<DatabaseViewModified>)message));
            return bus;
        }
    }
}
