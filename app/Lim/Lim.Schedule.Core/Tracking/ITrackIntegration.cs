using System;
using Common.Logging;
using Lim.Core;
using Lim.Entities;
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
        private static readonly ILog Log = LogManager.GetLogger<TrackIntegration>();
        private readonly IRepository _repository;

        public TrackIntegration(IRepository repository)
        {
            _repository = repository;
        }

        public void Track(TrackIntegrationCommand command)
        {
            Log.InfoFormat("Storing Tracking information for Configuration {0}", command.ConfigurationId);

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
                Log.ErrorFormat("Failed to track integration information, because {0}", ex, ex.Message);
            }
        }

        public void Get(GetLastTransactionDateCommand command)
        {
            Log.InfoFormat("Getting Tracking information for Configuration Id {0}", command.ConfigurationId);

            try
            {
               
                var currentTracking =
                    _repository.Find<IntegrationTracking>(
                        w => w.Configuration.Id == command.ConfigurationId);

                if (currentTracking == null)
                {
                    Log.InfoFormat("Cannot find tracking information for Configuration with Id {0}", command.ConfigurationId);
                    throw new Exception("Tracking information not found");
                }

                command.Set(currentTracking.MaxTransactionDate);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Failed to get track integration information, because {0}", ex, ex.Message);
            }
        }
    }
}