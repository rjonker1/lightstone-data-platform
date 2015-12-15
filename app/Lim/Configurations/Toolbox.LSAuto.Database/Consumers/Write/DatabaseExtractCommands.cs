using EasyNetQ;
using Lim.Domain.Base;
using Toolbox.LightstoneAuto.Domain;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;

namespace Toolbox.LightstoneAuto.Consumers.Write
{
    public class DatabaseExtractCommandConsumer
    {
        private readonly IAggregateRepository<DatabaseExtract> _repository;

        public DatabaseExtractCommandConsumer(IAggregateRepository<DatabaseExtract> repository)
        {
            _repository = repository;
        }

        public void Consume(IMessage<CreateDataExtract> message)
        {
            var dataSet = new DatabaseExtract(message.Body);
            _repository.Save(dataSet, -1);
        }

        public void Consume(IMessage<ModifyDataExtract> message)
        {
            var dataSet = new DatabaseExtract();
            dataSet.Modify(message.Body);
            _repository.Save(dataSet,message.Body.Version);
        }

        public void Consume(IMessage<DeActivateDataExtract> message)
        {
            var dataSet = new DatabaseExtract();
            dataSet.Deactivate(message.Body);
            _repository.Save(dataSet, message.Body.Version);
        }
    }
}
