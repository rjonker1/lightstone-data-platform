using System;
using Common.Logging;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Repository;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Tracking
{
    public interface ITrackIntegration
    {
        void Track(TrackIntegrationCommand command);
        void Get(GetLastTransactionDateCommand command);
    }

    public class TrackIntegration : ITrackIntegration
    {
        private readonly ILog _log;
        private readonly IAmRepository _repository;

        public TrackIntegration(IAmRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void Track(TrackIntegrationCommand command)
        {
            _log.InfoFormat("Storing Tracking information for Configuration {0}", command.ConfigurationId);

            try
            {
                var configuration = _repository.Get<Configuration>(command.ConfigurationId);

                var current =
                    _repository.Find<IntegrationTracking>(
                        w => w.Configuration.Id == configuration.Id);

                var tracking = new IntegrationTracking()
                {
                    Id = current != null ? current.Id : 0,
                    Configuration = configuration,
                    Updated = DateTime.UtcNow,
                    MaxTransactionDate = command.MaxTransactionDate,
                    TransactionCount =
                        current == null ? command.TransactionsCount : current.TransactionCount + command.TransactionsCount
                };

                _repository.Merge(tracking);
               // _repository.Flush();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to track integration information, because {0}", ex, ex.Message);
            }
        }

        public void Get(GetLastTransactionDateCommand command)
        {
            _log.InfoFormat("Getting Tracking information for Configuration Id {0}", command.ConfigurationId);

            try
            {
               
                var currentTracking =
                    _repository.Find<IntegrationTracking>(
                        w => w.Configuration.Id == command.ConfigurationId);

                if (currentTracking == null)
                {
                    _log.InfoFormat("Cannot find tracking information for Configuration with Id {0}", command.ConfigurationId);
                    throw new Exception("Tracking information not found");
                }

                command.Set(currentTracking.MaxTransactionDate);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to get track integration information, because {0}", ex, ex.Message);
            }
        }
    }
}