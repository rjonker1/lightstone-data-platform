using Lim.Domain.EventStore;
using Lim.Test.Helper.Fakes;
using Toolbox.LightstoneAuto.Database.Domain;
using Toolbox.LightstoneAuto.Database.Domain.Events;
using Toolbox.LightstoneAuto.Database.Infrastructure.Commands;
using Toolbox.LightstoneAuto.Database.Infrastructure.Handlers;
using Toolbox.LightstoneAuto.Database.Infrastructure.Read.Handlers;

namespace Lim.Test.Helper.Builder
{
    public static class FakeBusBuilder
    {
        public static FakeBus Bus()
        {
            var bus = new FakeBus();
            var eventStoreRepository = FakeDataBaseBuilder.ForEventStore();
            var storage = new EventStore(bus, eventStoreRepository);
            var repository = new AggregateRepository<DataSetExport>(storage);
            var commands = new DataSetCommandHandler(repository);
            bus.RegisterHandler<CreateDataSetExport>(commands.Handle);
            bus.RegisterHandler<DeActivateDataSetExport>(commands.Handle);
            bus.RegisterHandler<ModifyDataSetExport>(commands.Handle);

            var detailHandler = new DataSetDetailDtoHandler(FakeDataBaseBuilder.ForDataSetDtoRepository());
            bus.RegisterHandler<DataSetExportCreated>(detailHandler.Handle);
            bus.RegisterHandler<DataSetDeActivated>(detailHandler.Handle);
            bus.RegisterHandler<DataSetModified>(detailHandler.Handle);

            var dataSetHandler = new DataSetDtoHandler(FakeDataBaseBuilder.ForDataSetDtoRepository());
            bus.RegisterHandler<DataSetExportCreated>(dataSetHandler.Handle);
            bus.RegisterHandler<DataSetDeActivated>(dataSetHandler.Handle);
            bus.RegisterHandler<DataSetModified>(dataSetHandler.Handle);
            return bus;
        }
    }
}
