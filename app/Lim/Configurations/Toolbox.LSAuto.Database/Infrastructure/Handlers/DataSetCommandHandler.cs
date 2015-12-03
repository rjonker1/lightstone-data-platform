using Lim.Domain.Base;
using Toolbox.LightstoneAuto.Database.Domain;
using Toolbox.LightstoneAuto.Database.Infrastructure.Commands;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Handlers
{
    public class DataSetCommandHandler
    {
        private readonly IAggregateRepository<DataSetExport> _repository;

        public DataSetCommandHandler(IAggregateRepository<DataSetExport> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateDataSetExport message)
        {
            var dataSet = new DataSetExport(message);
            _repository.Save(dataSet, -1);
        }

        public void Handle(DeActivateDataSetExport message)
        {
            var dataSet = _repository.GetById(message.DataSetId);
            dataSet.Deactivate(new DeActivateDataSetExport(message.DataSetId,message.User,message.Version, message.CorrelationId));
            _repository.Save(dataSet, message.Version);
        }

        public void Handle(ModifyDataSetExport message)
        {
            var dataSet = _repository.GetById(message.DataSet.Id);
            dataSet.Rename(new ModifyDataSetExport(message.DataSet,message.User, message.Version,message.CorrelationId));
            _repository.Save(dataSet, message.Version);
        }
    }
}