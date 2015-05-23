using System.Collections.Generic;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;
namespace Lim.Schedule.Core
{
    public interface IHandleFetchingApiPushConfiguration
    {
        IEnumerable<ApiPushIntegration> Configurations { get; }
        bool HasConfiguration { get; }
        void Handle(FetchConfigurationCommand command);
        void Handle(FetchConfigurationForClientCommand command);
        void Handle(FetchConfigurationForCustomCommand command);
    }

    public interface IHandleFetchingApiPullConfiguration
    {
        IEnumerable<ApiPullIntegration> Configurations { get; }
        bool HasConfiguration { get; }
        void Handle(FetchConfigurationCommand command);
        void Handle(FetchConfigurationForClientCommand command);
        void Handle(FetchConfigurationForCustomCommand command);
    }
}