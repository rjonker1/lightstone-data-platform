using System.Collections.Generic;
using Lim.Domain.Dto;

namespace Lim.Web.UI.Commands
{
    public class GetAuthenticationTypes
    {
        public void Set(IEnumerable<AuthenticationTypeDto> authentication)
        {
            Authentication = authentication;
        }

        public IEnumerable<AuthenticationTypeDto> Authentication { get; private set; }
    }

    public class GetFrequencyTypes
    {
        public void Set(IEnumerable<FrequencyTypeDto> frequency)
        {
            Frequency = frequency;
        }

        public IEnumerable<FrequencyTypeDto> Frequency { get; private set; }
    }

    public class GetWeekdays
    {
        public void Set(IEnumerable<WeekdayDto> weekdays)
        {
            Weekdays = weekdays;
        }

        public IEnumerable<WeekdayDto> Weekdays { get; private set; }
    }

    public class GetIntegrationTypes
    {
    }

    public class GetActionType
    {
    }
}