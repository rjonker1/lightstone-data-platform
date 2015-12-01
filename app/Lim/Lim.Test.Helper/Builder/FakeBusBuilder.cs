using Lim.Test.Helper.Fakes;
using Toolbox.LightstoneAuto.Database.Domain.Base;
using Toolbox.LightstoneAuto.Database.Domain.Entities;
using Toolbox.LightstoneAuto.Database.Domain.Events;
using Toolbox.LightstoneAuto.Database.Infrastructure.Commands;
using Toolbox.LightstoneAuto.Database.Infrastructure.Handlers;
using Toolbox.LightstoneAuto.Database.Infrastructure.Read.Handlers;
using Toolbox.LightstoneAuto.Database.Infrastructure.Repository;

namespace Lim.Test.Helper.Builder
{
    public static class FakeBusBuilder
    {
        public static FakeBus Bus()
        {
            var bus = new FakeBus();
            var storage = new EventStore(bus);
            var repository = new AggregateRepository<DataSet>(storage);
            var commands = new DataSetCommandHandler(repository);
            bus.RegisterHandler<CreateDataSet>(commands.Handle);
            bus.RegisterHandler<DeactivateDataSet>(commands.Handle);

            var detailHandler = new DataSetDetailDtoHandler(FakeDataBaseBuilder.ForDataSetDetailDtoRepository());
            bus.RegisterHandler<DataSetCreated>(detailHandler.Handle);
            bus.RegisterHandler<DataSetDeActivated>(detailHandler.Handle);

            var dataSetHandler = new DataSetDtoHandler(FakeDataBaseBuilder.ForDataSetDtoRepository());
            bus.RegisterHandler<DataSetCreated>(dataSetHandler.Handle);
            bus.RegisterHandler<DataSetDeActivated>(dataSetHandler.Handle);
            return bus;
        }
    }
}
