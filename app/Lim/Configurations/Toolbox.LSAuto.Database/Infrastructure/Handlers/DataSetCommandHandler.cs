using Lim.Domain.Base;
using Toolbox.LightstoneAuto.Domain;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;

namespace Toolbox.LightstoneAuto.Infrastructure.Handlers
{
    public class DataSetCommandHandler
    {
        private readonly IAggregateRepository<DatabaseExtract> _repository;

        public DataSetCommandHandler(IAggregateRepository<DatabaseExtract> repository)
        {
            _repository = repository;
        }

        public void Handle(CreateDataExtract message)
        {
            var dataSet = new DatabaseExtract(message);
            _repository.Save(dataSet, -1);
        }

        public void Handle(DeActivateDataExtract message)
        {
            var dataSet = _repository.GetById(message.AggregateId);
            dataSet.Deactivate(new DeActivateDataExtract(message.DataSetId,message.User,message.Version, message.CorrelationId));
            _repository.Save(dataSet, message.Version);
        }

        public void Handle(ModifyDataExtract message)
        {
            var dataSet = _repository.GetById(message.AggregateId);
            dataSet.Modify(new ModifyDataExtract(message.DatabaseExtract,message.User, message.Version,message.CorrelationId));
            _repository.Save(dataSet, message.Version);
        }
    }
}