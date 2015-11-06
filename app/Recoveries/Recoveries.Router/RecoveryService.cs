using Common.Logging;
using Recoveries.Domain.Base;
using Recoveries.Infrastructure.Configuration;

namespace Recoveries.Router
{
    public interface IRecoveryService
    {
        void Start();
        void Stop();
    }

    public class RecoveryService : IRecoveryService
    {
        private readonly ILog _log = LogManager.GetLogger<RecoveryService>();
        private readonly IHandleErrorMessageRecovery _handler;
        public RecoveryService(IHandleErrorMessageRecovery handler)
        {
            _handler = handler;
        }

        public void Start()
        {
            _log.InfoFormat("Starting Recovery Service");

            //process any existing messages first
            _handler.HandleAll(ConfigurationReader.Configurations);

            _log.InfoFormat("Recovery Service Started");
        }
        public void Stop()
        {

        }
    }
}