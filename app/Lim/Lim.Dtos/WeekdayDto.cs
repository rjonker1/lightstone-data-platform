using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Enums;

namespace Lim.Dtos
{
    public class WeekdayDto
    {
        public WeekdayDto(int id, string day)
        {
            Id = id;
            Day = day;
        }

        public static List<WeekdayDto> Weekdays()
        {
            return Enum.GetValues(typeof (Weekdays)).Cast<Weekdays>().Select(s => new WeekdayDto((int) s, s.ToString())).ToList();
        }

        public int Id { get; private set; }
        public string Day { get; private set; }
    }
}