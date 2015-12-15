using System.Collections.Generic;
using Lim.Dtos;

namespace Lim.Domain.Lookup.Commands
{
    public class GetAuthenticationTypes : Command
    {
        public void Set(IEnumerable<AuthenticationTypeDto> authentication)
        {
            Authentication = authentication;
        }

        public IEnumerable<AuthenticationTypeDto> Authentication { get; private set; }
    }

    public class GetFrequencyTypes : Command
    {
        public void Set(IEnumerable<FrequencyTypeDto> frequency)
        {
            Frequency = frequency;
        }

        public IEnumerable<FrequencyTypeDto> Frequency { get; private set; }
    }

    public class GetWeekdays : Command
    {
        public void Set(IEnumerable<WeekdayDto> weekdays)
        {
            Weekdays = weekdays;
        }

        public IEnumerable<WeekdayDto> Weekdays { get; private set; }
    }

    public class GetIntegrationTypes : Command
    {
    }

    public class GetActionType : Command
    {
    }
}