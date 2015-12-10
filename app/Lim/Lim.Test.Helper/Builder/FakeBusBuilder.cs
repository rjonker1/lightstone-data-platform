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
            var repository = new AggregateRepository<DataSetExport>(storage);
            var commands = new DataSetCommandHandler(repository);
            bus.RegisterHandler<CreateDataSetExport>(commands.Handle);
            bus.RegisterHandler<DeActivateDataSetExport>(commands.Handle);
            bus.RegisterHandler<ModifyDataSetExport>(commands.Handle);

            var detailConsumer = new DataSetExportEventConsumer(bus,new FakeLsAutoDataSetCommit());
            bus.RegisterConsumer<IMessage<DataSetExportCreated>>(detailConsumer.Consume);
            bus.RegisterConsumer<IMessage<DataSetExportDeActivated>>(detailConsumer.Consume);
            bus.RegisterConsumer<IMessage<DataSetExportModified>>(detailConsumer.Consume);

            var viewConsumer = new ViewImportEventConsumer(bus, new FakeLsAutoViewCommit());
            bus.RegisterConsumer<IMessage<ViewImportCreated>>(viewConsumer.Consume);
            bus.RegisterConsumer<IMessage<ViewImportModified>>(viewConsumer.Consume);
            bus.RegisterConsumer<IMessage<ViewImportReloaded>>(viewConsumer.Consume);
            bus.RegisterConsumer<IMessage<ViewImportDeActivated>>(viewConsumer.Consume);
            return bus;
        }
    }
}
