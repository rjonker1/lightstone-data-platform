using System.Collections.Generic;
using Lim.Schedule.Commands;
using Lim.Schedule.Indentifiers;

namespace Lim.Schedule.Core
{
    public interface IHandleFetchingApiPushConfiguration
    {
        IEnumerable<ApiPushIntegration> Configurations { get; }
        bool HasConfiguration { get; }
        void Handle(FetchConfigurationCommand command);
    }

    public interface IHandleFetchingApiPullConfiguration
    {
        IEnumerable<ApiPullIntegration> Configurations { get; }
        bool HasConfiguration { get; }
        void Handle(FetchConfigurationCommand command);
    }
}