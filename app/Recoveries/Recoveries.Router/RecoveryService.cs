using Recoveries.ErrorQueues;

namespace Recoveries.Router
{
    public interface IRecoveryService
    {
        void Start();
        void Stop();
    }

    public class RecoveryService : IRecoveryService
    {

        private readonly IHandleErrorMessageRecovery _errorMessageRecoveryHandler;

        public RecoveryService()
        {
        }

        private RecoveryService(IHandleErrorMessageRecovery errorMessageRecoveryHandler)
        {
            _errorMessageRecoveryHandler = errorMessageRecoveryHandler;
        }

        public void Start()
        {
            var service = new RecoveryService(ErrorMessageRecoveryHandler.Create());
            service.Run();
        }

        private void Run()
        {
            _errorMessageRecoveryHandler.HandleAll(ConfigurationReader.Configurations);
        }

        public void Stop()
        {

        }
    }
}