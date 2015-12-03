using Lim.Domain.Base;
using Toolbox.LightstoneAuto.Database.Domain;
using Toolbox.LightstoneAuto.Database.Infrastructure.Commands;
using Toolbox.LSAuto.Entities;

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

        public void Handle(DeactivateDataSet message)
        {
            var dataSet = _repository.GetById(message.Id);
            dataSet.Deactivate();
            _repository.Save(dataSet, message.Version);
        }

        public void Handle(RenameDataSetExport message)
        {
            var dataSet = _repository.GetById(message.Id);
            dataSet.Rename(message.Name);
            _repository.Save(dataSet,message.OriginalVersion);
        }
    }
}