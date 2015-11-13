using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core
{
    public interface IHandleExecutingApiConfiguration
    {
        void Handle(ExecuteApiPushConfigurationCommand command);
        void Handle(ExecuteApiPullConfigurationCommand command);
        bool IsHandled { get; }
    }

    public interface IHandleExecutingFlatFileConfiguration
    {
        void Handle(ExecuteFlatFilePullConfigurationCommand command);
        void Handle(ExecuteFlatFilePushConfigurationCommand command);
        bool IsHandled { get; }
    }
}