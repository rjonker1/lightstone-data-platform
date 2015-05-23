﻿using System.Collections.Generic;
using Lim.Domain.Models;

namespace Lim.Web.UI.Commands
{
    public class GetAuthenticationTypes
    {
        public void Set(IEnumerable<AuthenticationType> authentication)
        {
            Authentication = authentication;
        }

        public IEnumerable<AuthenticationType> Authentication { get; private set; }
    }

    public class GetFrequencyTypes
    {
        public void Set(IEnumerable<FrequencyType> frequency)
        {
            Frequency = frequency;
        }

        public IEnumerable<FrequencyType> Frequency { get; private set; }
    }

    public class GetWeekdays
    {
        public void Set(IEnumerable<Weekday> weekdays)
        {
            Weekdays = weekdays;
        }

        public IEnumerable<Weekday> Weekdays { get; private set; }
    }

    public class GetIntegrationTypes
    {
    }

    public class GetActionType
    {
    }
}