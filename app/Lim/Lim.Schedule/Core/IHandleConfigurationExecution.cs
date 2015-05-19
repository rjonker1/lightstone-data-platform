﻿using Lim.Schedule.Commands;

namespace Lim.Schedule.Core
{
    public interface IHandleExecutingApiConfiguration
    {
        void Handle(ExecuteApiPushConfigurationCommand command);
        void Handle(ExecuteApiPullConfigurationCommand command);
    }
}