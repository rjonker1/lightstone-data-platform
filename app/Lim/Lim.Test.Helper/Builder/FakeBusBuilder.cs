using Lim.Domain.EventStore;
using Lim.Test.Helper.Fakes;
using Toolbox.LightstoneAuto.Domain;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;
using Toolbox.LightstoneAuto.Domain.Events;
using Toolbox.LightstoneAuto.Infrastructure.Handlers;
using Toolbox.LightstoneAuto.Infrastructure.Read.Handlers;

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
            bus.RegisterHandler<DataSetExportDeActivated>(detailHandler.Handle);
            bus.RegisterHandler<DataSetExportModified>(detailHandler.Handle);

            var dataSetHandler = new DataSetDtoHandler(FakeDataBaseBuilder.ForDataSetDtoRepository());
            bus.RegisterHandler<DataSetExportCreated>(dataSetHandler.Handle);
            bus.RegisterHandler<DataSetExportDeActivated>(dataSetHandler.Handle);
            bus.RegisterHandler<DataSetExportModified>(dataSetHandler.Handle);
            return bus;
        }
    }
}
