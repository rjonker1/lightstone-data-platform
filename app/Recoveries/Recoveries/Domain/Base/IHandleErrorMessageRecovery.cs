using Recoveries.Core;

namespace Recoveries.Domain.Base
{
    public interface IHandleErrorMessageRecovery
    {
        void Handle(IQueueOptions options);

        void HandleAll(IErrorQueueConfiguration[] configurations);
    }
}
