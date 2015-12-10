using EasyNetQ;
using Lim.Domain.Base;
using Toolbox.LightstoneAuto.Domain;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;

namespace Toolbox.LightstoneAuto.Consumers.Write
{
    public class DataSetExportCommandConsumer
    {
        private readonly IAggregateRepository<DataSetExport> _repository;

        public DataSetExportCommandConsumer(IAggregateRepository<DataSetExport> repository)
        {
            _repository = repository;
        }

        public void Consume(IMessage<CreateDataSetExport> message)
        {
            var dataSet = new DataSetExport(message.Body);
            _repository.Save(dataSet, -1);
        }

        public void Consume(IMessage<ModifyDataSetExport> message)
        {
            var dataSet = new DataSetExport();
            dataSet.Modify(message.Body);
            _repository.Save(dataSet,message.Body.Version);
        }

        public void Consume(IMessage<DeActivateDataSetExport> message)
        {
            var dataSet = new DataSetExport();
            dataSet.Deactivate(message.Body);
            _repository.Save(dataSet, message.Body.Version);
        }
    }
}
