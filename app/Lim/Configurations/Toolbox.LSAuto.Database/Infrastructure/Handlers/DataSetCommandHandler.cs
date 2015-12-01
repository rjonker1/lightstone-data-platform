using Toolbox.LightstoneAuto.Database.Domain.Base;
using Toolbox.LightstoneAuto.Database.Domain.Entities;
using Toolbox.LightstoneAuto.Database.Infrastructure.Commands;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Handlers
{
    public class DataSetCommandHandler
    {
        private readonly IAggregateRepository<DataSet> _repository;

        public DataSetCommandHandler(IAggregateRepository<DataSet> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateDataSet message)
        {
            var dataSet = new DataSet(message.Id, message.Name);
            _repository.Save(dataSet, -1);
        }

        public void Handle(DeactivateDataSet message)
        {
            var dataSet = _repository.GetById(message.Id);
            dataSet.Deactivate();
            _repository.Save(dataSet, message.Version);
        }
    }
}
