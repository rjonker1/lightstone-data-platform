using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core
{
    public interface IHandleExecutingApiConfiguration
    {
        void Handle(ExecuteApiPushConfigurationCommand command);
        void Handle(ExecuteApiPullConfigurationCommand command);
    }
}