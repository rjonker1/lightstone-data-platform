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
            _log.InfoFormat("Storing Tracking information for Integration Type {0} Action {1} Frequency {2}", (Enums.IntegrationType)command.Type, (Enums.IntegrationAction)command.Action, (Enums.Frequency)command.Frequency);

            try
            {
                var action = _repository.Get<ActionType>(command.Action);
                var frequency = _repository.Get<FrequencyType>(command.Frequency);
                var type = _repository.Get<IntegrationType>(command.Type);

                var currentTracking =
                    _repository.Find<IntegrationTracking>(
                        w => w.Action.Id == command.Action && w.Frequency.Id == command.Frequency && w.Type.Id == command.Type);

                var tracking = new IntegrationTracking()
                {
                    Id = currentTracking != null ? currentTracking.Id : 0,
                    Action = action,
                    Frequency = frequency,
                    Type = type,
                    Updated = DateTime.UtcNow,
                    MaxTransactionDate = command.MaxTransactionDate,
                    TransactionCount =
                        currentTracking == null ? command.TransactionsIntegrated : currentTracking.TransactionCount + command.TransactionsIntegrated
                };

                _repository.Merge(tracking);
                _repository.Flush();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Failed to track integration information, because {0}", ex, ex.Message);
            }
        }

        public void Get(GetLastTransactionDateCommand command)
        {
            _log.InfoFormat("Getting Tracking information for Integration Type {0} Action {1} Frequency {2}", (Enums.IntegrationType)command.Type, (Enums.IntegrationAction)command.Action, (Enums.Frequency)command.Frequency);

            try
            {
               
                var currentTracking =
                    _repository.Find<IntegrationTracking>(
                        w => w.Action.Id == command.Action && w.Frequency.Id == command.Frequency && w.Type.Id == command.Type);

                if (currentTracking == null)
                {
                    _log.InfoFormat("Cannot find tracking information for Integration Type {0} Action {1} Frequency {2}", (Enums.IntegrationType)command.Type, (Enums.IntegrationAction)command.Action, (Enums.Frequency)command.Frequency);
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